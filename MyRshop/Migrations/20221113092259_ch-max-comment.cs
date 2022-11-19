using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class chmaxcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
