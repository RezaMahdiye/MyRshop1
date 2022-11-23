using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class delseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Password", "RegisterDate" },
                values: new object[] { 1, "rezamediye@gmail.com", true, "Reza123456!", new DateTime(2022, 11, 23, 13, 56, 37, 731, DateTimeKind.Local).AddTicks(6564) });
        }
    }
}
