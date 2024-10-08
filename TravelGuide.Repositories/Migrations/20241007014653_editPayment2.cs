using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class editPayment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingBookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_FlightBookingBookingId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FlightBookingBookingId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "HotelBookingId",
                table: "Payments",
                newName: "FlightBookingId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0af71648-f201-4d07-8184-52268986c7a8", "AQAAAAIAAYagAAAAEKdkm+cXs6QkeeI9Y3NbNryJ7ZBSfJdTRBTWewIOCm7zCowkGTjLMoHGnKTfJMRXMw==", "b01a1d76-b7da-44c8-b7ba-3b15fb55adc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8752159-ffc8-494f-b938-3fbd361fe3a8", "AQAAAAIAAYagAAAAEHdgO/C5f3gYVdQYVowGGPNNaWExz76kfln6moBiqIHn8+6lGO5KvUqXMIJmJFKM+A==", "3f290877-c96c-4826-873c-2c2fcae11fb0" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FlightBookingId",
                table: "Payments",
                column: "FlightBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingId",
                table: "Payments",
                column: "FlightBookingId",
                principalTable: "FlightBookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_FlightBookingId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "FlightBookingId",
                table: "Payments",
                newName: "HotelBookingId");

            migrationBuilder.AddColumn<int>(
                name: "FlightBookingBookingId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93f32815-ba94-4728-93ab-3129e8cb1cb3", "AQAAAAIAAYagAAAAEKXYf4uoWhLYE0EQEMoSauR06Pw1eBa1izxD4DdtYdDmg3MmyL/xOY1FlgSSsz7bfw==", "5955b9e4-fa71-4522-808c-40d7c5a1ac16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb05a13f-34d9-4cd1-b0ec-7d14411cdd59", "AQAAAAIAAYagAAAAEFmPMgDMN7wK4u7jj5cv/Vn7Xh0fYyMDeWMHFZjTTNJZRdVuIVbIk9KDg/lVW3RpWA==", "7f131cac-84c1-462e-97c7-ac8ed31856c1" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FlightBookingBookingId",
                table: "Payments",
                column: "FlightBookingBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingBookingId",
                table: "Payments",
                column: "FlightBookingBookingId",
                principalTable: "FlightBookings",
                principalColumn: "BookingId");
        }
    }
}
