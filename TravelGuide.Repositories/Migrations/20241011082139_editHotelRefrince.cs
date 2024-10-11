using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class editHotelRefrince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36ae17ad-4c50-485e-be3f-e80ddc5e6234", "AQAAAAIAAYagAAAAEBzNSwYN+jUxB+vhI94LYt4TLk3bxHGLPESCSy3H4ZqfJK4RUFEEjVKAUhGZ7pFLmw==", "26b30d13-3f7b-4157-a76b-7740dd538b79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ce78d31-a795-4724-abf6-cfd3fc2cef53", "AQAAAAIAAYagAAAAEBx+kP9pqe63/PdamKfgPxvdo3/Qm33j0l9/Kln0a/0B7Gq00oX/JoQUsz5rlKX6Mw==", "a0d1ad96-7462-487c-83b0-69715eea65d7" });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Locations_LocationId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
