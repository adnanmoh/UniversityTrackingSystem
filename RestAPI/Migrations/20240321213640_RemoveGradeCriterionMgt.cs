using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class RemoveGradeCriterionMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriteriaForSubjects");

            migrationBuilder.DropTable(
                name: "GradeAndCriteria");

            migrationBuilder.DropTable(
                name: "AssessmentCriteria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentCriteria",
                columns: table => new
                {
                    CriteriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxGrade = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentCriteria", x => x.CriteriaID);
                });

            migrationBuilder.CreateTable(
                name: "CriteriaForSubjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    CriteriaID = table.Column<int>(type: "int", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Criteria__CF3E342244FF46B1", x => new { x.SubjectID, x.CriteriaID, x.YearID });
                    table.ForeignKey(
                        name: "FK__CriteriaF__Crite__5535A963",
                        column: x => x.CriteriaID,
                        principalTable: "AssessmentCriteria",
                        principalColumn: "CriteriaID");
                    table.ForeignKey(
                        name: "FK__CriteriaF__Subje__5441852A",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__CriteriaF__YearI__5629CD9C",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID");
                });

            migrationBuilder.CreateTable(
                name: "GradeAndCriteria",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    CriteriaID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GradeAnd__9B1ED785078FCEA8", x => new { x.GradeID, x.CriteriaID });
                    table.ForeignKey(
                        name: "FK__GradeAndC__Crite__04E4BC85",
                        column: x => x.CriteriaID,
                        principalTable: "AssessmentCriteria",
                        principalColumn: "CriteriaID");
                    table.ForeignKey(
                        name: "FK__GradeAndC__Grade__03F0984C",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriteriaForSubjects_CriteriaID",
                table: "CriteriaForSubjects",
                column: "CriteriaID");

            migrationBuilder.CreateIndex(
                name: "IX_CriteriaForSubjects_YearID",
                table: "CriteriaForSubjects",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_GradeAndCriteria_CriteriaID",
                table: "GradeAndCriteria",
                column: "CriteriaID");
        }
    }
}
