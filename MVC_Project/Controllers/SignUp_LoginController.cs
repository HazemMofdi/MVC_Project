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
using Microsoft.AspNetCore.Identity;


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
                ImagePath = "default.jpeg"
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


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Try to authenticate as a User
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

            // Try to authenticate as a Therapist (Doctor)
            var doctor = await _db.Therapists
                .FirstOrDefaultAsync(t => t.Email == model.Email && t.Password == model.Password);

            if (doctor != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, doctor.FullName),
            new Claim(ClaimTypes.Email, doctor.Email),
            new Claim(ClaimTypes.Role, "Doctor") // 🔥
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

            // Invalid email or password
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View(model);
        }




        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // Check if the user exists
        //    var user = await _db.Users
        //        .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password); // Consider hashing the password here!

        //    if (user == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Invalid email or password");
        //        return View(model);
        //    }

        //    // Create claims for the authenticated user
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.FullName),
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim(ClaimTypes.Role, "User")
        //    };

        //    // Create identity from claims
        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var principal = new ClaimsPrincipal(identity);

        //    // Sign the user in
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //    // Redirect user back to their original page if any, otherwise to the home page
        //    var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
        //    if (string.IsNullOrEmpty(returnUrl))
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return Redirect(returnUrl); // Redirect to the original page the user requested before login
        //}



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
            if (!ModelState.IsValid)
                return View(model);

            // Check for duplicate email
            if (await _db.Therapists.AnyAsync(t => t.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(model);
            }

            // Default image name (ensure this file exists in wwwroot/images/)
            string imagePath = "default.jpeg";

            // Only handle custom image upload if provided
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                // Clean filename (no spaces), generate unique name
                string cleanFileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName)
                                            .Replace(" ", "-")
                                            .ToLower();
                string extension = Path.GetExtension(model.ImageFile.FileName);
                string uniqueFileName = $"{Guid.NewGuid()}_{cleanFileName}{extension}";

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
                Rating = 5,
                ImagePath = imagePath // Can be either the default or the uploaded one
            };

            try
            {
                _db.Therapists.Add(doctor);
                await _db.SaveChangesAsync();
                return RedirectToAction("Login"); // Doc_login
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error saving data. Please try again.");
                return View(model);
            }
        }





        //public IActionResult Doc_Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Doc_Login(Doc_LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model); // Show validation errors if model is invalid
        //    }

        //    var therapist = await _db.Therapists
        //        .FirstOrDefaultAsync(t => t.Email == model.Email && t.Password == model.Password);

        //    if (therapist == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Invalid email or password");
        //        return View(model); // Stay on login page with error message
        //    }

        //    // Create authentication claims
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, therapist.FullName),
        //        new Claim(ClaimTypes.Email, therapist.Email),
        //        new Claim(ClaimTypes.Role, "Doctor") // 🔥 very important
        //    };

        //    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //    var principal = new ClaimsPrincipal(identity);


        //    // Sign in the doctor
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //    //// Optional: still save therapist name to session if you want
        //    //HttpContext.Session.SetString("TherapistName", therapist.FullName);

        //    return RedirectToAction("Index", "Home"); // Redirect to home page
        //}


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

            //// Clear session (if you're using session variables)
            //HttpContext.Session.Clear();

            // Redirect based on role

            return RedirectToAction("Login", "SignUp_Login");

            //if (role == "Doctor")
            //{
            //    return RedirectToAction("Doc_Login", "SignUp_Login");
            //}
            //else
            //{
            //    return RedirectToAction("Login", "SignUp_Login");
            //}
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///




        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            if (User.IsInRole("User"))
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null) return RedirectToAction("Login", "SignUp_Login");

                return View(new UserProfileViewModel
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Password = user.Password,
                    Preferences = user.Preferences,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    HealthAssessmentResults = user.HealthAssessmentResults,
                    ImagePath = user.ImagePath
                });
            }
            else if (User.IsInRole("Doctor"))
            {
                var therapist = await _db.Therapists.FirstOrDefaultAsync(d => d.Email == email);
                if (therapist == null) return RedirectToAction("Doc_Login", "SignUp_Login");

                return View(new UserProfileViewModel
                {
                    FullName = therapist.FullName,
                    Email = therapist.Email,
                    Password = therapist.Password,
                    Bio = therapist.Bio,
                    Availability = therapist.Availability,
                    ImagePath = therapist.ImagePath
                });
            }

            // If not authorized, show error message
            ViewBag.ErrorMessage = "You are not authorized to access this page.";
            return View();
        }











        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UserProfile(UserProfileViewModel model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "SignUp_Login");
            }

            if (User.IsInRole("User"))
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null) return RedirectToAction("Login", "SignUp_Login");

                ModelState.Remove("Availability");
                ModelState.Remove("Bio");

                // First handle the image upload!
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {


                    var fileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", user.ImagePath ?? "");

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    //if (!string.IsNullOrEmpty(user.ImagePath) && System.IO.File.Exists(oldPath))
                    //{
                    //    System.IO.File.Delete(oldPath);
                    //}

                    model.ImagePath = fileName;
                }
                else
                {
                    model.ImagePath = user.ImagePath; // very important to keep old image if not uploading new
                }

                // AFTER image is handled, now check model validation
                //if (!ModelState.IsValid)
                //{
                //    return View(model);
                //}

                // Now update the user
                user.FullName = model.FullName;
                user.Email = model.Email;
                user.Password = model.Password;
                user.Preferences = model.Preferences;
                user.DateOfBirth = model.DateOfBirth;
                user.Gender = model.Gender;
                user.HealthAssessmentResults = model.HealthAssessmentResults;
                user.ImagePath = model.ImagePath;

                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("UserProfile");
            }

            else if (User.IsInRole("Doctor"))
            {

                var therapist = await _db.Therapists.FirstOrDefaultAsync(d => d.Email == email);
                if (therapist == null) return RedirectToAction("Login", "SignUp_Login");



                ModelState.Remove("Preferences");
                ModelState.Remove("DateOfBirth");
                ModelState.Remove("Gender");

                //if (!ModelState.IsValid)
                //{
                //    // Return the same view with validation errors
                //    return View(model);
                //}



                // Update Therapist profile fields
                therapist.FullName = model.FullName;
                therapist.Email = model.Email;
                therapist.Password = model.Password;
                therapist.Bio = model.Bio;
                therapist.Availability = model.Availability;

                // Handle image update if there's a new file uploaded
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    // Generate a unique file name for the new image
                    var fileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images"); // Specify image folder
                    var filePath = Path.Combine(uploadsFolder, fileName); // Full path to save the image

                    // Get the old image path to delete it after uploading the new one
                    var oldPath = Path.Combine(uploadsFolder, therapist.ImagePath);

                    // Ensure the folder exists
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Save the new image file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    // Delete the old image if it exists
                    //if (System.IO.File.Exists(oldPath))
                    //{
                    //    System.IO.File.Delete(oldPath);
                    //}

                    // Update the therapist's image path with the new image name
                    therapist.ImagePath = fileName;
                }

                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("UserProfile");
            }
            else
            {
                return View(model);
            }
        }









        public IActionResult ChangePassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("VerifyEmail", "SignUp_Login");
            }

            return View(new ChangePasswordViewModel { Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // First check if it's a regular user
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user != null)
            {
                user.Password = model.NewPassword;
                _db.Update(user);
                await _db.SaveChangesAsync();

                TempData["Success"] = "Password changed successfully!";
                return RedirectToAction("Login", "SignUp_Login");
            }

            // Else check if it's a doctor
            var doctor = await _db.Therapists.FirstOrDefaultAsync(d => d.Email == model.Email);
            if (doctor != null)
            {
                doctor.Password = model.NewPassword;
                _db.Update(doctor);
                await _db.SaveChangesAsync();

                TempData["Success"] = "Password changed successfully!";
                return RedirectToAction("Doc_Login", "SignUp_Login");
            }

            ModelState.AddModelError("", "Email not found in our records!");
            return View(model);
        }






        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    // Redirect to ChangePassword with user email
                    return RedirectToAction("ChangePassword", "SignUp_Login", new { email = user.Email });
                }
                else
                {
                    var doctor = await _db.Therapists.FirstOrDefaultAsync(d => d.Email == model.Email);
                    if (doctor != null)
                    {
                        // Redirect to ChangePassword with doctor email
                        return RedirectToAction("ChangePassword", "SignUp_Login", new { email = doctor.Email });
                    }
                }

                ModelState.AddModelError("", "No account found with this email!");
            }

            return View(model);
        }






    }


}
