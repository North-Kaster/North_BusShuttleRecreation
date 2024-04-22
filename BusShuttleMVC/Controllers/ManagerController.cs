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

        public ManagerController(IBusService busService)
        {
            _busService = busService;
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
    
    }
}