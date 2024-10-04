using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class flightimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlightImage",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightImage",
                table: "Flights");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b356733-ddd2-4603-b1a0-25d2de6e7f12", "AQAAAAIAAYagAAAAEP/AqA7E4Q8QLNVmHJCTZT2rVdnFC3QJdeoQhyHW/XE7AOCeuGD572HOk1tvn4BTqQ==", "83ea12c1-76f8-4432-a9ca-ba5b38894bb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29198cfe-0742-475e-a0df-697f196c7ac7", "AQAAAAIAAYagAAAAEFdxNWFUPZGH7prv8eb5Bru44TGQWvS4+iQpVPUv0bPeJsS9oVdQNtMp54nnkMCfxw==", "2f29852b-428b-4983-ae22-51ec3c04473a" });
        }
    }
}
