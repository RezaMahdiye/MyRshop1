using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class delcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderDetail");
        }
    }
}
