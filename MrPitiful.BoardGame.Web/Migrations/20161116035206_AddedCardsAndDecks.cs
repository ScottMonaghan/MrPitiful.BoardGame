using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPitiful.BoardGame.Web.Migrations
{
    public partial class AddedCardsAndDecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameSetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_GameSets_GameSetId",
                        column: x => x.GameSetId,
                        principalTable: "GameSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameSetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decks_GameSets_GameSetId",
                        column: x => x.GameSetId,
                        principalTable: "GameSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardStateProperites",
                columns: table => new
                {
                    CardId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardStateProperites", x => new { x.CardId, x.Name });
                    table.ForeignKey(
                        name: "FK_CardStateProperites_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardsInDecks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CardId = table.Column<Guid>(nullable: false),
                    CardId1 = table.Column<Guid>(nullable: true),
                    DeckId = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsInDecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardsInDecks_Cards_CardId1",
                        column: x => x.CardId1,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardsInDecks_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckStateProperties",
                columns: table => new
                {
                    DeckId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DeckId1 = table.Column<Guid>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckStateProperties", x => new { x.DeckId, x.Name });
                    table.ForeignKey(
                        name: "FK_DeckStateProperties_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckStateProperties_Cards_DeckId1",
                        column: x => x.DeckId1,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_GameSetId",
                table: "Cards",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsInDecks_CardId1",
                table: "CardsInDecks",
                column: "CardId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardsInDecks_DeckId",
                table: "CardsInDecks",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_CardStateProperites_CardId",
                table: "CardStateProperites",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_GameSetId",
                table: "Decks",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckStateProperties_DeckId",
                table: "DeckStateProperties",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckStateProperties_DeckId1",
                table: "DeckStateProperties",
                column: "DeckId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardsInDecks");

            migrationBuilder.DropTable(
                name: "CardStateProperites");

            migrationBuilder.DropTable(
                name: "DeckStateProperties");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
