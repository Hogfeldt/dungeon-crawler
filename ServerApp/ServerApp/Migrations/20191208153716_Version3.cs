﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfoModel",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoModel", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "CharacterModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sprite = table.Column<string>(type: "varchar(50)", nullable: true),
                    Color = table.Column<string>(type: "varchar(50)", nullable: true),
                    Username = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterModel_UserInfoModel_Username",
                        column: x => x.Username,
                        principalTable: "UserInfoModel",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterModel_Username",
                table: "CharacterModel",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterModel");

            migrationBuilder.DropTable(
                name: "UserInfoModel");
        }
    }
}
