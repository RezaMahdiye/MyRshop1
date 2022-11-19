using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class relfileuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "FileModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "FileModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_UsersUserId",
                table: "FileModel",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_Users_UsersUserId",
                table: "FileModel",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_Users_UsersUserId",
                table: "FileModel");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_UsersUserId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "FileModel");
        }
    }
}
