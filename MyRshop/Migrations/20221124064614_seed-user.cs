using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class seeduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Password", "RegisterDate" },
                values: new object[] { 1, "rezamediye@gmail.com", true, "Reza123456!", new DateTime(2022, 11, 24, 10, 16, 14, 621, DateTimeKind.Local).AddTicks(3516) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
