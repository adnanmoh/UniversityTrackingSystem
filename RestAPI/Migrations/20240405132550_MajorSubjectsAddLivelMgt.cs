using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class MajorSubjectsAddLivelMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectInLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevels");

            migrationBuilder.RenameTable(
                name: "SubjectsInMajorsLevels",
                newName: "SubjectsInMajorsLevel");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectsInMajorsLevels_MajorID",
                table: "SubjectsInMajorsLevel",
                newName: "IX_SubjectsInMajorsLevel_MajorID");

            migrationBuilder.AddColumn<int>(
                name: "LevelID",
                table: "SubjectsInMajorsLevel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TermID",
                table: "SubjectsInMajorsLevel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel",
                columns: new[] { "SubjectID", "MajorID", "LevelID", "TermID" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsInMajorsLevel_LevelID",
                table: "SubjectsInMajorsLevel",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsInMajorsLevel_TermID",
                table: "SubjectsInMajorsLevel",
                column: "TermID");

            migrationBuilder.AddForeignKey(
                name: "FK__SubjectsInMajorsLevel__5333352A",
                table: "SubjectsInMajorsLevel",
                column: "LevelID",
                principalTable: "Levels",
                principalColumn: "LevelID");

            migrationBuilder.AddForeignKey(
                name: "FK__SubjectsInMajorsLevel__TermI__5165187F",
                table: "SubjectsInMajorsLevel",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__SubjectsInMajorsLevel__5333352A",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropForeignKey(
                name: "FK__SubjectsInMajorsLevel__TermI__5165187F",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropIndex(
                name: "IX_SubjectsInMajorsLevel_LevelID",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropIndex(
                name: "IX_SubjectsInMajorsLevel_TermID",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropColumn(
                name: "LevelID",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.DropColumn(
                name: "TermID",
                table: "SubjectsInMajorsLevel");

            migrationBuilder.RenameTable(
                name: "SubjectsInMajorsLevel",
                newName: "SubjectsInMajorsLevels");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectsInMajorsLevel_MajorID",
                table: "SubjectsInMajorsLevels",
                newName: "IX_SubjectsInMajorsLevels_MajorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SubjectsInMajorsLevel__CF3E342244FF46B1",
                table: "SubjectsInMajorsLevels",
                columns: new[] { "SubjectID", "MajorID" });

            migrationBuilder.CreateTable(
                name: "SubjectInLevel",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    LevelID = table.Column<int>(type: "int", nullable: false),
                    CollegeID = table.Column<int>(type: "int", nullable: false),
                    MajorID = table.Column<int>(type: "int", nullable: false),
                    TermID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubjectI__11E4FA5C264D528A", x => new { x.SubjectID, x.LevelID, x.CollegeID, x.MajorID, x.TermID });
                    table.ForeignKey(
                        name: "FK__SubjectIn__Colle__4F7CD00D",
                        column: x => x.CollegeID,
                        principalTable: "Colleges",
                        principalColumn: "CollegeID");
                    table.ForeignKey(
                        name: "FK__SubjectIn__Level__4E88ABD4",
                        column: x => x.LevelID,
                        principalTable: "Levels",
                        principalColumn: "LevelID");
                    table.ForeignKey(
                        name: "FK__SubjectIn__Major__5070F446",
                        column: x => x.MajorID,
                        principalTable: "Majors",
                        principalColumn: "MajorID");
                    table.ForeignKey(
                        name: "FK__SubjectIn__Subje__4D94879B",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__SubjectIn__TermI__5165187F",
                        column: x => x.TermID,
                        principalTable: "Terms",
                        principalColumn: "TermID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInLevel_CollegeID",
                table: "SubjectInLevel",
                column: "CollegeID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInLevel_LevelID",
                table: "SubjectInLevel",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInLevel_MajorID",
                table: "SubjectInLevel",
                column: "MajorID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectInLevel_TermID",
                table: "SubjectInLevel",
                column: "TermID");
        }
    }
}
