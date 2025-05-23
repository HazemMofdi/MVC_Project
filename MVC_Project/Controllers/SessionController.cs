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
        public async Task<IActionResult> ViewSession()
        {
            var email = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            var fullName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;

            ViewBag.FullName = fullName;
            ViewBag.Role = role;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            List<Session> sessionList = new List<Session>();
            List<Session> canceledSessions = new List<Session>();

            if (role == "User")
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    sessionList = await _db.Sessions
                        .Where(s => s.UserID == user.Id && s.SessionStatus != "Canceled")
                        .ToListAsync();
                }
                else
                {
                    return RedirectToAction("Login", "SignUp_Login");
                }
            }
            else if (role == "Doctor")
            {
                var therapist = await _db.Therapists.FirstOrDefaultAsync(t => t.Email == email);
                if (therapist != null)
                {
                    sessionList = await _db.Sessions
                        .Where(s => s.TherapistID == therapist.Id && s.SessionStatus != "Canceled")
                        .ToListAsync();

                    canceledSessions = await _db.Sessions
                        .Where(s => s.TherapistID == therapist.Id && s.SessionStatus == "Canceled")
                        .ToListAsync();
                }
                else
                {
                    return RedirectToAction("Login", "SignUp_Login");
                }
            }
            else
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            // ✅ Update past sessions' status to "Completed"
            bool updated = false;
            foreach (var session in sessionList)
            {
                if (session.SessionStatus == "Booked" && session.SessionDate < DateTime.Now)
                {
                    session.SessionStatus = "Completed";
                    _db.Sessions.Update(session);
                    updated = true;
                }
            }

            if (updated)
            {
                await _db.SaveChangesAsync();
            }

            ViewBag.CanceledSessions = canceledSessions;
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

            // ❌ Check if the user already has a session with the same therapist at the same date
            bool sessionExists = await _db.Sessions.AnyAsync(s =>
                s.TherapistID == model.TherapistID &&
                s.UserID == user.Id &&
                s.SessionDate == model.Date.Date &&
                s.SessionStatus != "Canceled" // exclude canceled sessions
            );

            if (sessionExists)
            {
                return RedirectToAction("SessionConflict", "Session");
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
            await _db.SaveChangesAsync();

            TempData["Success"] = "Session booked successfully!";
            return RedirectToAction("SessionSuccess");
        }


        public IActionResult SessionConflict()
        {
            return View();
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
            _db.Sessions.Update(session);
            _db.SaveChanges();
            TempData["Success"] = "Session Is Canceled!";
            return RedirectToAction("ViewSession"); // replace with the name of your view method
        }




    }
}
