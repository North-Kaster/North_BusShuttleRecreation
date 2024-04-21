using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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