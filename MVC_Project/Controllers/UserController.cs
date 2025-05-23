using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace MVC_Project.Controllers
{
    public class UserController : Controller
    {
        //AppDbContext db = new AppDbContext();

        private readonly AppDbContext _db;

        public UserController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Check if the authentication cookie is present and the user is logged in
        //var isAuthenticated = HttpContext.User?.Identity?.IsAuthenticated ?? false;

        //if (!isAuthenticated)
        //{
        //    return RedirectToAction("Login", "SignUp_Login"); // Manually redirect if not authenticated
        //}

        //if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
        //{
        //    return RedirectToAction("Login", "SignUp_Login");
        //}
        [Authorize]
        public IActionResult UserList()
        {
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            ViewBag.Role = role;
            if (!User.IsInRole("Doctor"))
            {
                ViewBag.AccessDenied = true;
                return View();
            }

            var usersList = _db.Users.ToList();
            return View(usersList);
        }
    }
}
