using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthAssessmentResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preferences = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgressTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgressNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoodRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressTrackings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TherapistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Therapists_TherapistID",
                        column: x => x.TherapistID,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SessionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TherapistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Therapists_TherapistID",
                        column: x => x.TherapistID,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Therapists",
                columns: new[] { "Id", "Availability", "Bio", "Email", "FullName", "ImagePath", "Password", "Rating" },
                values: new object[,]
                {
                    { 1, "Mon-Fri, 9 AM - 5 PM", "Experienced therapist with 10+ years of practice. Specializes in anxiety and depression.", "HazemMofdi11@gmail.com", "Hazem Mofdi", "doctors-1.jpg", "12345678", 5 },
                    { 2, "Tue-Thu, 10 AM - 6 PM", "Specializes in stress management and burnout. Helps clients develop coping strategies.", "HassanAtef10@gmail.com", "Hassan Atef", "doctors-1.jpg", "12345678", 5 },
                    { 3, "Mon-Wed, 11 AM - 7 PM", "Specializes in trauma-informed therapist who specializes in helping clients heal from PTSD and complex trauma", "RahmaTarek111@gmail.com", "Rahma Tarek", "doctors-2.jpg", "12345678", 5 },
                    { 4, "Wed-Fri, 12 PM - 8 PM", "Specializes in workplace stress and burnout. She helps clients manage stress, improve work-life balance, and develop resilience through mindfulness and stress-reduction techniques.", "NancySaad111@gmail.com", "Nancy Saad", "doctors-2.jpg", "12345678", 5 },
                    { 5, "Mon-Thu, 9 AM - 4 PM", "licensed psychologist specializing in the treatment of Obsessive-Compulsive Disorder (OCD), She helps clients reduce compulsions and manage intrusive thoughts. With over 10 years of experience", "HamssMohamed111@gmail.com", "Hamss Mohammed", "doctors-2.jpg", "12345678", 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Gender", "HealthAssessmentResults", "Password", "PhoneNumber", "Preferences" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SarahAhmed12@gmail.com", "Sarah Ahmed", "Female", "Anxiety", "123456", "01012345678", "Prefers video calls" },
                    { 2, new DateTime(2003, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "MohammedMahmoud33@gmail.com", "Mohammed Mahmoud", "Male", "OCD", "1234567", "01033345678", "Prefers video calls" },
                    { 3, new DateTime(2000, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ToqaAli25@gmail.com", "Toqa Ali", "Male", "MildDepression", "12345678", "01044445678", "Prefers Chat" },
                    { 4, new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yara.Hassan@example.com", "Yara Hassan", "Female", "Anxiety", "SecurePass123", "01055556789", "Prefers video calls" },
                    { 5, new DateTime(1998, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar.Ibrahim@example.com", "Omar Ibrahim", "Male", "PanicDisorder", "OmarPass2023", "01066667890", "Prefers text therapy" },
                    { 6, new DateTime(1992, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lina.Mahmoud@example.com", "Lina Mahmoud", "Female", "PTSD", "Lina123!", "01077778901", "Prefers evening sessions" },
                    { 7, new DateTime(1997, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karim.Adel@example.com", "Karim Adel", "Male", "OCD", "Karim@789", "01088889012", "Prefers weekly sessions" },
                    { 8, new DateTime(2001, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nour.Samir@example.com", "Nour Samir", "Female", "MildDepression", "NourPass!", "01099990123", "Prefers female therapists" }
                });

            migrationBuilder.InsertData(
                table: "ProgressTrackings",
                columns: new[] { "Id", "Date", "Goals", "MoodRating", "ProgressNotes", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reduce anxiety by 20%", "Good", "Feeling better after the session.", 1 },
                    { 2, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manage stress levels", "AboveAverage", "Noted improvement in mood.", 2 },
                    { 3, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Improve communication skills", "VeryGood", "Made progress in expressing feelings.", 3 },
                    { 4, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Continue anxiety management", "Excellent", "Feeling more confident.", 1 },
                    { 5, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work on OCD management", "Good", "Making steady progress.", 2 },
                    { 6, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Develop coping strategies for anxiety", "AboveAverage", "Reported reduced anxiety in social situations.", 4 },
                    { 7, new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handle panic triggers more calmly", "Good", "Felt more in control during anxious moments.", 5 },
                    { 8, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build resilience to trauma-related stress", "Average", "Struggled slightly but remains optimistic.", 6 },
                    { 9, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reduce compulsive behavior", "VeryGood", "Reported fewer OCD episodes this week.", 7 },
                    { 10, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enhance self-esteem and positivity", "Good", "Feeling more emotionally balanced.", 8 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "ReviewDate", "ReviewText", "TherapistID", "UserID" },
                values: new object[,]
                {
                    { 1, "Excellent", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Hazem Mofdi was very understanding and helpful. Highly recommend!", 1, 1 },
                    { 2, "Good", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Hassan Atef provided useful stress management tips. Very professional.", 2, 2 },
                    { 3, "Excellent", new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Rahma Tarek helped me a lot with my trauma recovery. Thank you!", 3, 3 },
                    { 4, "Good", new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Nancy Saad is very knowledgeable about workplace stress. Great session!", 4, 1 },
                    { 5, "Excellent", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Hamss Mohammed is amazing at OCD management. Highly recommend!", 5, 2 },
                    { 6, "Excellent", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Hazem really helped me understand and manage my anxiety better. He’s a great listener!", 1, 4 },
                    { 7, "Excellent", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very supportive and calm atmosphere. Hazem provided solid strategies for panic disorder.", 1, 5 },
                    { 8, "Good", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hassan was empathetic and offered helpful evening sessions. Could improve in follow-up.", 2, 6 },
                    { 9, "Excellent", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nancy made me feel heard. Great experience with OCD management strategies!", 4, 7 },
                    { 10, "Excellent", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felt very comfortable talking to Hamss. Appreciated her compassionate approach.", 5, 8 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "SessionDate", "SessionNotes", "SessionStatus", "SessionTime", "SessionType", "TherapistID", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Initial consultation for anxiety management.", "Booked", new TimeSpan(0, 10, 0, 0, 0), "VideoCall", 1, 1 },
                    { 2, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Follow-up session for stress management.", "Completed", new TimeSpan(0, 14, 0, 0, 0), "Chat", 2, 2 },
                    { 3, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discussion on trauma recovery.", "Booked", new TimeSpan(0, 16, 0, 0, 0), "Chat", 3, 3 },
                    { 4, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Session on workplace stress and burnout.", "Booked", new TimeSpan(0, 11, 0, 0, 0), "VideoCall", 4, 1 },
                    { 5, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Session on OCD management.", "Booked", new TimeSpan(0, 13, 0, 0, 0), "Chat", 5, 2 },
                    { 6, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Initial consultation for anxiety.", "Booked", new TimeSpan(0, 9, 0, 0, 0), "VideoCall", 1, 4 },
                    { 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Session for panic disorder support.", "Booked", new TimeSpan(0, 11, 0, 0, 0), "Chat", 1, 5 },
                    { 8, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evening-preference client, PTSD therapy.", "Booked", new TimeSpan(0, 12, 0, 0, 0), "VideoCall", 2, 6 },
                    { 9, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "OCD-focused discussion and planning.", "Booked", new TimeSpan(0, 14, 0, 0, 0), "VideoCall", 4, 7 },
                    { 10, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Session for mild depression, female therapist requested.", "Booked", new TimeSpan(0, 15, 0, 0, 0), "VideoCall", 5, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgressTrackings_UserID",
                table: "ProgressTrackings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TherapistID",
                table: "Reviews",
                column: "TherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TherapistID",
                table: "Sessions",
                column: "TherapistID");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserID",
                table: "Sessions",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressTrackings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
