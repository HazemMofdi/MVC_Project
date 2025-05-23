using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using Microsoft.AspNetCore.Authorization;
using MVC_Project.Models;
using System.Security.Claims;


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
            // Get the logged-in user's email and role
            var email = HttpContext.User?.FindFirst(ClaimTypes.Email)?.Value;
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;
            var fullName = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;
            ViewBag.FullName = fullName;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(role))
            {
                // If no email or role, force re-login
                return RedirectToAction("Login", "SignUp_Login");
            }

            List<ProgressTracking> trackList = new List<ProgressTracking>();

            if (role == "User")
            {
                // Find the user by email
                var user = _db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    // Fetch progress where UserId matches
                    trackList = _db.ProgressTrackings
                                   .Where(p => p.UserID == user.Id)
                                   .ToList();
                }
            }
            else if (role == "Doctor")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Logout", "SignUp_Login");
            }

            return View(trackList);
        }

    }
}
