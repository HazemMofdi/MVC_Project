using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 5,
                column: "SessionDate",
                value: new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "FName", "Gender", "HealthAssessmentResults", "LName", "Password", "PhoneNumber", "Preferences" },
                values: new object[,]
                {
                    { 4, new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yara.Hassan@example.com", "Yara", "Female", "Anxiety", "Hassan", "SecurePass123", "01055556789", "Prefers video calls" },
                    { 5, new DateTime(1998, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omar.Ibrahim@example.com", "Omar", "Male", "PanicDisorder", "Ibrahim", "OmarPass2023", "01066667890", "Prefers text therapy" },
                    { 6, new DateTime(1992, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lina.Mahmoud@example.com", "Lina", "Female", "PTSD", "Mahmoud", "Lina123!", "01077778901", "Prefers evening sessions" },
                    { 7, new DateTime(1997, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karim.Adel@example.com", "Karim", "Male", "OCD", "Adel", "Karim@789", "01088889012", "Prefers weekly sessions" },
                    { 8, new DateTime(2001, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nour.Samir@example.com", "Nour", "Female", "MildDepression", "Samir", "NourPass!", "01099990123", "Prefers female therapists" }
                });

            migrationBuilder.InsertData(
                table: "ProgressTrackings",
                columns: new[] { "Id", "Date", "Goals", "MoodRating", "ProgressNotes", "UserID" },
                values: new object[,]
                {
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
                    { 6, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Initial consultation for anxiety.", "Booked", new TimeSpan(0, 9, 0, 0, 0), "VideoCall", 1, 4 },
                    { 7, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Session for panic disorder support.", "Booked", new TimeSpan(0, 11, 0, 0, 0), "Chat", 1, 5 },
                    { 8, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evening-preference client, PTSD therapy.", "Booked", new TimeSpan(0, 12, 0, 0, 0), "VideoCall", 2, 6 },
                    { 9, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "OCD-focused discussion and planning.", "Booked", new TimeSpan(0, 14, 0, 0, 0), "VideoCall", 4, 7 },
                    { 10, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Session for mild depression, female therapist requested.", "Booked", new TimeSpan(0, 15, 0, 0, 0), "VideoCall", 5, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 5,
                column: "SessionDate",
                value: new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
