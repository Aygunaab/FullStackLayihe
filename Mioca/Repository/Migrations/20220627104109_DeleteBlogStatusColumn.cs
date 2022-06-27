using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class DeleteBlogStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogStatus",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogStatus",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
