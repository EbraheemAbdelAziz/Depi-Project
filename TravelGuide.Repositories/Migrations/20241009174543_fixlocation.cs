using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class fixlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationCity",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DestinationCountry",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78b94968-da3b-41aa-950d-145c7b68a195", "AQAAAAIAAYagAAAAEGw2T39b2g7eRExTh6962nPTS0y46mfrRvZ519vtI1bZ6azEdfiNstNCPa8N33VqKw==", "d61dbd8d-d2a1-4409-9d97-e013620ff7e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ee967c3-7975-4c95-a47f-aaf5a72dbb16", "AQAAAAIAAYagAAAAEJhS4qpPWCMidd58rtBO9N2BEwHy6XY40bJA7BbPt1dj30NRnZw84UNFaLsIaMB6uA==", "8a10c10d-1999-474c-8ff2-e4bae8780418" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_LocationId",
                table: "Flights",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Locations_LocationId",
                table: "Flights",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Locations_LocationId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_LocationId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "DestinationCity",
                table: "Flights",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationCountry",
                table: "Flights",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8f696fd-fc18-48c0-a417-57403d50d458", "AQAAAAIAAYagAAAAEHQhSbd9y2eEBNr3rHCOGKI98kfwZjEsjANtEHKxhA3g7E+Q0GJbCoNXd3leIH4wlg==", "7bad8669-b880-4463-ae94-7f6f15ea6ef7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c17596c-4e69-4579-b6fb-83fd95f5ecdb", "AQAAAAIAAYagAAAAEMD+91ZBhQcBtMu+MICO/UYAaKxCaEmhbi7ygoEsVUkwp3xUWy9OeFqeJ1y+/j/dnQ==", "ecdfc4db-700e-4192-ac7f-6ff1d4fe44cf" });
        }
    }
}
