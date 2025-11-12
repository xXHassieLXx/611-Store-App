using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApi.Migrations
{
    /// <inheritdoc />
    public partial class invoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BillingAddress", "BillingEmail", "BillingName", "CreatedAt", "Currency", "DueDate", "InvoiceNumber", "IsPaid", "IssueDate", "OrderId", "PaymentDate", "Subtotal", "Tax", "TaxId", "Total", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123, León", "juan.perez@gmail.com", "Juan Pérez", new DateTime(2025, 11, 2, 16, 37, 59, 618, DateTimeKind.Local).AddTicks(9698), "MXN", new DateTime(2025, 12, 2, 16, 37, 59, 618, DateTimeKind.Local).AddTicks(6507), "INV-1001", false, new DateTime(2025, 11, 2, 16, 37, 59, 616, DateTimeKind.Local).AddTicks(3998), 1, null, 1000.0, 160.0, "XAXX010101000", 1160.0, null },
                    { 2, "Calle Falsa 123, León", "juan.perez@gmail.com", "Juan Pérez", new DateTime(2025, 11, 7, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(316), "MXN", new DateTime(2025, 12, 7, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(310), "INV-1002", true, new DateTime(2025, 11, 7, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(307), 1, new DateTime(2025, 11, 11, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(314), 500.0, 80.0, "XAXX010101000", 580.0, new DateTime(2025, 11, 12, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(317) },
                    { 3, "Av. Central 45, León", "maria.lopez@gmail.com", "María López", new DateTime(2025, 11, 9, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(322), "MXN", new DateTime(2025, 12, 9, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(320), "INV-1003", false, new DateTime(2025, 11, 9, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(319), 2, null, 1200.0, 192.0, "XEXX010101000", 1392.0, null },
                    { 4, "Av. Central 45, León", "maria.lopez@gmail.com", "María López", new DateTime(2025, 11, 3, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(328), "MXN", new DateTime(2025, 12, 3, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(325), "INV-1004", true, new DateTime(2025, 11, 3, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(324), 2, new DateTime(2025, 11, 5, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(327), 800.0, 128.0, "XEXX010101000", 928.0, new DateTime(2025, 11, 5, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(329) },
                    { 5, "Av. Central 45, León", "maria.lopez@gmail.com", "María López", new DateTime(2025, 11, 4, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(333), "USD", new DateTime(2025, 12, 4, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(331), "INV-1005", false, new DateTime(2025, 11, 4, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(330), 2, null, 300.0, 48.0, "XEXX010101000", 348.0, null },
                    { 6, "Blvd. Campestre 500, León", "carlos.ruiz@gmail.com", "Carlos Ruiz", new DateTime(2025, 11, 5, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(339), "MXN", new DateTime(2025, 12, 5, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(336), "INV-1006", true, new DateTime(2025, 11, 5, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(335), 1, new DateTime(2025, 11, 7, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(338), 1500.0, 240.0, "XAXX010101000", 1740.0, new DateTime(2025, 11, 7, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(340) },
                    { 7, "Blvd. Campestre 500, León", "carlos.ruiz@gmail.com", "Carlos Ruiz", new DateTime(2025, 11, 6, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(345), "MXN", new DateTime(2025, 12, 6, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(342), "INV-1007", false, new DateTime(2025, 11, 6, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(341), 2, null, 2200.0, 352.0, "XAXX010101000", 2552.0, null },
                    { 8, "Calle Falsa 123, León", "juan.perez@gmail.com", "Juan Pérez", new DateTime(2025, 11, 8, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(353), "USD", new DateTime(2025, 12, 8, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(350), "INV-1008", true, new DateTime(2025, 11, 8, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(346), 1, new DateTime(2025, 11, 10, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(352), 900.0, 144.0, "XAXX010101000", 1044.0, new DateTime(2025, 11, 10, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(354) },
                    { 9, "Calle Falsa 123, León", "juan.perez@gmail.com", "Juan Pérez", new DateTime(2025, 11, 10, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(359), "MXN", new DateTime(2025, 12, 10, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(356), "INV-1009", false, new DateTime(2025, 11, 10, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(355), 1, null, 400.0, 64.0, "XAXX010101000", 464.0, null },
                    { 10, "Av. Central 45, León", "maria.lopez@gmail.com", "María López", new DateTime(2025, 11, 11, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(364), "MXN", new DateTime(2025, 12, 11, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(361), "INV-1010", true, new DateTime(2025, 11, 11, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(361), 2, new DateTime(2025, 11, 12, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(363), 1100.0, 176.0, "XEXX010101000", 1276.0, new DateTime(2025, 11, 12, 16, 37, 59, 619, DateTimeKind.Local).AddTicks(365) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
