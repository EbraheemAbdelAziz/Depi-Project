using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a41eb0f-73f5-435e-bbd2-9bd7167b86b2", "AQAAAAIAAYagAAAAEHNkvfLftKlpvDkp6TxNCkCQsSEthI9wPxGSumHZKFtyEEgDV9f11SWqy5Sj3mg5GQ==", "bdd9d01f-13b0-4467-9789-2efef7bca5bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b543bfa7-0d3e-41c1-af78-fcd326d2b106", "AQAAAAIAAYagAAAAEEE6ngwaDle0xmKbvV5usJPmqaiQpB769rs6DwGQpH33O4mMkHPu7eK5Y/T2BF0Txw==", "18383aaa-e966-4d04-9462-2807d8b22234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0af71648-f201-4d07-8184-52268986c7a8", "AQAAAAIAAYagAAAAEKdkm+cXs6QkeeI9Y3NbNryJ7ZBSfJdTRBTWewIOCm7zCowkGTjLMoHGnKTfJMRXMw==", "b01a1d76-b7da-44c8-b7ba-3b15fb55adc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8752159-ffc8-494f-b938-3fbd361fe3a8", "AQAAAAIAAYagAAAAEHdgO/C5f3gYVdQYVowGGPNNaWExz76kfln6moBiqIHn8+6lGO5KvUqXMIJmJFKM+A==", "3f290877-c96c-4826-873c-2c2fcae11fb0" });
        }
    }
}
