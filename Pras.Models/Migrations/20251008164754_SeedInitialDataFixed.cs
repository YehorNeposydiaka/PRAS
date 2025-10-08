using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pras.Models.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bases",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 19, 45, 30, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2025, 10, 8, 19, 45, 30, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bases",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 19, 43, 30, 757, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2025, 10, 8, 19, 43, 30, 760, DateTimeKind.Local).AddTicks(4851));
        }
    }
}
