using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateContactTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactSocials_Socials_SocialId",
                table: "ContactSocials");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ContactSocials_SocialId",
                table: "ContactSocials");

            migrationBuilder.DropColumn(
                name: "SocialId",
                table: "ContactSocials");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ContactSocials",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Contacts",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "Contacts",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contacts",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ContactSocials");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "SocialId",
                table: "ContactSocials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Map = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactSocials_SocialId",
                table: "ContactSocials",
                column: "SocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactSocials_Socials_SocialId",
                table: "ContactSocials",
                column: "SocialId",
                principalTable: "Socials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
