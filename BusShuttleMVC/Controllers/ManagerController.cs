using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DomainModel;
using BusShuttleMVC.Models;
using BusShuttleMVC.Services;
using BusShuttleMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace BusShuttleMVC.Controllers
{
    [Authorize(Policy = "IsManager")]
    public class ManagerController : Controller
    {
        private readonly IBusService _busService;
        private readonly IBusStopService _busStopService;
        private readonly IBusLoopService _busLoopService;
        private readonly IBusRouteService _busRouteService;
        private readonly ApplicationDbContext _context;

        public ManagerController(IBusService busService, IBusStopService busStopService, IBusLoopService busLoopService, IBusRouteService busRouteService, ApplicationDbContext context)
        {
            _busService = busService;
            _busStopService = busStopService;
            _busLoopService = busLoopService;
            _busRouteService = busRouteService;
            _context = context;
        }

        public IActionResult ManagerDashboard()
        {
            return View();
        }

        public IActionResult ManageBuses()
        {
            return View(_busService.GetAllBuses().Select(t => BusViewModel.FromBus(t)));
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
            var busLoop = _context.BusLoops.Include(bl => bl.LoopBusRoute).FirstOrDefault(bl => bl.Id == busLoopId);
            if (busLoop == null)
            {
                return NotFound($"BusLoop with ID {busLoopId} does not exist.");
            }

            var busRoute = busLoop.LoopBusRoute;
            if (busRoute == null)
            {
                return NotFound($"BusRoute for BusLoop with ID {busLoopId} does not exist.");
            }

            var busStop = _context.BusStops.Find(busStopId);
            if (busStop == null)
            {
                return NotFound($"BusStop with ID {busStopId} does not exist.");
            }

            busRoute.RouteStops.Add(new RouteStop { BusStop = busStop });

            _context.SaveChanges();

            return RedirectToAction("ManageRoutes");
        }

        public IActionResult ViewStopsForRoute(string loopName)
        {
            var busLoop = _context.BusLoops.Include(bl => bl.LoopBusRoute)
                                        .ThenInclude(br => br.RouteStops)
                                        .ThenInclude(rs => rs.BusStop)
                                        .FirstOrDefault(bl => bl.Name == loopName);

            if (busLoop == null)
            {
                return NotFound($"BusLoop with name {loopName} does not exist.");
            }

            var busStops = busLoop.LoopBusRoute.RouteStops.Select(rs => rs.BusStop);

            return View(busStops);
        }
        public IActionResult ManageDrivers()
        {
            return View();
        }
        public IActionResult ManageEntries()
        {
            var entries = _context.Entries.ToList();

            var model = new ManageEntryViewModel
            {
                Entries = entries.Select(e => new EntryViewModel
                {
                    Timestamp = e.Timestamp,
                    Boarded = e.Boarded,
                    LeftBehind = e.LeftBehind,
                    Driver = e.Driver,
                    BusNumber = e.BusNumber,
                    BusLoopName = _busLoopService.FindBusLoopByID(e.BusLoopId)?.Name,
                    BusStopName = _busStopService.FindBusStopByID(e.BusStopId)?.Name
                }).ToList()
            };

            return View(model);
        }

    }
}