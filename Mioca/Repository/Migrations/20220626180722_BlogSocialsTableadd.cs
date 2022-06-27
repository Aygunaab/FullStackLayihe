using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class BlogSocialsTableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogSocials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialId = table.Column<int>(nullable: false),
                    BlogId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    BlogSocialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogSocials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogSocials_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogSocials_BlogSocials_BlogSocialId",
                        column: x => x.BlogSocialId,
                        principalTable: "BlogSocials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogSocials_Socials_SocialId",
                        column: x => x.SocialId,
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogSocials_BlogId",
                table: "BlogSocials",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogSocials_BlogSocialId",
                table: "BlogSocials",
                column: "BlogSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogSocials_SocialId",
                table: "BlogSocials",
                column: "SocialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogSocials");
        }
    }
}
