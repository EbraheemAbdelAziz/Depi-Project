using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoomBookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PackageBookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FlightBookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_UserId",
                table: "RoomBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_UserId",
                table: "PackageBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_UserId",
                table: "FlightBookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightBookings_AspNetUsers_UserId",
                table: "FlightBookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageBookings_AspNetUsers_UserId",
                table: "PackageBookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_AspNetUsers_UserId",
                table: "RoomBookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightBookings_AspNetUsers_UserId",
                table: "FlightBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageBookings_AspNetUsers_UserId",
                table: "PackageBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_AspNetUsers_UserId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_UserId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_PackageBookings_UserId",
                table: "PackageBookings");

            migrationBuilder.DropIndex(
                name: "IX_FlightBookings_UserId",
                table: "FlightBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlightBookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cba202c1-e1b0-418c-95a4-20609824a395", "AQAAAAIAAYagAAAAENg9EwpOJkZ9nG1bsrOX1/Caw7Bn/zBTg1hSe5j1zKkpXlyQOlFvvSDbO6rhICnXvg==", "9a6bb30e-9882-4db4-92d6-5d1695980061" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa34a541-1b66-4cf2-af49-6e8d10969879", "AQAAAAIAAYagAAAAEPR8+ZMkvrUQAv2trRpXUH3cBx6/VBBKfnhwBk6oRv+17oLgExH6iKMkJB6oOzxNYQ==", "7d4fe9fe-cfcc-498f-958f-906a81e5f68f" });
        }
    }
}
