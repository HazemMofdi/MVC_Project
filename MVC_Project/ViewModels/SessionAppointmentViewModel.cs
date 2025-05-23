namespace MVC_Project.ViewModels
{
    public class SessionAppointmentViewModel
    {
        // User Inputs


        public DateTime Date { get; set; } // full date and time selected
        public string SessionType { get; set; }
        public int UserID { get; set; }
        public int TherapistID { get; set; }
        public string? Message { get; set; }

    }
}
