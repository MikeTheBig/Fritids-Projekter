using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedForAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Auditoriums_AuditoriumId",
                table: "Shows");

            migrationBuilder.AlterColumn<int>(
                name: "AuditoriumId",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Auditoriums",
                columns: new[] { "AuditoriumId", "Name", "SeatCount" },
                values: new object[,]
                {
                    { 1, "Auditorium A", 100 },
                    { 2, "Auditorium B", 80 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "DurationInMinutes", "Title" },
                values: new object[,]
                {
                    { 1, "A mind-bending thriller about dreams within dreams.", 148, "Inception" },
                    { 2, "A hacker discovers the shocking truth about his reality.", 136, "The Matrix" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "AuditoriumId", "EndDate", "MovieId", "MovieTitle", "StartDate", "TotalSeats" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Inception", new DateTime(2025, 4, 1, 21, 44, 18, 749, DateTimeKind.Local).AddTicks(3843), 0 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "The Matrix", new DateTime(2025, 4, 2, 21, 44, 18, 752, DateTimeKind.Local).AddTicks(9907), 0 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "CustomerEmail", "CustomerName", "EndDate", "ShowId", "StartDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John Doe", new DateTime(2025, 4, 1, 23, 44, 18, 753, DateTimeKind.Local).AddTicks(3769), 1, new DateTime(2025, 4, 1, 21, 44, 18, 753, DateTimeKind.Local).AddTicks(3576), 1, 1 },
                    { 2, "janesmith@example.com", "Jane Smith", new DateTime(2025, 4, 2, 23, 44, 18, 753, DateTimeKind.Local).AddTicks(4541), 2, new DateTime(2025, 4, 2, 21, 44, 18, 753, DateTimeKind.Local).AddTicks(4533), 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Auditoriums_AuditoriumId",
                table: "Shows",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "AuditoriumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Auditoriums_AuditoriumId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auditoriums",
                keyColumn: "AuditoriumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auditoriums",
                keyColumn: "AuditoriumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "AuditoriumId",
                table: "Shows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Auditoriums_AuditoriumId",
                table: "Shows",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "AuditoriumId");
        }
    }
}
