using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public enum ReviewRatingEnum
    {
        Poor = 1,
        Fair = 2,
        Average = 3,
        Good = 4,
        Excellent = 5
    }
    public class Review
    {
        // Question mark is used to indicate that the property nullable is true
        // while the [Required] annotation refers to Entering  the property is required
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required] // Rating is requried for the Review
        public string Rating { get; set; }
        [Required]
        public string? ReviewText { get; set; }

        // Foreign Keys
        [ForeignKey("UserID")]
        public User User { get; set; }
        public int UserID { get; set; }

        [ForeignKey("TherapistID")]
        public Therapist Therapist { get; set; }
        public int TherapistID { get; set; }

    }
}
