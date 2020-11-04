using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Base.Migrations
{
    public partial class InitialRetry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Customer_ClientId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cart_ItemsId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_ItemsId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ClientId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ItemsId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Seller_Id",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cart_Id",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.ProductId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartId",
                table: "Order",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CustomerId",
                table: "Comment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Customer_CustomerId",
                table: "Comment",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cart_CartId",
                table: "Order",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Customer_CustomerId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cart_CartId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropIndex(
                name: "IX_Order_CartId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CustomerId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Seller_Id",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Cart_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartId",
                table: "Product",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ItemsId",
                table: "Order",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ClientId",
                table: "Comment",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Customer_ClientId",
                table: "Comment",
                column: "ClientId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cart_ItemsId",
                table: "Order",
                column: "ItemsId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
