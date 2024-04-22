using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DomainModel;
using BusShuttleMVC.Models;
using BusShuttleMVC.Services;

namespace BusShuttleMVC.Controllers
{
    public class DriverController : Controller
    {
        [Authorize(Policy = "IsDriver")]
        public IActionResult DriverDashboard()
        {
            return View();
        }
    }
}