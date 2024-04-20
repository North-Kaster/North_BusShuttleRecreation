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
            return RedirectToAction("DriverDashboard");
        }
        else if (User.HasClaim("IsManager", "true"))
        {
            return RedirectToAction("ManagerDashboard");
        }
        else
        {
            return Redirect("/Identity/Account/Login");
        }
    }
    [Authorize(Policy = "isDriver")]
    public IActionResult DriverDashboard()
    {
        return View();
    }
    [Authorize(Policy = "IsManager")]
    public IActionResult ManagerDashboard()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
