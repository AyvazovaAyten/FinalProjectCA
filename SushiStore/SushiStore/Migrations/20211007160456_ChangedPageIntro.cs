using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class ChangedPageIntro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntroBackground",
                table: "PageIntro");

            migrationBuilder.AlterColumn<string>(
                name: "IntroTextBold",
                table: "PageIntro",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IntroTextBold",
                table: "PageIntro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntroBackground",
                table: "PageIntro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
