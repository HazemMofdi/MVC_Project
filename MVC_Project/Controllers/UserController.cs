using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class UserController : Controller
    {
        AppDbContext db = new AppDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult user()
        {
            var usersList = db.Users.ToList();
            return View(usersList);
        }
    }
}
