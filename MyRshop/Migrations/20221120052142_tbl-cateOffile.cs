using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class tblcateOffile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CateId",
                table: "FileModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryOfFileId",
                table: "FileModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryOfFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOfFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_CategoryOfFileId",
                table: "FileModel",
                column: "CategoryOfFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_CategoryOfFiles_CategoryOfFileId",
                table: "FileModel",
                column: "CategoryOfFileId",
                principalTable: "CategoryOfFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_CategoryOfFiles_CategoryOfFileId",
                table: "FileModel");

            migrationBuilder.DropTable(
                name: "CategoryOfFiles");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_CategoryOfFileId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "CateId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "CategoryOfFileId",
                table: "FileModel");
        }
    }
}
