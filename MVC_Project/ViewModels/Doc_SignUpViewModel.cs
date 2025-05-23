using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class Doc_SignUpViewModel
    {
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$",
    ErrorMessage = "Needs at least 1 letter and 1 number")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Availability is required")]
        public string Availability { get; set; }

        [Required(ErrorMessage = "Profile image is required")]
        public IFormFile? ImageFile { get; set; }  // Optional image upload







    }
}
