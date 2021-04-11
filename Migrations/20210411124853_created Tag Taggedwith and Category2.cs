using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeiderappAPI.Migrations
{
    public partial class createdTagTaggedwithandCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_TaggedWiths_BadgeList_BadgeId",
                table: "TaggedWiths",
                column: "BadgeId",
                principalTable: "BadgeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaggedWiths_Tags_TagId1_TagCategoryId",
                table: "TaggedWiths",
                columns: new[] { "TagId1", "TagCategoryId" },
                principalTable: "Tags",
                principalColumns: new[] { "Id", "CategoryId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Categories_CategoryId",
                table: "Tags",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaggedWiths_BadgeList_BadgeId",
                table: "TaggedWiths");

            migrationBuilder.DropForeignKey(
                name: "FK_TaggedWiths_Tags_TagId1_TagCategoryId",
                table: "TaggedWiths");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Categories_CategoryId",
                table: "Tags");
        }
    }
}
