using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AbouttablesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ourMissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<string>(maxLength: 150, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Desc = table.Column<string>(maxLength: 5000, nullable: false),
                    Videolink = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ourMissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(maxLength: 50, nullable: false),
                    AddedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    AddedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<string>(maxLength: 150, nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Profession = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhatClientSays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Desc = table.Column<string>(maxLength: 250, nullable: false),
                    ClientImage = table.Column<string>(maxLength: 150, nullable: false),
                    ClientComment = table.Column<string>(maxLength: 500, nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    companyName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatClientSays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMemberSocials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    TeamMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMemberSocials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMemberSocials_Socials_SocialId",
                        column: x => x.SocialId,
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMemberSocials_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberSocials_SocialId",
                table: "TeamMemberSocials",
                column: "SocialId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberSocials_TeamMemberId",
                table: "TeamMemberSocials",
                column: "TeamMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "ourMissions");

            migrationBuilder.DropTable(
                name: "TeamMemberSocials");

            migrationBuilder.DropTable(
                name: "WhatClientSays");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
