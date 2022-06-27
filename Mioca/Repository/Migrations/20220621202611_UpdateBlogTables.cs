using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateBlogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Blogs",
                newName: "TextTopQuote");

            migrationBuilder.AddColumn<string>(
                name: "DetailsImage",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuoteImage",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextBottomQuote",
                table: "Blogs",
                type: "ntext",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TextQuote",
                table: "Blogs",
                type: "ntext",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsImage",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "QuoteImage",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TextBottomQuote",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TextQuote",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "TextTopQuote",
                table: "Blogs",
                newName: "Text");
        }
    }
}
