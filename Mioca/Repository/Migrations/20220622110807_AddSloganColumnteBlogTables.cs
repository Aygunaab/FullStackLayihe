using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddSloganColumnteBlogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextQuote",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "SloganUser",
                table: "Blogs",
                type: "ntext",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SloganUser",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "TextQuote",
                table: "Blogs",
                type: "ntext",
                nullable: false,
                defaultValue: "");
        }
    }
}
