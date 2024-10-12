using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class packageImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "TravelImage",
                table: "TravelPackages");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "TravelPackages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PackageImage",
                table: "TravelPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelPackages_Locations_DestinationId",
                table: "TravelPackages",
                column: "DestinationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelPackages_Locations_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropIndex(
                name: "IX_TravelPackages_DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "PackageImage",
                table: "TravelPackages");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "TravelPackages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "TravelImage",
                table: "TravelPackages",
                type: "varbinary(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52129cf3-c73b-4e86-aa2e-47e0285153c4", "AQAAAAIAAYagAAAAEFJhxnGg1/LmneT/asuz1+z592+y41UrIQWWR9UWKn1TTd8S6K1sHE6BS0dyJyV0gw==", "166fa5a4-0390-4cd2-9772-c6076e0d0475" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2807f19b-282f-47d5-a2ed-fab746a2f6e4", "AQAAAAIAAYagAAAAEMkJLsTTdy42iRsTooxXtibQVOBRsKQrb1iEjRZqie6lSqfsIjIls7lbsn3Y/fSSMw==", "b770e2da-29b2-44f4-8dee-53cdbf1bee41" });
        }
    }
}
