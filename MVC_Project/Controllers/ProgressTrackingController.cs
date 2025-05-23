using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using Microsoft.AspNetCore.Authorization;
using MVC_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.ViewModels;


namespace MVC_Project.Controllers
{
    public class ProgressTrackingController : Controller
    {

        //AppDbContext db = new AppDbContext();

        private readonly AppDbContext _db;

        public ProgressTrackingController(AppDbContext db)
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
        public IActionResult Track()
        {
            // Get user info from claims
            var email = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            var fullName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;
            
            ViewBag.FullName = fullName;
            ViewBag.Role = role;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            List<ProgressTracking> trackList = new List<ProgressTracking>();

            if (role == "User")
            {
                var user = _db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    trackList = _db.ProgressTrackings
                                   .Where(p => p.UserID == user.Id)
                                   .ToList();
                }
            }
            else if (role == "Doctor")
            {
                // Doctors can view all progress records
                trackList = _db.ProgressTrackings.ToList();
            }
            else
            {
                ViewBag.AccessDenied = true;
                return View(); // Show access denied or empty view
            }

            return View(trackList);
        }









        [HttpGet]
        public IActionResult DocFeedback()
        {
            var user = _db.Users
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),   // therapist id
                    Text = t.FullName             // therapist name
                })
                .ToList();

            ViewBag.Therapists = user;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DocFeedback(ProgressViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var therapist = await _db.Therapists.FirstOrDefaultAsync(u => u.Email == email);
            if (therapist == null) return RedirectToAction("Doc_login", "SignUp_Login");





            // 🌟 Find the therapist by name
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == model.UserID);
            if (user == null)
            {
                ModelState.AddModelError("", "Selected therapist does not exist.");
                return RedirectToAction("track", "ProgressTracking");
            }

            if (model.Date.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("", "You cannot make a review in the past.");
                return RedirectToAction("track", "ProgressTracking");
            }

            var track = new ProgressTracking
            {
                Date = model.Date.Date,
                MoodRating = model.MoodRating,
                ProgressNotes = model.ProgressNotes,
                Goals = model.Goals,
                UserID = user.Id,
            };

            if (!ModelState.IsValid)
            {
                return RedirectToAction("track", "ProgressTracking");
            }

            _db.ProgressTrackings.Add(track);
            _db.SaveChanges();

            TempData["Success"] = "Feedback was successfully sent !";
            return RedirectToAction("DocFeedbackSuccess");
        }



        public IActionResult DocFeedbackSuccess()
        {
            return View();
        }

















    }
}
