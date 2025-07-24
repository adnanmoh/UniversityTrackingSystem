using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class DecmalToFloatMgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "GradeAndCriteria",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "AssignmentSolutions",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaxGrade",
                table: "Assignments",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");

            migrationBuilder.AlterColumn<double>(
                name: "MaxGrade",
                table: "AssessmentCriteria",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "GradeAndCriteria",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "AssignmentSolutions",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxGrade",
                table: "Assignments",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaxGrade",
                table: "AssessmentCriteria",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
