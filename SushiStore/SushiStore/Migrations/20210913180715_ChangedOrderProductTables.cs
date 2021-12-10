using Microsoft.EntityFrameworkCore.Migrations;

namespace SushiStore.Migrations
{
    public partial class ChangedOrderProductTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingDetails_ShippingId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ShippingDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAdress",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAdress",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ShippingId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateTable(
                name: "ShippingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakeMyself = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingId",
                table: "Orders",
                column: "ShippingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingDetails_ShippingId",
                table: "Orders",
                column: "ShippingId",
                principalTable: "ShippingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
