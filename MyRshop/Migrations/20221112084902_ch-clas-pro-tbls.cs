using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class chclasprotbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiginDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BiginEndTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HoleTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "HoleTime",
                table: "ClassProgram",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "ClassProgram",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoleTime",
                table: "ClassProgram");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "ClassProgram");

            migrationBuilder.AddColumn<string>(
                name: "BiginDate",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BiginEndTime",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HoleTime",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
