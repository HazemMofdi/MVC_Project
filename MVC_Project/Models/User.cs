using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{

    public enum GenderEnum
    {
        Male,
        Female
    }

    public enum HealthAssessmentResultEnum
    {
        Anxiety,
        MildDepression,
        SevereStress,
        PTSD,
        OCD,
        BipolarDisorder,
        PanicDisorder
    }
    public class User
    {
        // Question mark is used to indicate that the property nullable is true
        // while the [Required] annotation refers to Entering the property is required
        [Key]
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? HealthAssessmentResults { get; set; }
        public string? Preferences { get; set; }


        // Relations

        public ICollection<Session> Sessions { get; set; }
        public ICollection<ProgressTracking> ProgressTrackings { get; set; }
        public ICollection<Review> Review { get; set; }




    }
}
