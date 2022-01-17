using Microsoft.EntityFrameworkCore.Migrations;

namespace SpeiderappAPI.Migrations
{
    public partial class rename_requirement_dicriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Requirements",
                newName: "RequirementType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequirementType",
                table: "Requirements",
                newName: "Discriminator");
        }
    }
}
