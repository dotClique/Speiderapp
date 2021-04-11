using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeiderappAPI.Migrations
{
    public partial class UserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1L, "ocrispe0@jugem.jp", "Ozzie", "Crispe" },
                    { 2L, "adandye@hexun.com", "Aggi", "Dandy" },
                    { 3L, "gspottiswood2@psu.com", "Gerry", "Spottiswood" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
