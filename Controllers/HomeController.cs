using System.Diagnostics;
using identityStep.Data;
using Microsoft.AspNetCore.Mvc;
using pandafilm.Models;

namespace pandafilm.Controllers;

public class HomeController : Controller
{

        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var movieList = _db.movieModels.ToList();
            return View(movieList);
        }

        public IActionResult Privacy()
        {
            return View();
        }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
