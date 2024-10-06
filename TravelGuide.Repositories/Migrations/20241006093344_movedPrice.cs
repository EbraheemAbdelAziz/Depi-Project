using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class movedPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "FlightBookings");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Flights");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "RoomBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "PackageBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "FlightBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a4a1fe9-8f4d-46f5-8f95-f024b23d40b2", "AQAAAAIAAYagAAAAEC6K/drohMYTgjh1moSanrG3ZEH5RZZBY8L5upHvQSZDa56F5zM7QumrkC4sm3Se7A==", "f4de762d-8d7a-46a4-b67a-0f29ea30b31a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02759d95-9567-465a-bdc7-f1a4c23c5845", "AQAAAAIAAYagAAAAEMnkmWOnogbG0M6pbzRyZ2TJQqLO2EtVRJFKTJnG7JtpucHTxtU6b68sZMq19/y+8Q==", "6053ad96-b046-44d0-92a1-cf399d5a9cdb" });
        }
    }
}
