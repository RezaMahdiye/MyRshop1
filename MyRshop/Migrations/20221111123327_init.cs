using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRshop.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affair",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<int>(nullable: false),
                    WorkshopName = table.Column<string>(maxLength: 30, nullable: false),
                    BossName = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    TellPhon = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affair", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hirring",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    TellPhon = table.Column<string>(maxLength: 30, nullable: false),
                    Experience = table.Column<string>(nullable: false),
                    Marital = table.Column<bool>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    SalaryPrice = table.Column<int>(nullable: false),
                    Spetial = table.Column<int>(nullable: false),
                    SoftwareName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hirring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    QuantityInStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<int>(nullable: false),
                    WorkshopName = table.Column<string>(maxLength: 50, nullable: false),
                    BossName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    TellPhon = table.Column<string>(maxLength: 50, nullable: false),
                    Birthday = table.Column<string>(maxLength: 50, nullable: false),
                    Experience = table.Column<string>(maxLength: 50, nullable: false),
                    Marital = table.Column<bool>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    SalaryPrice = table.Column<int>(nullable: false),
                    Spetial = table.Column<int>(nullable: false),
                    SoftwareName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 300, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    HoleTime = table.Column<int>(nullable: false),
                    TeacherName = table.Column<string>(maxLength: 50, nullable: false),
                    BiginEndTime = table.Column<string>(maxLength: 50, nullable: false),
                    BiginDate = table.Column<string>(maxLength: 50, nullable: false),
                    Days = table.Column<string>(maxLength: 100, nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsFinaly = table.Column<bool>(nullable: false),
                    Sum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryToProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryToProducts", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<string>(maxLength: 50, nullable: false),
                    BiginEndTime = table.Column<string>(maxLength: 50, nullable: false),
                    BiginDate = table.Column<string>(maxLength: 50, nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassProgram_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    ClassProgramId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_ClassProgram_ClassProgramId",
                        column: x => x.ClassProgramId,
                        principalTable: "ClassProgram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryToProducts_CategoryId",
                table: "CategoryToProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassProgram_ProductId",
                table: "ClassProgram",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ClassProgramId",
                table: "OrderDetail",
                column: "ClassProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affair");

            migrationBuilder.DropTable(
                name: "CategoryToProducts");

            migrationBuilder.DropTable(
                name: "Hirring");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ClassProgram");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
