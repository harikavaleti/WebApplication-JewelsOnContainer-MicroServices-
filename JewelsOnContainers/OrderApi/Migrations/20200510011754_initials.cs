using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderApi.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders1",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BuyerId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PaymentAuthCode = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders1", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems1_Orders1_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders1",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems1_OrderId",
                table: "OrderItems1",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems1");

            migrationBuilder.DropTable(
                name: "Orders1");
        }
    }
}
