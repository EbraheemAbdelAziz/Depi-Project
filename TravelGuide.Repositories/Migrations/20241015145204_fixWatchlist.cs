using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class fixWatchlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "WatchlistItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WatchlistItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5078591-da55-403d-8045-7f331ad9cb32", "AQAAAAIAAYagAAAAELNuDwvOZmykJfv/lknPMIc24SftZN8nUDFgws7K3LjNd7KciASGfBg1DBxWBZMzJQ==", "a2d6dc90-c6cd-4fa4-ae91-b88d8b2e0a33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24305aae-d4b0-49cc-8100-7f90660b1b63", "AQAAAAIAAYagAAAAEMZD09WgAdgPcUq8Nr3LKJ4taOUqd+kVE3LxEott9B1cxLU0z3rIuFn/f53OZLvV9w==", "807315dc-a21d-4666-bdf2-3ad18a775d8a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "WatchlistItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WatchlistItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ab8e47e-084f-4fc3-b738-dbdd6fbe86b5", "AQAAAAIAAYagAAAAEFm7T+pXRUh5qGuIR9OZJ2AiU2XeJv/jhyw2E/ils78OwCLje0zdc/9rD4MSMJsekw==", "63d2e3b4-a105-4877-9abb-077d1c042793" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "830b16fb-8682-436e-863b-3a50baa80cb0", "AQAAAAIAAYagAAAAENAx/pFTXduy+St6vFYI1E6BW51re6dGDgjDtSMHNiTZfu+rm+7qYbJypTg0B7ydtQ==", "5b254d92-063f-48b2-881f-d0d67d9598b1" });
        }
    }
}
