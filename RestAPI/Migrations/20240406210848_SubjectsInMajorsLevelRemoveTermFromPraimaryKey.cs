using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class SubjectsInMajorsLevelRemoveTermFromPraimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__SubjectsInMajorsLevel__TermI__5165187F",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel",
                columns: new[] { "SubjectID", "MajorID", "LevelID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsInMajorsLevel_Terms_TermID",
                table: "SubjectsInMajorsLevel",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsInMajorsLevel_Terms_TermID",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel",
                columns: new[] { "SubjectID", "MajorID", "LevelID", "TermID" });

            migrationBuilder.AddForeignKey(
                name: "FK__SubjectsInMajorsLevel__TermI__5165187F",
                table: "SubjectsInMajorsLevel",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID");
        }
    }
}
