using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateTaxTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    PriceLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxs");
        }
    }
}
