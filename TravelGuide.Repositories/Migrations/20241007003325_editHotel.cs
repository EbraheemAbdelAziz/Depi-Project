using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class editHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelImage",
                table: "Hotels",
                type: "nvarchar(max)",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelImage",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10bcff1d-2de8-44c7-b98d-2604a15788da", "AQAAAAIAAYagAAAAEAijC4bgGriwknMH9hUX/LAzgOUcqjEtrCGoFi9Qu5g4DkEjHE/52Ju6ZQAI3oddUw==", "303a6a43-ed77-4956-9a8c-155c4e72ffe9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7861443d-12d8-441f-b5c2-7c4d09421c4d", "AQAAAAIAAYagAAAAEPwcJPJUNFfBVpFNS6vB/RAWn24AQUV/5SmHUBJ5nur/DaFivRgOE+9FFjNp1jXdjw==", "d7c597d1-b671-45b9-8efd-3c19a9774a38" });
        }
    }
}
