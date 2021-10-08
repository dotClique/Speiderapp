using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeiderappAPI.Migrations
{
    public partial class nullability_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -4L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 5, 17, 27, 33, 816, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -3L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 19, 27, 33, 816, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -1L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 19, 27, 33, 816, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -6L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 4, 27, 33, 816, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -5L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 6, 19, 27, 33, 816, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -2L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 19, 27, 33, 816, DateTimeKind.Local).AddTicks(5283));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -4L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 5, 17, 25, 42, 845, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -3L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 19, 25, 42, 845, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -1L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 19, 25, 42, 845, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -6L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 4, 25, 42, 845, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -5L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 6, 19, 25, 42, 845, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "Requirements",
                keyColumn: "RequirementID",
                keyValue: -2L,
                column: "PublishTime",
                value: new DateTime(2021, 10, 8, 19, 25, 42, 845, DateTimeKind.Local).AddTicks(5668));
        }
    }
}
