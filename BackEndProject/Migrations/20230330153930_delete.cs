using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndProject.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "TeacherSocials");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "TeacherSocials");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "TeacherSocials");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "TeacherSocials");

            migrationBuilder.DropColumn(
                name: "Vimeo",
                table: "TeacherSocials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "TeacherSocials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "TeacherSocials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skype",
                table: "TeacherSocials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "TeacherSocials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vimeo",
                table: "TeacherSocials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
