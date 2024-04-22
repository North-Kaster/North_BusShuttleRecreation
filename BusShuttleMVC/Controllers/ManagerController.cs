using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DomainModel;
using BusShuttleMVC.Models;
using BusShuttleMVC.Services;

namespace BusShuttleMVC.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IBusService _busService;

        public ManagerController(IBusService busService)
        {
            _busService = busService;
        }

        [Authorize(Policy = "IsManager")]
        public IActionResult ManagerDashboard()
        {
            return View();
        }

        [Authorize(Policy = "IsManager")]
        public IActionResult ManageBuses()
        {
            return View(_busService.GetAllBuses().Select(t => BusViewModel.FromBus(t)));
        }

        [HttpPost]
        [Authorize(Policy = "IsManager")]
        public IActionResult AddBus(int busNumber)
        {
            var bus = new Bus (Guid.NewGuid(), 0) { BusNumber = busNumber };
            _busService.AddBus(bus);
            return RedirectToAction("ManageBuses");
        }
    }
}