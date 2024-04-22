using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DomainModel;
using BusShuttleMVC.Models;
using BusShuttleMVC.Services;

namespace BusShuttleMVC.Controllers
{
    [Authorize(Policy = "IsManager")]
    public class ManagerController : Controller
    {
        private readonly IBusService _busService;
        private readonly IBusStopService _busStopService;

        public ManagerController(IBusService busService, IBusStopService busStopService)
        {
            _busService = busService;
            _busStopService = busStopService;
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
            var bus = new Bus (Guid.NewGuid(), 0) { BusNumber = busNumber };
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
        public IActionResult ManageRoutes()
        {
            return View();
        }
        public IActionResult ManageDrivers()
        {
            return View();
        }
    
    }
}