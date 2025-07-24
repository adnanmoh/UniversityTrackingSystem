using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class SubjectsInMajorsLevelAttachmentCourseTabelsMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments2", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK__Attachment2__Group__3A81B327",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK__Attachment2__Subje__3B75D760",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__Attachment2__Teach__398D8EEE",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                    table.ForeignKey(
                        name: "FK__Attachment2__YearI__3A81B327",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK__Course__Group__3A81B327",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "FK__Course__Subje__3B75D760",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__Course__Teach__398D8EEE",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                    table.ForeignKey(
                        name: "FK__Course__YearI__3A81B327",
                        column: x => x.YearID,
                        principalTable: "Years",
                        principalColumn: "YearID");
                });

            migrationBuilder.CreateTable(
                name: "SubjectsInMajorsLevels",
                columns: table => new
                {
                    MajorID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubjectsInMajorsLevel__CF3E342244FF46B1", x => new { x.SubjectID, x.MajorID });
                    table.ForeignKey(
                        name: "FK__SubjectsInMajorsLevel__5441852A",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FK__SubjectsInMajorsLevel__5535A963",
                        column: x => x.MajorID,
                        principalTable: "Majors",
                        principalColumn: "MajorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_GroupID",
                table: "Attachments",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_SubjectID",
                table: "Attachments",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TeacherID",
                table: "Attachments",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_YearID",
                table: "Attachments",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_GroupID",
                table: "Courses",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectID",
                table: "Courses",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherID",
                table: "Courses",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_YearID",
                table: "Courses",
                column: "YearID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsInMajorsLevels_MajorID",
                table: "SubjectsInMajorsLevels",
                column: "MajorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SubjectsInMajorsLevels");
        }
    }
}
