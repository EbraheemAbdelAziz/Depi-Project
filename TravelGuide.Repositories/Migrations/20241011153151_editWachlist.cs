using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class editWachlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "WatchlistItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchlistItems_AspNetUsers_UserId1",
                table: "WatchlistItems");

            migrationBuilder.DropIndex(
                name: "IX_WatchlistItems_UserId1",
                table: "WatchlistItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WatchlistItems");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WatchlistItems");

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
        }
    }
}
