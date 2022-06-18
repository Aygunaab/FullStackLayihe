using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class IsTopBottomBannerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBottomBanner",
                table: "Banners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTopBanner",
                table: "Banners",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBottomBanner",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "IsTopBanner",
                table: "Banners");
        }
    }
}
