using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddBlogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Image = table.Column<string>(maxLength: 250, nullable: true),
                    Text = table.Column<string>(type: "ntext", nullable: false),
                    BlogStatus = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogCategorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Message = table.Column<string>(maxLength: 2000, nullable: true),
                    BlogId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    CommentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogComments_BlogComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "BlogComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    BlogId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedBlogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagToBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagToBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagToBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagToBlogs_BlogTags_TagId",
                        column: x => x.TagId,
                        principalTable: "BlogTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_CommentId",
                table: "BlogComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_UserId",
                table: "BlogComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedBlogs_BlogId",
                table: "SavedBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedBlogs_UserId",
                table: "SavedBlogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagToBlogs_BlogId",
                table: "TagToBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_TagToBlogs_TagId",
                table: "TagToBlogs",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "SavedBlogs");

            migrationBuilder.DropTable(
                name: "TagToBlogs");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "BlogTags");

            migrationBuilder.DropTable(
                name: "BlogCategorys");
        }
    }
}
