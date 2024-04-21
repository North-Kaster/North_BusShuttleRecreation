using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusShuttleMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace BusShuttleMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        if (User.HasClaim("IsDriver", "true"))
        {
            return RedirectToAction("DriverDashboard", "Driver");
        }
        else if (User.HasClaim("IsManager", "true"))
        {
            return RedirectToAction("ManagerDashboard", "Manager");
        }
        else
        {
            return Redirect("/Identity/Account/Login");
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
