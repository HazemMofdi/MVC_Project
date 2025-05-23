using System.ComponentModel.DataAnnotations;

namespace MVC_Project.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Emial")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
