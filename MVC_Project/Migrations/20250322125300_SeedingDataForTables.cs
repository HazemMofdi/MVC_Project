using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HealthAssessmentResults",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MoodRating",
                table: "ProgressTrackings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MoodRating",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "MoodRating",
                value: "AboveAverage");

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "MoodRating",
                value: "VeryGood");

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "MoodRating",
                value: "Excellent");

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "MoodRating",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: "Excellent");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: "Excellent");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: "Excellent");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "HealthAssessmentResults" },
                values: new object[] { "Female", "Anxiety" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gender", "HealthAssessmentResults" },
                values: new object[] { "Male", "OCD" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Gender", "HealthAssessmentResults" },
                values: new object[] { "Male", "MildDepression" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HealthAssessmentResults",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MoodRating",
                table: "ProgressTrackings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MoodRating",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "MoodRating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "MoodRating",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "MoodRating",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ProgressTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "MoodRating",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "HealthAssessmentResults" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Gender", "HealthAssessmentResults" },
                values: new object[] { 0, 4 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Gender", "HealthAssessmentResults" },
                values: new object[] { 0, 1 });
        }
    }
}
