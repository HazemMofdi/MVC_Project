using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace MVC_Project.Controllers
{
    public class SignUp_LoginController : Controller
    {

        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SignUp_LoginController(AppDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp", model); // return to form with validation errors
            }

            var user = new User
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password ,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                HealthAssessmentResults = model.HealthAssessmentResults,
                Preferences = model.Preferences
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model); // Return view with validation errors
        //    }

        //    var user = await _db.Users
        //        .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Invalid email or password");
        //        return View(model); // Stay on login page
        //    }

        //    HttpContext.Session.SetString("UserName", user.FullName);

        //    return RedirectToAction("Index", "Home"); // Go to Home *only if* user is valid
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if the user exists
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password); // Consider hashing the password here!

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(model);
            }

            // Create claims for the authenticated user
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.FullName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, "User")
    };

            // Create identity from claims
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Sign the user in
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Redirect user back to their original page if any, otherwise to the home page
            var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl); // Redirect to the original page the user requested before login
        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>



        public IActionResult Doc_SignUp()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Doc_SignUp(Doc_SignUpViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Check for duplicate email
            if (await _db.Therapists.AnyAsync(t => t.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(model);
            }

            string imagePath = "default-profile.png"; // Default value

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                // Clean filename (remove spaces, make lowercase)
                string cleanFileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName)
                    .Replace(" ", "-")
                    .ToLower();
                string extension = Path.GetExtension(model.ImageFile.FileName);

                // Use cleaned name only, without GUID
                string uniqueFileName = $"{cleanFileName}{extension}";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                imagePath = uniqueFileName;
            }

            var doctor = new Therapist
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
                Bio = model.Bio,
                Availability = model.Availability,
                ImagePath = imagePath // now either default or cleaned uploaded image
            };

            try
            {
                _db.Therapists.Add(doctor);
                await _db.SaveChangesAsync();
                return RedirectToAction("Doc_Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error saving data. Please try again.");
                return View(model);
            }
        }




        public IActionResult Doc_Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Doc_Login(Doc_LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Show validation errors if model is invalid
            }

            var therapist = await _db.Therapists
                .FirstOrDefaultAsync(t => t.Email == model.Email && t.Password == model.Password);

            if (therapist == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(model); // Stay on login page with error message
            }

            // Create authentication claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, therapist.FullName),
        new Claim(ClaimTypes.Email, therapist.Email),
        new Claim(ClaimTypes.Role, "Doctor") // 🔥 very important
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Sign in the doctor
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Optional: still save therapist name to session if you want
            HttpContext.Session.SetString("TherapistName", therapist.FullName);

            return RedirectToAction("Index", "Home"); // Redirect to home page
        }


        ////////////////////////////////////////////////////
        ///


      



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Save who was logged in (before signing out)
            var role = HttpContext.User?.FindFirst(ClaimTypes.Role)?.Value;

            // Sign the user out of the cookie auth scheme
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Clear session (if you're using session variables)
            HttpContext.Session.Clear();

            // Redirect based on role
            if (role == "Doctor")
            {
                return RedirectToAction("Doc_Login", "SignUp_Login");
            }
            else
            {
                return RedirectToAction("Login", "SignUp_Login");
            }
        }




    }
}
