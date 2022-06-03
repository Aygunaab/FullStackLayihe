using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddRelationProductSpecTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecsifications_ProductId",
                table: "ProductSpecsifications",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecsifications_Products_ProductId",
                table: "ProductSpecsifications",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecsifications_Products_ProductId",
                table: "ProductSpecsifications");

            migrationBuilder.DropIndex(
                name: "IX_ProductSpecsifications_ProductId",
                table: "ProductSpecsifications");
        }
    }
}
