using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class AddedRestaurantNameColToBio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "Bios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "Bios");
        }
    }
}
