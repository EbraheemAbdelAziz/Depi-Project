using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class editWachlistid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchlistItems_AspNetUsers_UserId1",
                table: "WatchlistItems");

            migrationBuilder.DropIndex(
                name: "IX_WatchlistItems_UserId1",
                table: "WatchlistItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WatchlistItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WatchlistItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_UserId",
                table: "WatchlistItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchlistItems_AspNetUsers_UserId",
                table: "WatchlistItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchlistItems_AspNetUsers_UserId",
                table: "WatchlistItems");

            migrationBuilder.DropIndex(
                name: "IX_WatchlistItems_UserId",
                table: "WatchlistItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WatchlistItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WatchlistItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d65e8eb1-ebe7-4b3b-81d3-3eea972f1f78", "AQAAAAIAAYagAAAAEDiUWsqfjb245bZhfJ1N3CfoPB9CkI2lk/IzJCm3sCts7PM0yC8fed10AQHz9v1y+Q==", "88f86ae5-0502-466e-ac83-bbd0cc9c2278" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "835332a1-9e85-4d80-a4b0-698378fad994", "AQAAAAIAAYagAAAAEEsWgZKxI7yXHYugdIs3f0JUsRQA4RSXUQC1QKXUL6SQQQzA5Vz6LSEnpQvf6xPvJg==", "08994a32-fb84-46ea-aabc-03f46d110221" });

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistItems_UserId1",
                table: "WatchlistItems",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchlistItems_AspNetUsers_UserId1",
                table: "WatchlistItems",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
