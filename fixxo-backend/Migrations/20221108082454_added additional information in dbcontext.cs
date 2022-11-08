using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fixxo_backend.Migrations
{
    public partial class addedadditionalinformationindbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInformationEntity_ClassificationEntity_ClassificationId",
                table: "AdditionalInformationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInformationEntity_Products_ProductId",
                table: "AdditionalInformationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categoríes_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassificationEntity",
                table: "ClassificationEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoríes",
                table: "Categoríes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalInformationEntity",
                table: "AdditionalInformationEntity");

            migrationBuilder.RenameTable(
                name: "ClassificationEntity",
                newName: "Classifications");

            migrationBuilder.RenameTable(
                name: "Categoríes",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "AdditionalInformationEntity",
                newName: "AdditionalInformations");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalInformationEntity_ProductId",
                table: "AdditionalInformations",
                newName: "IX_AdditionalInformations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalInformationEntity_ClassificationId",
                table: "AdditionalInformations",
                newName: "IX_AdditionalInformations_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalInformations",
                table: "AdditionalInformations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInformations_Classifications_ClassificationId",
                table: "AdditionalInformations",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInformations_Products_ProductId",
                table: "AdditionalInformations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInformations_Classifications_ClassificationId",
                table: "AdditionalInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInformations_Products_ProductId",
                table: "AdditionalInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdditionalInformations",
                table: "AdditionalInformations");

            migrationBuilder.RenameTable(
                name: "Classifications",
                newName: "ClassificationEntity");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categoríes");

            migrationBuilder.RenameTable(
                name: "AdditionalInformations",
                newName: "AdditionalInformationEntity");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalInformations_ProductId",
                table: "AdditionalInformationEntity",
                newName: "IX_AdditionalInformationEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AdditionalInformations_ClassificationId",
                table: "AdditionalInformationEntity",
                newName: "IX_AdditionalInformationEntity_ClassificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassificationEntity",
                table: "ClassificationEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoríes",
                table: "Categoríes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdditionalInformationEntity",
                table: "AdditionalInformationEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInformationEntity_ClassificationEntity_ClassificationId",
                table: "AdditionalInformationEntity",
                column: "ClassificationId",
                principalTable: "ClassificationEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInformationEntity_Products_ProductId",
                table: "AdditionalInformationEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categoríes_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categoríes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
