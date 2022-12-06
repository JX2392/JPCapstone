using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManager.Migrations
{
    /// <inheritdoc />
    public partial class upd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedCourses",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "StringOfCourses",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StringOfCourses",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "SelectedCourses",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
