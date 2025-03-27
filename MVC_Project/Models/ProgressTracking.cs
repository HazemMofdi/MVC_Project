using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{
    public enum MoodRatingEnum
    {
        VeryPoor = 1,
        Poor = 2,
        BelowAverage = 3,
        Average = 4,
        AboveAverage = 5,
        Good = 6,
        VeryGood = 7,
        Excellent = 8,
        Outstanding = 9,
        Perfect = 10
    }
    public class ProgressTracking
    {
        // Question mark is used to indicate that the property nullable is true
        // while the [Required] annotation refers to Entering  the property is required
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? ProgressNotes { get; set; }
        public string? Goals { get; set; }
        [Required]
        public string MoodRating { get; set; }


        [ForeignKey("UserID"), Required]
        public User User { get; set; }
        public int UserID { get; set; }
    }
}
