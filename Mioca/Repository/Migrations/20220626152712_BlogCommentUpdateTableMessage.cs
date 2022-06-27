using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class BlogCommentUpdateTableMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_CommentId",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_CommentId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "Mesage",
                table: "BlogComments",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "BlogComments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mesage",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "BlogComments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "BlogComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "BlogComments",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_CommentId",
                table: "BlogComments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_CommentId",
                table: "BlogComments",
                column: "CommentId",
                principalTable: "BlogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
