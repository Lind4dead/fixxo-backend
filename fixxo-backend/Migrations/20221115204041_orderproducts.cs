using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fixxo_backend.Migrations
{
    public partial class orderproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProduct_OrderProductEntityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProduct_OrderProductEntityId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderProductEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProductEntityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProductEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductEntityId",
                table: "Orders");
        }
    }
}
