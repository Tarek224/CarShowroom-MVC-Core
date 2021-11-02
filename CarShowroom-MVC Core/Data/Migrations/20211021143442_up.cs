using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarShowroom.Data.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category_Describtion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Car_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acceleration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stored_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Car_ID);
                    table.ForeignKey(
                        name: "FK_Car_Category_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Category",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarImage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Car_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarImage_Car_Car_ID",
                        column: x => x.Car_ID,
                        principalTable: "Car",
                        principalColumn: "Car_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Car_ID = table.Column<int>(type: "int", nullable: false),
                    Comment_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Car_Car_ID",
                        column: x => x.Car_ID,
                        principalTable: "Car",
                        principalColumn: "Car_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Car_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WishList_Car_Car_ID",
                        column: x => x.Car_ID,
                        principalTable: "Car",
                        principalColumn: "Car_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_Category_ID",
                table: "Car",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CarImage_Car_ID",
                table: "CarImage",
                column: "Car_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Car_ID",
                table: "Comment",
                column: "Car_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Customer_ID",
                table: "Comment",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_Car_ID",
                table: "WishList",
                column: "Car_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImage");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
