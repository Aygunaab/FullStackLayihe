using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddFagColumnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Question = table.Column<string>(maxLength: 250, nullable: true),
                    Answer = table.Column<string>(maxLength: 2000, nullable: true),
                    IsGeneral = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fags", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fags");
        }
    }
}
