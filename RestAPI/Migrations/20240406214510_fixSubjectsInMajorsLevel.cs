using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class fixSubjectsInMajorsLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel",
                columns: new[] { "SubjectID", "MajorID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel",
                columns: new[] { "SubjectID", "MajorID", "LevelID" });
        }
    }
}
