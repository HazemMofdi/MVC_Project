namespace MVC_Project.ViewModels
{
    public class ReviewViewModel
    {
        public DateTime Date { get; set; } // full date and time selected
        public string Rating { get; set; }
        public int UserID { get; set; }
        public int TherapistID { get; set; }
        public string? ReviewText { get; set; }
    }
}
