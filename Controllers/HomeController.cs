using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pandafilm.Data;
using pandafilm.Models;

namespace pandafilm.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
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


    [HttpGet]
    [Route("Home/SignUp")]
    public IActionResult SignUp()
    {
        return View("SignUp","_Layout");
    }
    [HttpPost]
    public IActionResult SignUpDB(UserModel umodel)
    {
        if (ModelState.IsValid)
        {
            // Check if the email is already registered
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == umodel.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email address is already registered.");
                return View(umodel);
            }
            // If not, proceed with registration
            var newUser = new UserModel{
                UserName = umodel.UserName,
                Email = umodel.Email,
                Password = umodel.Password,
                ConfirmPassword = umodel.ConfirmPassword
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            // _logger.LogInformation($"User {newUser.Email} registered successfully.");
            return View("Login");
        }
        else
        {
            return View(umodel);
        }
    }
    
    [HttpGet]
    [Route("Home/SignIn")]
    public IActionResult SignIn()
    {
        return View();
    }


    [HttpPost]
    public IActionResult SignInDB(LoginModel lmodel)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == lmodel.Email && u.Password == lmodel.Password);

            if (user != null)
            {
                // Authentication successful, redirect to a dashboard or home page
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(lmodel);
            }
        }
        else
        {
            return View(lmodel);
        }
    }

    [HttpPost]
    public IActionResult Logout()
    {
        // Clear session or cookie to indicate user logout
        HttpContext.Session.Clear();
        // _logger.LogInformation($"User logged out successfully.");
        return RedirectToAction("Index", "Login"); // Redirect to the homepage after logout
    }
       
 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
