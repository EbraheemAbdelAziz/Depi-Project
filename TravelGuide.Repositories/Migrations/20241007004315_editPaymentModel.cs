using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class editPaymentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "FlightBookingBookingId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelBookingId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageBookingId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomBookingId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PackageBookingId",
                table: "Payments",
                column: "PackageBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RoomBookingId",
                table: "Payments",
                column: "RoomBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingBookingId",
                table: "Payments",
                column: "FlightBookingBookingId",
                principalTable: "FlightBookings",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PackageBookings_PackageBookingId",
                table: "Payments",
                column: "PackageBookingId",
                principalTable: "PackageBookings",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_RoomBookings_RoomBookingId",
                table: "Payments",
                column: "RoomBookingId",
                principalTable: "RoomBookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingBookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PackageBookings_PackageBookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_RoomBookings_RoomBookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_FlightBookingBookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PackageBookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_RoomBookingId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FlightBookingBookingId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "HotelBookingId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PackageBookingId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RoomBookingId",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fa55a40-55f8-4e9f-91f2-bb5f9e0b0ee3", "AQAAAAIAAYagAAAAEBx+Tl1C/LwdgmgNJg/RDqCtRZL+HWLmK4O5AXGOgvmbxMqGgUacGIPlqFraMIbAIQ==", "c324b6b1-380e-48f3-ac55-294cfd474fdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88b9fd4f-178c-446d-ae4c-e805811dbd72", "AQAAAAIAAYagAAAAEGXcOU+n1Y1Ap31w1zr3nKMgOm6lTrpGsewrSowAJnf9vYC7aPp3GFnqNTlLApG0vA==", "532396d1-1673-4094-9a0a-13ad4684314d" });
        }
    }
}
