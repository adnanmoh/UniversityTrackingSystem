using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class AssigmentSolutionMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "AssignmentSolutions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Assignments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_GroupID",
                table: "Assignments",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Groups_GroupID",
                table: "Assignments",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Groups_GroupID",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_GroupID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "AssignmentSolutions");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Assignments");
        }
    }
}
