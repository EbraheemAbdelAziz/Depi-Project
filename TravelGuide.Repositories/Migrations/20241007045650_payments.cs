using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class payments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                type: "datetime2",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fb72523-d293-479a-be35-8151b94b3f12", "AQAAAAIAAYagAAAAEAs+VKadK0H+tYcTmyQuSi8lTHEvpjA0mQezw3A2HP0rkaoYzkKKGWolvPFmkwFUVQ==", "80ef0e94-9a9a-4d9f-b37a-bb7e18390a1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29590e81-c593-42c2-b6ce-ac5b8e822ae9", "AQAAAAIAAYagAAAAENLdkgAXhGZJWzk6zmre3l3RJj8QJ8TUA5lhKgCW6VDaV3iiZKMHE6Hyl0p/ygCyQw==", "0161b3a6-1a66-4eb3-a6d8-8b06f8775341" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 50,
                oldNullable: true);

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
    }
}
