using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fixxo_backend.Migrations
{
    public partial class updatedentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProduct_OrderProductEntityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProduct_OrderProductEntityId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderProductEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProductEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductEntityId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "TotalQuantity");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrderProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "TotalQuantity",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "OrderEntityId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductEntityId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductEntityId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderEntityId",
                table: "Products",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderProductEntityId",
                table: "Products",
                column: "OrderProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderProductEntityId",
                table: "Orders",
                column: "OrderProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderProduct_OrderProductEntityId",
                table: "Orders",
                column: "OrderProductEntityId",
                principalTable: "OrderProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProduct_OrderProductEntityId",
                table: "Products",
                column: "OrderProductEntityId",
                principalTable: "OrderProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderEntityId",
                table: "Products",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
