using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class addedNewColumnsToCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "CartItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                table: "CartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "CartItems");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
