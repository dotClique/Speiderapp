using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SpeiderappAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_Tags_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    RequirementID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AuthorID = table.Column<long>(type: "bigint", nullable: false),
                    PublishTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.RequirementID);
                    table.ForeignKey(
                        name: "FK_Requirements_Users_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequirementPrerequisites",
                columns: table => new
                {
                    RequirerID = table.Column<long>(type: "bigint", nullable: false),
                    RequireeID = table.Column<long>(type: "bigint", nullable: false),
                    IsAdvisory = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementPrerequisites", x => new { x.RequirerID, x.RequireeID });
                    table.ForeignKey(
                        name: "FK_RequirementPrerequisites_Requirements_RequireeID",
                        column: x => x.RequireeID,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementPrerequisites_Requirements_RequirerID",
                        column: x => x.RequirerID,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    RequirementID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceID);
                    table.ForeignKey(
                        name: "FK_Resources_Requirements_RequirementID",
                        column: x => x.RequirementID,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaggedWiths",
                columns: table => new
                {
                    BadgeID = table.Column<long>(type: "bigint", nullable: false),
                    TagID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedWiths", x => new { x.BadgeID, x.TagID });
                    table.ForeignKey(
                        name: "FK_TaggedWiths_Requirements_BadgeID",
                        column: x => x.BadgeID,
                        principalTable: "Requirements",
                        principalColumn: "RequirementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaggedWiths_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -1L, "ocrispe0@jugem.jp", "Ozzie", "Crispe" },
                    { -2L, "adandye@hexun.com", "Aggi", "Dandy" },
                    { -3L, "gspottiswood2@psu.com", "Gerry", "Spottiswood" }
                });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "RequirementID", "AuthorID", "Description", "Discriminator", "Image", "PublishTime", "Title" },
                values: new object[,]
                {
                    { -1L, -1L, "This is a cool badge for chucking wood.", "Badge", "3aas!2d=", new DateTime(2021, 8, 30, 22, 27, 23, 270, DateTimeKind.Unspecified).AddTicks(6919), "Woodchuck" },
                    { -4L, -1L, "Hobby-baserte aktiviteter for alle aldre", "Badge", "http://placekitten.com/g/200/200", new DateTime(2021, 8, 27, 20, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(1750), "Hobby" }
                });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "RequirementID", "AuthorID", "Description", "Discriminator", "PublishTime" },
                values: new object[,]
                {
                    { -2L, -1L, "Actually chop wood", "Requirement", new DateTime(2021, 8, 30, 22, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(2065) },
                    { -5L, -1L, "Stoff-handling", "Requirement", new DateTime(2021, 8, 28, 22, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(2186) }
                });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "RequirementID", "AuthorID", "Description", "Discriminator", "Image", "PublishTime", "Title" },
                values: new object[] { -3L, -2L, "Beskrivende test-tekst", "Badge", "http://placekitten.com/g/200/300", new DateTime(2021, 8, 30, 22, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(1704), "Testing" });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "RequirementID", "AuthorID", "Description", "Discriminator", "PublishTime" },
                values: new object[] { -6L, -3L, "Sytråd-shopping", "Requirement", new DateTime(2021, 8, 30, 7, 27, 23, 271, DateTimeKind.Unspecified).AddTicks(2196) });

            migrationBuilder.InsertData(
                table: "RequirementPrerequisites",
                columns: new[] { "RequireeID", "RequirerID", "IsAdvisory" },
                values: new object[,]
                {
                    { -2L, -1L, false },
                    { -5L, -4L, true },
                    { -6L, -4L, false }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceID", "Description", "Location", "Name", "RequirementID" },
                values: new object[] { -1L, "Oversikt over aktiviteter og merker i KMSpeideren", "https://kmspeider.no/aktivitetsbanken", "Aktivitetsbanken", -1L });

            migrationBuilder.CreateIndex(
                name: "IX_RequirementPrerequisites_RequireeID",
                table: "RequirementPrerequisites",
                column: "RequireeID");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_AuthorID",
                table: "Requirements",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_RequirementID",
                table: "Resources",
                column: "RequirementID");

            migrationBuilder.CreateIndex(
                name: "IX_TaggedWiths_TagID",
                table: "TaggedWiths",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CategoryID",
                table: "Tags",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequirementPrerequisites");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "TaggedWiths");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
