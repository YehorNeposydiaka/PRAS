using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pras.Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bases",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Status" },
                values: new object[] { 1, new DateTime(2025, 10, 8, 19, 43, 30, 757, DateTimeKind.Local).AddTicks(575), "main@pras.com", "12345", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Name", "Password" },
                values: new object[] { 1, "admin@pras.com", false, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Checks",
                columns: new[] { "Id", "BaseId", "CheckTime", "Number", "PaymentType", "TotalAmount", "UserId" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHK-001", "Cash", 0.0, 1 });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BaseId", "DocumentNumber", "InvoiceDate", "SupplierName", "TotalAmount" },
                values: new object[] { 1, 1, "INV-001", new DateTime(2025, 10, 8, 19, 43, 30, 760, DateTimeKind.Local).AddTicks(4851), "Supplier X", 0.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BaseId", "Code", "CostPrice", "Name", "Price", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, 1, 111222333, 0.0, "Product A", 0.0, 0.0, false },
                    { 2, 1, 333222, 0.0, "Product B", 0.0, 0.0, false }
                });

            migrationBuilder.InsertData(
                table: "CheckProducts",
                columns: new[] { "Id", "CheckId", "PriceAtSale", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0.0, 1, 0.0 },
                    { 2, 1, 0.0, 2, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CheckProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Checks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
