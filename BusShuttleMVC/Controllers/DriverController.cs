using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DomainModel;
using BusShuttleMVC.Models;
using BusShuttleMVC.Services;
using BusShuttleMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace BusShuttleMVC.Controllers
{
    [Authorize(Policy = "IsDriverAndActivated")]
    public class DriverController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly IBusService _busService;
        private readonly IBusStopService _busStopService;
        private readonly IBusLoopService _busLoopService;
        private readonly IBusRouteService _busRouteService;
        public DriverController(IEntryService EntryService, IBusService busService, IBusStopService busStopService, IBusLoopService busLoopService, IBusRouteService busRouteService, ApplicationDbContext context)
        {
            _entryService = EntryService;
            _busService = busService;
            _busStopService = busStopService;
            _busLoopService = busLoopService;
            _busRouteService = busRouteService;
        }

        public IActionResult DriverDashboard()
        {
            return View();
        }
        public IActionResult CreateEntry()
        {
            var busLoops = _busLoopService.GetAllBusLoops();
            var buses = _busService.GetAllBuses();
            var model = new EntryViewModel
            {
                BusLoops = busLoops.Select(BusLoopViewModel.FromBusLoop), 
                Buses = buses.Select(BusViewModel.FromBus),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult StartRoute(string busNumber, Guid busLoopId)
        {
            TempData["BusNumber"] = busNumber;
            TempData["BusLoopId"] = busLoopId;
            return RedirectToAction("CreateEntrySecondPage");
        }
        public IActionResult CreateEntrySecondPage()
        {

            var busStops = _busStopService.GetAllBusStops();
            var model = new EntryViewModel
            {
                BusStops = busStops.Select(BusStopViewModel.FromBusStop), 
            };

            TempData.Keep("BusNumber");
            TempData.Keep("BusLoopId");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(Guid id, DateTime timeStamp, int boarded, int leftBehind, Guid busLoopId, string busNumber, Guid busStopId)
        {
            var driver = User.Identity.Name;
            var entry = await _entryService.CreateEntry(id, timeStamp, boarded, leftBehind, driver, busLoopId, busNumber, busStopId);

            var busStops = _busStopService.GetAllBusStops().ToList();
            // Find the index of the current stop
            var currentIndex = busStops.FindIndex(stop => stop.Id == busStopId);
            // Store the index of the next stop in TempData
            TempData["NextStopIndex"] = (currentIndex + 1) % busStops.Count;
            TempData.Keep("BusNumber");
            TempData.Keep("BusLoopId");

            return RedirectToAction("CreateEntrySecondPage");
        }
    }
}