using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class SignupViewModel
    {

        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public string Preferences { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select a gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Please Choose your complaint")]
        public string HealthAssessmentResults { get; set; }

        [Required]
        public bool AcceptTerms { get; set; }
    }
}
