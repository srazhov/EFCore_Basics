using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Base.Migrations
{
    public partial class InitialRetry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Cart_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Seller_Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cart_Id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Comment",
                type: "int",
                nullable: true);
        }
    }
}
