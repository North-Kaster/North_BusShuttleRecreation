using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using DomainModel;
using BusShuttleMVC.Models;
using BusShuttleMVC.Services;
using BusShuttleMVC.Data;


namespace BusShuttleMVC.Controllers
{
    [Authorize(Policy = "IsManager")]
    public class ManagerController : Controller
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly IBusService _busService;
        private readonly IBusStopService _busStopService;
        private readonly IBusLoopService _busLoopService;
        private readonly IBusRouteService _busRouteService;
        private readonly IEntryService _entryService;
        private readonly UserManager<IdentityUser> _userManager;

        // Models
        private List<EntryViewModel> GetEntryViewModels()
        {
            var entries = _entryService.GetEntries();

            return entries.Select(e => new EntryViewModel
            {
                Timestamp = e.Timestamp,
                Boarded = e.Boarded,
                LeftBehind = e.LeftBehind,
                Driver = e.Driver,
                BusNumber = e.BusNumber,
                BusLoopName = _busLoopService.FindBusLoopByID(e.BusLoopId)?.Name,
                BusStopName = _busStopService.FindBusStopByID(e.BusStopId)?.Name
            }).ToList();
        }

        private IEnumerable<BusViewModel> GetBusViewModels()
        {
            return _busService.GetAllBuses().Select(BusViewModel.FromBus);
        }

        public ManagerController(ILogger<ManagerController> logger, IBusService busService, IBusStopService busStopService, IBusLoopService busLoopService, IBusRouteService busRouteService, IEntryService entryService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _busService = busService;
            _busStopService = busStopService;
            _busLoopService = busLoopService;
            _busRouteService = busRouteService;
            _entryService = entryService;
            _userManager = userManager;
        }

        public IActionResult ManagerDashboard()
        {
            var entries = _entryService.GetEntries();
            var buses = _busService.GetAllBuses().Select(t => BusViewModel.FromBus(t));

            var model = new ManagerDashboardViewModel
            {
                Entries = GetEntryViewModels(),
                Buses = GetBusViewModels()
            };

            return View(model);
        }

        public IActionResult ManageBuses()
        {
            return View(GetBusViewModels());
        }

        [HttpPost]
        public IActionResult AddBus(int busNumber)
        {
            var bus = new Bus(Guid.NewGuid(), 0) { BusNumber = busNumber };
            _busService.AddBus(bus);
            return RedirectToAction("ManageBuses");
        }
        [HttpPost]
        public IActionResult DeleteBus(Guid id)
        {
            var bus = _busService.FindBusByID(id);
            if (bus != null)
            {
                _busService.DeleteBus(bus);
            }
            return RedirectToAction("ManageBuses");
        }

        public IActionResult ManageBusStops()
        {
            return View(_busStopService.GetAllBusStops().Select(t => BusStopViewModel.FromBusStop(t)));
        }
        public IActionResult AddBusStop(string busStopName, double latitude, double longitude)
        {
            var busStop = new BusStop(Guid.NewGuid(), busStopName, latitude, longitude);
            _busStopService.AddBusStop(busStop);
            return RedirectToAction("ManageBusStops");
        }
        public IActionResult DeleteBusStop(Guid id)
        {
            var busStop = _busStopService.FindBusStopByID(id);
            if (busStop != null)
            {
                _busStopService.DeleteBusStop(busStop);
            }
            return RedirectToAction("ManageBusStops");
        }
        public IActionResult ManageBusLoops()
        {
            return View(_busLoopService.GetAllBusLoops().Select(t => BusLoopViewModel.FromBusLoop(t)));
        }
        public IActionResult AddBusLoop(string busLoopName)
        {
            var busRoute = new BusRoute(Guid.NewGuid());
            _busRouteService.AddBusRoute(busRoute);

            var busLoop = new BusLoop(Guid.NewGuid(), busLoopName, busRoute);
            _busLoopService.AddBusLoop(busLoop);

            return RedirectToAction("ManageBusLoops");
        }
        public IActionResult DeleteBusLoop(Guid id)
        {
            var busLoop = _busLoopService.FindBusLoopByID(id);
            if (busLoop != null)
            {
                _busLoopService.DeleteBusLoop(busLoop);
            }
            return RedirectToAction("ManageBusLoops");
        }
        public IActionResult ManageRoutes()
        {
            var busLoops = _busLoopService.GetAllBusLoops().Select(t => BusLoopViewModel.FromBusLoop(t));
            var busStops = _busStopService.GetAllBusStops().Select(t => BusStopViewModel.FromBusStop(t));
            var busRouteViewModel = new BusRouteViewModel { BusLoops = busLoops, BusStops = busStops };
            return View(busRouteViewModel);
        }
        [HttpPost]
        public IActionResult AddStopToRoute(Guid busLoopId, Guid busStopId)
        {
            var busLoop = _busLoopService.FindBusLoopByID(busLoopId);

            // Some checks I made for debugging purposes. Have proven to be useful to keep around
            if (busLoop == null)
            {
                _logger.LogError($"BusLoop with ID {busLoopId} does not exist.");
                return NotFound();
            }

            var busRoute = busLoop.LoopBusRoute;
            if (busRoute == null)
            {
                _logger.LogError($"BusRoute for BusLoop with ID {busLoopId} does not exist.");
                return NotFound();
            }

            var busStop = _busStopService.FindBusStopByID(busStopId);
            if (busStop == null)
            {
                _logger.LogError($"BusStop with ID {busStopId} does not exist.");
                return NotFound();
            }

            _busRouteService.AddStopToRoute(busRoute, busStop);

            return RedirectToAction("ManageRoutes");
        }

        public IActionResult ViewStopsForRoute(string loopName)
        {
            var busLoop = _busLoopService.FindBusLoopByNameWithStops(loopName);

            if (busLoop == null)
            {
                return NotFound($"BusLoop with name {loopName} does not exist.");
            }

            var busStops = busLoop.LoopBusRoute.RouteStops.Select(rs => rs.BusStop);

            return View(busStops);
        }
        public async Task<IActionResult> ManageDrivers()
        {
            var users = await _userManager.GetUsersForClaimAsync(new Claim("IsDriver", "true"));
            var model = new List<ManageDriversViewModel>();

            foreach (var user in users)
            {
                var claims = await _userManager.GetClaimsAsync(user);
                var isActivated = claims.FirstOrDefault(c => c.Type == "isActivated")?.Value ?? "false";
                model.Add(new ManageDriversViewModel { UserName = user.UserName, IsActivated = isActivated });
            }

            return View(model);
        }
        public async Task<IActionResult> ChangeDriverActivationStatus(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound($"User with username {userName} does not exist.");
            }

            var existingIsActivatedClaim = (await _userManager.GetClaimsAsync(user))
                .FirstOrDefault(c => c.Type == "isActivated");

            if (existingIsActivatedClaim != null && existingIsActivatedClaim.Value == "true")
            {
                await _userManager.RemoveClaimAsync(user, existingIsActivatedClaim);
                await _userManager.AddClaimAsync(user, new Claim("isActivated", "false"));
            }
            else
            {
                await _userManager.RemoveClaimAsync(user, existingIsActivatedClaim);
                await _userManager.AddClaimAsync(user, new Claim("isActivated", "true"));
            }

            return RedirectToAction("ManageDrivers");
        }
        public IActionResult ManageEntries()
        {
            var entries = _entryService.GetEntries();

            var model = new ManageEntryViewModel
            {
                Entries = GetEntryViewModels()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DownloadEntriesCSV()
        {
            var entries = _entryService.GetEntries();
            var builder = new StringBuilder();
            builder.AppendLine("Boarded,Left Behind,Bus Stop,Timestamp,Bus Loop,Driver Name,Bus Number");

            foreach (var entry in entries)
            {
                var busStopName = _busStopService.FindBusStopByID(entry.BusStopId)?.Name;
                var busLoopName = _busLoopService.FindBusLoopByID(entry.BusLoopId)?.Name;
                builder.AppendLine($"{entry.Boarded},{entry.LeftBehind},{busStopName},{entry.Timestamp},{busLoopName},{entry.Driver},{entry.BusNumber}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Entries.csv");
        }
    }
}