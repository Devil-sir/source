using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesApp.Migrations
{
    public partial class fourthConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalAmt = table.Column<double>(type: "float", nullable: false),
                    dateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productsSold",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    saleId = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productsSold", x => x.id);
                    table.ForeignKey(
                        name: "FK_productsSold_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productsSold_sale_saleId",
                        column: x => x.saleId,
                        principalTable: "sale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productsSold_productId",
                table: "productsSold",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_productsSold_saleId",
                table: "productsSold",
                column: "saleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productsSold");

            migrationBuilder.DropTable(
                name: "sale");
        }
    }
}
