using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateLayoutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sales_CountryId",
                table: "Sales",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Countries_CountryId",
                table: "Sales",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Countries_CountryId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CountryId",
                table: "Sales");
        }
    }
}
