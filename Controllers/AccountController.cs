using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pandafilm.Data;


public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("Account/SignUp")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(UserModel user)
    {
        if (ModelState.IsValid)
        {
            // Check if the email is already registered
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View(user);
            }
             var newUser = new UserModel{
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("SignIn");
        }
        return View(user);
    }
    
    [HttpGet]
    [Route("Home/SignIn")]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                // Add more claims as needed
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                // Customize properties if needed, such as setting IsPersistent to true for persistent cookies
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid email or password");
        return View();
    }

    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
        {
            // Implement Forgot Password logic (e.g., send reset password link to email)
            return RedirectToAction("SignIn");
        }
        ModelState.AddModelError("", "User not found");
        return View();
    }

    public IActionResult SignOut()
    {
        // Implement SignOut logic (e.g., clear authentication cookie)
        return RedirectToAction("Index", "Home");
    }
}