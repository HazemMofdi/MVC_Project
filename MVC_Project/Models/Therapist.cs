using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Therapist
    {
        // Question mark is used to indicate that the property nullable is true
        // while the [Required] annotation refers to Entering  the property is required
        [Key]
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Bio { get; set; }
        public int? Rating { get; set; }
        public string? Availability { get; set; }

        // Relations

        public ICollection<Session> Sessions { get; set; }
        public ICollection<Review> Review { get; set; }


    }
}
