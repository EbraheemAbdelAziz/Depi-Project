using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class packageImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "TravelPackages");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelImage",
                table: "TravelPackages");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "TravelPackages",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c943e3ee-80c9-484d-a043-b36fa33fe63c", "AQAAAAIAAYagAAAAEM5HhFlycL+k21fyGWVdpLKW5BHNdY50jEXVgR/odY1Ktw7m/fGkvrf63/w9thLI1A==", "3c905c04-cd63-49d2-9c6b-e6a29c2437af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f46cb6b2-bdd1-4c1f-8005-3edc58ac0458", "AQAAAAIAAYagAAAAECWsXujNLA+SsrrBnq/mduuV2zKn7IYKzMGTRUp3tvByZLqx9/GVr9a9ocp3gOCt8Q==", "9eb56a24-027a-49d1-9575-b54c11defaa3" });
        }
    }
}
