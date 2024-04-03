using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pandafilm.Data;
using pandafilm.Models;

namespace pandafilm.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Blog()
    {
        return View();
    }

    public IActionResult BlogDetail()
    {
        return View();
    }

    public IActionResult Service()
    {
        return View();
    }

    public IActionResult Team()
    {
        return View();
    }

    public IActionResult ContactUs()
    {
        return View();
    }

 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
