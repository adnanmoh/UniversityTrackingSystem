using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class AddCriterionsForGradeMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Attendance",
                table: "Grades",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Exam",
                table: "Grades",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "participation",
                table: "Grades",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Exam",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "participation",
                table: "Grades");
        }
    }
}
