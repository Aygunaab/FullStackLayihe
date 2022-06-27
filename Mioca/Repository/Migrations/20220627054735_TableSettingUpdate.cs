using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class TableSettingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerCoverImage",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerCoverImage",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
