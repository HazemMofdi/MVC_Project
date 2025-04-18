using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class DB_sol3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
          name: "Prefrences", // الاسم الخاطئ
          table: "Users");

            // ثم نضيف العمود بالاسم الصحيح
            migrationBuilder.AddColumn<string>(
                name: "Preferences", // الاسم الصحيح
                table: "Users",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
         name: "Preferences",
         table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Prefrences",
                table: "Users",
                nullable: true);
        }
    }
}
