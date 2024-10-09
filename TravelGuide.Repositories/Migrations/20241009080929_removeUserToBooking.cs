using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelGuide.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class removeUserToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4a111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cf5a7a2-e906-4017-9b6c-a25b7d4ae1d8", "AQAAAAIAAYagAAAAEHj8BQNYEBjMIDY3Ntug/k1yTBZZ8NaobQPMRf+pg7MEbIp+KiSM71utnwL7HqtnNw==", "dc8e616e-e007-4bc7-b1e4-1f97be74f6c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62fe5285-fd68-4711-ae93-673787f4ac66",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ff9f834-1c27-4ad1-b5f2-d032beeef51b", "AQAAAAIAAYagAAAAEDANRpZSE561BiuzKNEXxfU2jTN8uLhDneohbwbT1rRShei//V60eQpFPA4sWy1yWA==", "8c278d1a-fdaa-4645-bf1f-c485dda44c96" });
        }
    }
}
