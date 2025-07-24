using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class lectureForSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "LecturesForSubject",
                newName: "SubjectID");

            migrationBuilder.RenameColumn(
                name: "LectureId",
                table: "LecturesForSubject",
                newName: "LectureID");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectID",
                table: "LecturesForSubject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LectureID",
                table: "LecturesForSubject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Lectures__2DF84CA73B42459B",
                table: "LecturesForSubject",
                columns: new[] { "LectureID", "SubjectID" });

            migrationBuilder.CreateTable(
                name: "LectureSubject",
                columns: table => new
                {
                    LectureId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureSubject", x => new { x.LectureId, x.SubjectId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_LecturesForSubject_SubjectID",
                table: "LecturesForSubject",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Lectures__2DF84CA73B42459B",
                table: "LecturesForSubject");

            migrationBuilder.DropIndex(
                name: "IX_LecturesForSubject_SubjectID",
                table: "LecturesForSubject");

            migrationBuilder.RenameColumn(
                name: "SubjectID",
                table: "LecturesForSubject",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "LectureID",
                table: "LecturesForSubject",
                newName: "LectureId");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "LecturesForSubject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LectureId",
                table: "LecturesForSubject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
