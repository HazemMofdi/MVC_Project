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
    public class SessionController : Controller
    {
        //AppDbContext db = new AppDbContext();

        private readonly AppDbContext _db;

        public SessionController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        //if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
        //{
        //    return RedirectToAction("Login", "SignUp_Login");
        //}

        [Authorize]
        public IActionResult Session()
        {
            // Get the email and role from the authentication cookie
            var email = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            var fullName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.FullName = fullName;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                // If no email or role, force re-login
                return RedirectToAction("Login", "SignUp_Login");
            }

            List<Session> sessionList = new List<Session>();

            if (role == "User")
            {
                // Query the user first
                var user = _db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    // Fetch sessions where UserId matches
                    sessionList = _db.Sessions
                                    .Where(s => s.UserID == user.Id)
                                    .ToList();
                }
            }
            else if (role == "Doctor")
            {
                // Query the therapist first
                var therapist = _db.Therapists.FirstOrDefault(t => t.Email == email);
                if (therapist != null)
                {
                    // Fetch sessions where TherapistId matches
                    sessionList = _db.Sessions
                                    .Where(s => s.TherapistID == therapist.Id)
                                    .ToList();
                }
            }
            else
            {
                // Unknown role, force logout
                return RedirectToAction("Logout", "SignUp_Login");
            }

            return View(sessionList);
        }


    }
}
