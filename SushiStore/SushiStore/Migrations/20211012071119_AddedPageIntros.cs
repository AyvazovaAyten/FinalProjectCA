using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class AddedPageIntros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageIntro_Pages_PageId",
                table: "PageIntro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageIntro",
                table: "PageIntro");

            migrationBuilder.RenameTable(
                name: "PageIntro",
                newName: "PageIntros");

            migrationBuilder.RenameIndex(
                name: "IX_PageIntro_PageId",
                table: "PageIntros",
                newName: "IX_PageIntros_PageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageIntros",
                table: "PageIntros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageIntros_Pages_PageId",
                table: "PageIntros",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageIntros_Pages_PageId",
                table: "PageIntros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageIntros",
                table: "PageIntros");

            migrationBuilder.RenameTable(
                name: "PageIntros",
                newName: "PageIntro");

            migrationBuilder.RenameIndex(
                name: "IX_PageIntros_PageId",
                table: "PageIntro",
                newName: "IX_PageIntro_PageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageIntro",
                table: "PageIntro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PageIntro_Pages_PageId",
                table: "PageIntro",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
