using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Therapists",
                newName: "Img");

            migrationBuilder.RenameColumn(
                name: "FName",
                table: "Therapists",
                newName: "FullName");

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Img" },
                values: new object[] { "Hazem Mofdi", "doctors-1.jpg" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "Img" },
                values: new object[] { "Hassan Atef", "doctors-1.jpg" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FullName", "Img" },
                values: new object[] { "Rahma Tarek", "doctors-2.jpg" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FullName", "Img" },
                values: new object[] { "Nancy Saad", "doctors-2.jpg" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FullName", "Img" },
                values: new object[] { "Hamss Mohammed", "doctors-2.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Img",
                table: "Therapists",
                newName: "LName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Therapists",
                newName: "FName");

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Hazem", "Mofdi" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Hassan", "Atef" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Rahma", "Tarek" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Nancy", "Saad" });

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FName", "LName" },
                values: new object[] { "Hamss", "Mohammed" });
        }
    }
}
