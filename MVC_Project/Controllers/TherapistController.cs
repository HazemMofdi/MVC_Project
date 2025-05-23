using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class TherapistController : Controller
    {
        //AppDbContext db = new AppDbContext();

        private readonly AppDbContext _db;

        public TherapistController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult doc()
        {
            var therapistList = _db.Therapists.ToList();
            return View(therapistList);
        }
    }
}
