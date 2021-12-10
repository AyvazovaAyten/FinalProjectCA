using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class AddedDescriptionAndDurationToIntroSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IntroSliders",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "IntroSliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IntroSliders");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "IntroSliders");
        }
    }
}
