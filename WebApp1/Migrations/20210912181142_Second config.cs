﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp1.Migrations
{
    public partial class Secondconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Test1", "Verktøy" },
                    { 2, "Test2", "Kjøretøy" },
                    { 3, "Test3", "Dagligvarer" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerId", "Address", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Test1", "Fiskars" },
                    { 2, null, "Test2", "Bosch" },
                    { 3, null, "Test3", "Myklevold" },
                    { 4, null, "Test4", "Volvo" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "CategoryId", "ManufacturerId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Manufacturer_ManufacturerId",
                table: "Product",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Manufacturer_ManufacturerId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Category",
                value: "Verktøy");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Category",
                value: "Verktøy");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "Category",
                value: " Kjøretøy");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "Category",
                value: "Kjøretøy");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "Category",
                value: "Dagligvarer");
        }
    }
}
