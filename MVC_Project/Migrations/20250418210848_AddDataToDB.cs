using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
       table: "Therapists",
       columns: new[] { "Id", "Name", "Img", "Email", "Bio", "Rating", "Availablility" },
       values: new object[,]
       {
            { 1, "Hazem Mofdi", "doctors-1.jpg", "HazemMofdi11@gmail.com", "Experienced therapist with 10+ years of practice. Specializes in anxiety and depression.", 5, "Mon-Fri, 9 AM - 5 PM" },
            { 2, "Hassan Atef", "doctors-1.jpg", "HassanAtef10@gmail.com", "Specializes in stress management and burnout. Helps clients develop coping strategies.", 5, "Tue-Thu, 10 AM - 6 PM" },
            { 3, "Rahma Tarek", "doctors-2.jpg", "RahmaTarek111@gmail.com", "Specializes in trauma-informed therapist who specializes in helping clients heal from PTSD and complex trauma", 5, "Mon-Wed, 11 AM - 7 PM" },
            { 4, "Nancy Saad", "doctors-2.jpg", "NancySaad111@gmail.com", "Specializes in workplace stress and burnout. She helps clients manage stress, improve work-life balance, and develop resilience through mindfulness and stress-reduction techniques.", 5, "Wed-Fri, 12 PM - 8 PM" },
            { 5, "Hamss Mohammed", "doctors-2.jpg", "HamssMohamed111@gmail.com", "licensed psychologist specializing in the treatment of Obsessive-Compulsive Disorder (OCD), She helps clients reduce compulsions and manage intrusive thoughts. With over 10 years of experience", 5, "Mon-Thu, 9 AM - 4 PM" }
       });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Email", "Password", "PhoneNumber", "DateOfBirth", "Gender", "HealthAssessmentResults", "Preferences" },
                values: new object[,]
                {
            { 1, "Sarah Ahmed", "SarahAhmed12@gmail.com", "123456", "01012345678", new DateTime(1999, 5, 15), "Female", "Anxiety", "Prefers video calls" },
            { 2, "Mohammed Mahmoud", "MohammedMahmoud33@gmail.com", "1234567", "01033345678", new DateTime(2003, 7, 15), "Male", "OCD", "Prefers video calls" },
            { 3, "Toqa Ali", "ToqaAli25@gmail.com", "12345678", "01044445678", new DateTime(2000, 3, 15), "Male", "MildDepression", "Prefers Chat" },
            { 4, "Yara Hassan", "Yara.Hassan@example.com", "SecurePass123", "01055556789", new DateTime(1995, 8, 22), "Female", "Anxiety", "Prefers video calls" },
            { 5, "Omar Ibrahim", "Omar.Ibrahim@example.com", "OmarPass2023", "01066667890", new DateTime(1998, 11, 5), "Male", "PanicDisorder", "Prefers text therapy" },
            { 6, "Lina Mahmoud", "Lina.Mahmoud@example.com", "Lina123!", "01077778901", new DateTime(1992, 4, 30), "Female", "PTSD", "Prefers evening sessions" },
            { 7, "Karim Adel", "Karim.Adel@example.com", "Karim@789", "01088889012", new DateTime(1997, 7, 14), "Male", "OCD", "Prefers weekly sessions" },
            { 8, "Nour Samir", "Nour.Samir@example.com", "NourPass!", "01099990123", new DateTime(2001, 1, 18), "Female", "MildDepression", "Prefers female therapists" }
                });
            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "UserID", "TherapistID", "SessionDate", "SessionTime", "SessionType", "SessionStatus", "SessionNotes" },
                values: new object[,]
                {
        { 1, 1, 1, new DateTime(2025, 4, 4), new TimeSpan(10, 0, 0), "VideoCall", "Booked", "Initial consultation for anxiety management." },
        { 2, 2, 2, new DateTime(2025, 3, 3), new TimeSpan(14, 0, 0), "Chat", "Completed", "Follow-up session for stress management." },
        { 3, 3, 3, new DateTime(2025, 6, 6), new TimeSpan(16, 0, 0), "Chat", "Booked", "Discussion on trauma recovery." },
        { 4, 1, 4, new DateTime(2025, 5, 5), new TimeSpan(11, 0, 0), "VideoCall", "Booked", "Session on workplace stress and burnout." },
        { 5, 2, 5, new DateTime(2025, 4, 30), new TimeSpan(13, 0, 0), "Chat", "Booked", "Session on OCD management." },
        { 6, 4, 1, new DateTime(2025, 4, 28), new TimeSpan(9, 0, 0), "VideoCall", "Booked", "Initial consultation for anxiety." },
        { 7, 5, 1, new DateTime(2025, 7, 4), new TimeSpan(11, 0, 0), "Chat", "Booked", "Session for panic disorder support." },
        { 8, 6, 2, new DateTime(2025, 5, 2), new TimeSpan(12, 0, 0), "VideoCall", "Booked", "Evening-preference client, PTSD therapy." },
        { 9, 7, 4, new DateTime(2025, 5, 4), new TimeSpan(14, 0, 0), "VideoCall", "Booked", "OCD-focused discussion and planning." },
        { 10, 8, 5, new DateTime(2025, 5, 3), new TimeSpan(15, 0, 0), "VideoCall", "Booked", "Session for mild depression, female therapist requested." }
                });
            migrationBuilder.InsertData(
    table: "ProgressTrackings",
    columns: new[] { "Id", "UserID", "Date", "MoodRating", "Goals", "ProgressNotes" },
    values: new object[,]
    {
        { 1, 1, new DateTime(2025, 5, 5), "Good", "Reduce anxiety by 20%", "Feeling better after the session." },
        { 2, 2, new DateTime(2025, 4, 3), "AboveAverage", "Manage stress levels", "Noted improvement in mood." },
        { 3, 3, new DateTime(2025, 7, 6), "VeryGood", "Improve communication skills", "Made progress in expressing feelings." },
        { 4, 1, new DateTime(2025, 6, 5), "Excellent", "Continue anxiety management", "Feeling more confident." },
        { 5, 2, new DateTime(2025, 4, 3), "Good", "Work on OCD management", "Making steady progress." },
        { 6, 4, new DateTime(2025, 4, 30), "AboveAverage", "Develop coping strategies for anxiety", "Reported reduced anxiety in social situations." },
        { 7, 5, new DateTime(2025, 7, 6), "Good", "Handle panic triggers more calmly", "Felt more in control during anxious moments." },
        { 8, 6, new DateTime(2025, 5, 4), "Average", "Build resilience to trauma-related stress", "Struggled slightly but remains optimistic." },
        { 9, 7, new DateTime(2025, 5, 6), "VeryGood", "Reduce compulsive behavior", "Reported fewer OCD episodes this week." },
        { 10, 8, new DateTime(2025, 5, 5), "Good", "Enhance self-esteem and positivity", "Feeling more emotionally balanced." }
    });
            migrationBuilder.InsertData(
    table: "Reviews",
    columns: new[] { "Id", "UserID", "TherapistID", "Rating", "ReviewText", "ReviewDate" },
    values: new object[,]
    {
        { 1, 1, 1, "Excellent", "Dr. Hazem Mofdi was very understanding and helpful. Highly recommend!", new DateTime(2025, 8, 15) },
        { 2, 2, 2, "Good", "Dr. Hassan Atef provided useful stress management tips. Very professional.", new DateTime(2025, 9, 15) },
        { 3, 3, 3, "Excellent", "Dr. Rahma Tarek helped me a lot with my trauma recovery. Thank you!", new DateTime(2025, 10, 15) },
        { 4, 1, 4, "Good", "Dr. Nancy Saad is very knowledgeable about workplace stress. Great session!", new DateTime(2025, 10, 16) },
        { 5, 2, 5, "Excellent", "Dr. Hamss Mohammed is amazing at OCD management. Highly recommend!", new DateTime(2025, 7, 7) },
        { 6, 4, 1, "Excellent", "Mr. Hazem really helped me understand and manage my anxiety better. He’s a great listener!", new DateTime(2025, 5, 1) },
        { 7, 5, 1, "Excellent", "Very supportive and calm atmosphere. Hazem provided solid strategies for panic disorder.", new DateTime(2025, 7, 6) },
        { 8, 6, 2, "Good", "Hassan was empathetic and offered helpful evening sessions. Could improve in follow-up.", new DateTime(2025, 5, 4) },
        { 9, 7, 4, "Excellent", "Nancy made me feel heard. Great experience with OCD management strategies!", new DateTime(2025, 5, 6) },
        { 10, 8, 5, "Excellent", "Felt very comfortable talking to Hamss. Appreciated her compassionate approach.", new DateTime(2025, 5, 6) }
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Reviews", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            migrationBuilder.DeleteData(table: "ProgressTrackings", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            migrationBuilder.DeleteData(table: "Sessions", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            migrationBuilder.DeleteData(table: "Therapists", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5 });
            migrationBuilder.DeleteData(table: "Users", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });

        }
    }
}
