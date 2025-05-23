namespace MVC_Project.ViewModels
{
    public class ProgressViewModel
    {
        public DateTime Date { get; set; } // full date and time selected
        public string MoodRating { get; set; }
        public string? ProgressNotes { get; set; }
        public string? Goals { get; set; }
        public int UserID { get; set; }
    }
}
