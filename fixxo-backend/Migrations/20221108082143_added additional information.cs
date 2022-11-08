using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fixxo_backend.Migrations
{
    public partial class addedadditionalinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassificationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalInformationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ClassificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInformationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalInformationEntity_ClassificationEntity_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "ClassificationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalInformationEntity_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformationEntity_ClassificationId",
                table: "AdditionalInformationEntity",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformationEntity_ProductId",
                table: "AdditionalInformationEntity",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInformationEntity");

            migrationBuilder.DropTable(
                name: "ClassificationEntity");
        }
    }
}
