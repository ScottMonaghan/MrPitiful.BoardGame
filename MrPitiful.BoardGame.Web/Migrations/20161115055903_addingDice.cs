using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPitiful.BoardGame.Web.Migrations
{
    public partial class addingDice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameSetId = table.Column<Guid>(nullable: false),
                    Sides = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dice_GameSets_GameSetId",
                        column: x => x.GameSetId,
                        principalTable: "GameSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DieStateProperties",
                columns: table => new
                {
                    DieId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieStateProperties", x => new { x.DieId, x.Name });
                    table.ForeignKey(
                        name: "FK_DieStateProperties_Dice_DieId",
                        column: x => x.DieId,
                        principalTable: "Dice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dice_GameSetId",
                table: "Dice",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_DieStateProperties_DieId",
                table: "DieStateProperties",
                column: "DieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DieStateProperties");

            migrationBuilder.DropTable(
                name: "Dice");
        }
    }
}
