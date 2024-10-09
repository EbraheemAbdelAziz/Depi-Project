using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class addUserToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cf5a7a2-e906-4017-9b6c-a25b7d4ae1d8", "AQAAAAIAAYagAAAAEHj8BQNYEBjMIDY3Ntug/k1yTBZZ8NaobQPMRf+pg7MEbIp+KiSM71utnwL7HqtnNw==", "dc8e616e-e007-4bc7-b1e4-1f97be74f6c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ff9f834-1c27-4ad1-b5f2-d032beeef51b", "AQAAAAIAAYagAAAAEDANRpZSE561BiuzKNEXxfU2jTN8uLhDneohbwbT1rRShei//V60eQpFPA4sWy1yWA==", "8c278d1a-fdaa-4645-bf1f-c485dda44c96" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
