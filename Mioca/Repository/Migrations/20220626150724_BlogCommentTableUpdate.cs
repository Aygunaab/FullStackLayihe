using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class BlogCommentTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailsImage",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "QuoteImage",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailsImage",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuoteImage",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
