using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models
{

    public enum SessionStatusEnum
    {
        Booked,
        Completed,
        Canceled
    }

    public enum SessionTypeEnum
    {
        VideoCall,
        Chat
    }
    public class Session
    {
        // Question mark is used to indicate that the property nullable is true
        // while the [Required] annotation refers to Entering  the property is required
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime SessionDate { get; set; }
        [Required]
        public string SessionType { get; set; }
        [Required]
        public string SessionStatus { get; set; }
        public string? SessionNotes { get; set; }

        // Foreign Keys
        [ForeignKey("UserID"), Required]
        public User User { get; set; }
        public int UserID { get; set; }

        [ForeignKey("TherapistID"), Required]
        public Therapist Therapist { get; set; }
        public int TherapistID { get; set; }

    }
}
