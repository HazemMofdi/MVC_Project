using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project.ViewModels;

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
        public IActionResult ViewSession()
        {
            var email = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            var fullName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;

            ViewBag.FullName = fullName;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            List<Session> sessionList = new List<Session>();

            if (role == "User")
            {
                var user = _db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    sessionList = _db.Sessions.Where(s => s.UserID == user.Id).ToList();
                }
                else
                {
                    return RedirectToAction("Login", "SignUp_Login");
                }
            }
            else if (role == "Doctor")
            {
                var therapist = _db.Therapists.FirstOrDefault(t => t.Email == email);
                if (therapist != null)
                {
                    sessionList = _db.Sessions.Where(s => s.TherapistID == therapist.Id).ToList();
                }
                else
                {
                    return RedirectToAction("Doc_Login", "SignUp_Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            // ✅ Update status for past sessions
            foreach (var session in sessionList)
            {
                if (session.SessionStatus == "Booked" && session.SessionDate.Date < DateTime.Now.Date)
                {
                    session.SessionStatus = "Completed";
                }
            }

            return View(sessionList);
        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public IActionResult session()
        {
            var therapist = _db.Therapists
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),   // therapist id
                    Text = t.FullName             // therapist name
                })
                .ToList();

            ViewBag.Therapists = therapist;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> session(SessionAppointmentViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return RedirectToAction("Login", "SignUp_Login");





            // 🌟 Find the therapist by name
            var therapist = await _db.Therapists.FirstOrDefaultAsync(t => t.Id == model.TherapistID);
            if (therapist == null)
            {
                ModelState.AddModelError("", "Selected therapist does not exist.");
                return RedirectToAction("MakeAppointment", "Home");
            }

            if (model.Date.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("", "You cannot book a session in the past.");
                return RedirectToAction("MakeAppointment", "Home");
            }

            var session = new Session
            {
                SessionDate = model.Date.Date,
                SessionType = model.SessionType,
                SessionStatus = SessionStatusEnum.Booked.ToString(),
                SessionNotes = model.Message,
                UserID = user.Id,
                TherapistID = therapist.Id
            };

            if (!ModelState.IsValid)
            {
                return RedirectToAction("MakeAppointment", "Home");
            }

            _db.Sessions.Add(session);
            _db.SaveChanges();

            TempData["Success"] = "Session booked successfully!";
            return RedirectToAction("SessionSuccess");
        }



        public IActionResult SessionSuccess()
        {
            return View();
        }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>




        [HttpPost]
        public IActionResult CancelSession(int id)
        {
            var session = _db.Sessions.FirstOrDefault(s => s.Id == id);
            session.SessionStatus = "Canceled";
            _db.Sessions.Remove(session);
            _db.SaveChanges();
            TempData["Success"] = "Session Is Canceled!";
            return RedirectToAction("ViewSession"); // replace with the name of your view method
        }




    }
}
