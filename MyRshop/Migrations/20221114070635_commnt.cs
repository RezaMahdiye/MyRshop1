using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class commnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Comment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
