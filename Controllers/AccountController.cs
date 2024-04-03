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

     public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(User user)
    {
        if (ModelState.IsValid)
        {
            // Check if the email is already registered
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View(user);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("SignIn");
        }
        return View(user);
    }

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
            // Implement SignIn logic (e.g., set authentication cookie)
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