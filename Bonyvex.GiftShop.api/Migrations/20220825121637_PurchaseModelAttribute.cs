using Microsoft.EntityFrameworkCore.Migrations;

namespace Bonyvex.GiftShop.api.Migrations
{
    public partial class PurchaseModelAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus",
                table: "Purchases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingStatus",
                table: "Purchases");
        }
    }
}
