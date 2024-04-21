using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BusShuttleMVC.Controllers
{
    public class ManagerController : Controller
    {
        [Authorize(Policy = "IsManager")]
        public IActionResult ManagerDashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBus(int busNumber)
        {
            DomainModel.Bus.AddBus(busNumber);
            return RedirectToAction("ManagerDashboard");
        }
    }
    
}