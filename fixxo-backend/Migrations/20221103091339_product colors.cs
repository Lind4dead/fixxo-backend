using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fixxo_backend.Migrations
{
    public partial class productcolors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColorEntity_Products_ProductEntityId",
                table: "ProductColorEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColorEntity",
                table: "ProductColorEntity");

            migrationBuilder.RenameTable(
                name: "ProductColorEntity",
                newName: "Colors");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColorEntity_ProductEntityId",
                table: "Colors",
                newName: "IX_Colors_ProductEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Products_ProductEntityId",
                table: "Colors",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Products_ProductEntityId",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "ProductColorEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Colors_ProductEntityId",
                table: "ProductColorEntity",
                newName: "IX_ProductColorEntity_ProductEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColorEntity",
                table: "ProductColorEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColorEntity_Products_ProductEntityId",
                table: "ProductColorEntity",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
