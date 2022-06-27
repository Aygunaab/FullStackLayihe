using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateBlogSocialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogSocials_BlogSocials_BlogSocialId",
                table: "BlogSocials");

            migrationBuilder.DropIndex(
                name: "IX_BlogSocials_BlogSocialId",
                table: "BlogSocials");

            migrationBuilder.DropColumn(
                name: "BlogSocialId",
                table: "BlogSocials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogSocialId",
                table: "BlogSocials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogSocials_BlogSocialId",
                table: "BlogSocials",
                column: "BlogSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogSocials_BlogSocials_BlogSocialId",
                table: "BlogSocials",
                column: "BlogSocialId",
                principalTable: "BlogSocials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
