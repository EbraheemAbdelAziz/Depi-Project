using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class cascadeBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3db851ba-8bf3-4047-ab11-9f236e83f8bc", "AQAAAAIAAYagAAAAEGIDOhR1l7E4/plVMhtZ16QsNZfS+ufF8W03bK9cBCOD3KwTBdRK5y9eXPIuIe1Kzg==", "b442908c-ad13-48ef-9b94-3ee538c49c81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b465a943-ef16-4795-a63c-fcae082dd588", "AQAAAAIAAYagAAAAEEazvl5Vc8ffzz6UZQ1spfd85U40tkN0AzUir3A/Gt1ePd8R7mZEJEuCkg1cRtV2Gw==", "ce5fd667-8b65-480a-9625-b0c1e7f2395e" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingId",
                table: "Payments",
                column: "FlightBookingId",
                principalTable: "FlightBookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fb72523-d293-479a-be35-8151b94b3f12", "AQAAAAIAAYagAAAAEAs+VKadK0H+tYcTmyQuSi8lTHEvpjA0mQezw3A2HP0rkaoYzkKKGWolvPFmkwFUVQ==", "80ef0e94-9a9a-4d9f-b37a-bb7e18390a1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29590e81-c593-42c2-b6ce-ac5b8e822ae9", "AQAAAAIAAYagAAAAENLdkgAXhGZJWzk6zmre3l3RJj8QJ8TUA5lhKgCW6VDaV3iiZKMHE6Hyl0p/ygCyQw==", "0161b3a6-1a66-4eb3-a6d8-8b06f8775341" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_FlightBookings_FlightBookingId",
                table: "Payments",
                column: "FlightBookingId",
                principalTable: "FlightBookings",
                principalColumn: "BookingId");
        }
    }
}
