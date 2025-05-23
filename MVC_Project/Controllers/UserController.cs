using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using Microsoft.AspNetCore.Authorization;


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

        [Authorize]
        public IActionResult User()
        {
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


            var usersList = _db.Users.ToList();
            return View(usersList);
        }
    }
}
