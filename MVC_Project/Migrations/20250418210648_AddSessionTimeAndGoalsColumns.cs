using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionTimeAndGoalsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                       name: "SessionTime",
                       table: "Sessions",
                       nullable: false,
                       defaultValue: new TimeSpan(0, 0, 0, 0, 0)); 

            migrationBuilder.AddColumn<string>(
                        name: "Goals",
                        table: "ProgressTrackings",
                        nullable: true,
                        defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                    name: "SessionTime",
                    table: "Sessions");

            migrationBuilder.DropColumn(
                    name: "Goals",
                    table: "ProgressTrackings");
        }
    }
}
