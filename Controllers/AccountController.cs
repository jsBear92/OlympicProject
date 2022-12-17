using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OlympicProject.Data;
using OlympicProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OlympicProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly OlympicContext _context;

        public AccountController(OlympicContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userEmail, string password)
        {
            bool emailExists = _context.Accounts.FirstOrDefault(x => x.UserEmail == userEmail) != null;
            bool passwordExists = _context.Accounts.FirstOrDefault(x => x.UserPassword == password) != null;
            int userType = _context.Accounts.Where(x => x.UserEmail == userEmail).Select(x => x.UserType).SingleOrDefault();

            if (!string.IsNullOrEmpty(userEmail) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity identity = null;
            bool loginAuth = false;

            if (emailExists && passwordExists)
            {
                if (userType == 0)
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, userEmail),
                    new Claim(ClaimTypes.Role, "Admin")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                }
                else
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, userEmail),
                    new Claim(ClaimTypes.Role, "Event")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                }

                loginAuth = true;
            }

            if (loginAuth)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
