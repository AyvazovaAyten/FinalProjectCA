using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class AddedMetaTagsPagesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                table: "Titles");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Titles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Titles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CallText",
                table: "Bios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopyRight",
                table: "Bios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterText",
                table: "Bios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteBy",
                table: "Bios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuText",
                table: "AppParts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaTags_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageIntro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroLogo = table.Column<string>(nullable: true),
                    IntroText = table.Column<string>(nullable: false),
                    IntroTextBold = table.Column<string>(nullable: false),
                    IntroBackground = table.Column<string>(nullable: false),
                    PageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageIntro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageIntro_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titles_PageId",
                table: "Titles",
                column: "PageId",
                unique: true,
                filter: "[PageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MetaTags_PageId",
                table: "MetaTags",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageIntro_PageId",
                table: "PageIntro",
                column: "PageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Pages_PageId",
                table: "Titles",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Pages_PageId",
                table: "Titles");

            migrationBuilder.DropTable(
                name: "MetaTags");

            migrationBuilder.DropTable(
                name: "PageIntro");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Titles_PageId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "CallText",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "CopyRight",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "FooterText",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "SiteBy",
                table: "Bios");

            migrationBuilder.DropColumn(
                name: "MenuText",
                table: "AppParts");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "Titles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
