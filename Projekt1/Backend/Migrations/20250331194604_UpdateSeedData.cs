using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 2, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 2, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 4, 1, 18, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 4, 2, 20, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 1, 23, 44, 18, 753, DateTimeKind.Local).AddTicks(3769), new DateTime(2025, 4, 1, 21, 44, 18, 753, DateTimeKind.Local).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 4, 2, 23, 44, 18, 753, DateTimeKind.Local).AddTicks(4541), new DateTime(2025, 4, 2, 21, 44, 18, 753, DateTimeKind.Local).AddTicks(4533) });

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2025, 4, 1, 21, 44, 18, 749, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 2,
                column: "StartDate",
                value: new DateTime(2025, 4, 2, 21, 44, 18, 752, DateTimeKind.Local).AddTicks(9907));
        }
    }
}
