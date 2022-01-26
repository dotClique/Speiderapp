using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeiderappAPI.Migrations
{
    public partial class fix_seed_datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -4L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -3L,
                column: "PublishTime",
                value: new DateTime(2021, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -1L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -6L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 7, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -5L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -2L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 7, 19, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -4L,
                column: "PublishTime",
                value: new DateTime(2021, 8, 27, 20, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -3L,
                column: "PublishTime",
                value: new DateTime(2021, 8, 30, 22, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -1L,
                column: "PublishTime",
                value: new DateTime(2021, 8, 30, 22, 27, 23, 270, DateTimeKind.Unspecified).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -6L,
                column: "PublishTime",
                value: new DateTime(2021, 8, 30, 7, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -5L,
                column: "PublishTime",
                value: new DateTime(2021, 8, 28, 22, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -2L,
                column: "PublishTime",
                value: new DateTime(2021, 8, 30, 22, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(2065));
        }
    }
}
