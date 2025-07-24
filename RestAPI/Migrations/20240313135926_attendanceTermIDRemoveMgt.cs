using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class attendanceTermIDRemoveMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Attendanc__TermI__6A30C649",
                table: "Attendance");

            

            migrationBuilder.DropColumn(
                name: "TermID",
                table: "Attendance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TermID",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TermID",
                table: "Attendance",
                column: "TermID");

            migrationBuilder.AddForeignKey(
                name: "FK__Attendanc__TermI__6A30C649",
                table: "Attendance",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID");
        }
    }
}
