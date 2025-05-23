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
    public class ReviewController : Controller
    {
        //private readonly AppDbContext db;

        private readonly AppDbContext _db;

        public ReviewController(AppDbContext db)
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
        public IActionResult Review()
        {
            // Get logged-in user's email and role
            var email = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            var fullName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.FullName = fullName;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            List<Review> reviewList = new List<Review>();

            if (role == "User")
            {
                // Find the user by email
                var user = _db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    // Fetch reviews written by the user
                    reviewList = _db.Reviews
                                    .Where(r => r.UserID == user.Id)
                                    .ToList();
                }
            }
            else if (role == "Doctor")
            {
                // Find the therapist by email
                var therapist = _db.Therapists.FirstOrDefault(t => t.Email == email);
                if (therapist != null)
                {
                    // Fetch reviews about the therapist
                    reviewList = _db.Reviews
                                    .Where(r => r.TherapistID == therapist.Id)
                                    .ToList();
                }
            }
            else
            {
                return RedirectToAction("Logout", "SignUp_Login");
            }

            return View(reviewList);
        }






        [HttpGet]
        public IActionResult MakeReview()
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
        public async Task<IActionResult> MakeReview(ReviewViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return RedirectToAction("Login", "SignUp_Login");





            // 🌟 Find the therapist by name
            var therapist = await _db.Therapists.FirstOrDefaultAsync(t => t.Id == model.TherapistID);
            if (therapist == null)
            {
                ModelState.AddModelError("", "Selected therapist does not exist.");
                return RedirectToAction("Review", "Review");
            }

            if (model.Date.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("", "You cannot make a review in the past.");
                return RedirectToAction("Review", "Review");
            }

            var review = new Review
            {
                ReviewDate = model.Date.Date,
                Rating = model.Rating,
                ReviewText = model.ReviewText,
                UserID = user.Id,
                TherapistID = therapist.Id
            };

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Review", "Review");
            }

            _db.Reviews.Add(review);
            _db.SaveChanges();

            TempData["Success"] = "Review made successfully!";
            return RedirectToAction("ReviewSuccess");
        }



        public IActionResult ReviewSuccess()
        {
            return View();
        }



    }
}
