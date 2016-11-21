using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPitiful.BoardGame.Web.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSets_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameStateProperties",
                columns: table => new
                {
                    GameId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStateProperties", x => new { x.GameId, x.Name });
                    table.ForeignKey(
                        name: "FK_GameStateProperties_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "GameBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameSetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameBoards_GameSets_GameSetId",
                        column: x => x.GameSetId,
                        principalTable: "GameSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSetStateProperties",
                columns: table => new
                {
                    GameSetId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSetStateProperties", x => new { x.GameSetId, x.Name });
                    table.ForeignKey(
                        name: "FK_GameSetStateProperties_GameSets_GameSetId",
                        column: x => x.GameSetId,
                        principalTable: "GameSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStateProperties",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStateProperties", x => new { x.PlayerId, x.Name });
                    table.ForeignKey(
                        name: "FK_PlayerStateProperties_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardStateProperties",
                columns: table => new
                {
                    CardId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardStateProperties", x => new { x.CardId, x.Name });
                    table.ForeignKey(
                        name: "FK_CardStateProperties_Cards_CardId",
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
                    CardId = table.Column<Guid>(nullable: true),
                    DeckId = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsInDecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardsInDecks_Cards_CardId",
                        column: x => x.CardId,
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

            migrationBuilder.CreateTable(
                name: "GameBoardSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameBoardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoardSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameBoardSpaces_GameBoards_GameBoardId",
                        column: x => x.GameBoardId,
                        principalTable: "GameBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameBoardStateProperties",
                columns: table => new
                {
                    GameBoardId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoardStateProperties", x => new { x.GameBoardId, x.Name });
                    table.ForeignKey(
                        name: "FK_GameBoardStateProperties_GameBoards_GameBoardId",
                        column: x => x.GameBoardId,
                        principalTable: "GameBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameBoardSpaceStateProperties",
                columns: table => new
                {
                    GameBoardSpaceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoardSpaceStateProperties", x => new { x.GameBoardSpaceId, x.Name });
                    table.ForeignKey(
                        name: "FK_GameBoardSpaceStateProperties_GameBoardSpaces_GameBoardSpaceId",
                        column: x => x.GameBoardSpaceId,
                        principalTable: "GameBoardSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePieces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameBoardSpaceId = table.Column<Guid>(nullable: true),
                    GameSetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePieces_GameBoardSpaces_GameBoardSpaceId",
                        column: x => x.GameBoardSpaceId,
                        principalTable: "GameBoardSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePieces_GameSets_GameSetId",
                        column: x => x.GameSetId,
                        principalTable: "GameSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpaceConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameBoardSpaceId = table.Column<Guid>(nullable: false),
                    RemoteSpaceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceConnections_GameBoardSpaces_GameBoardSpaceId",
                        column: x => x.GameBoardSpaceId,
                        principalTable: "GameBoardSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpaceConnections_GameBoardSpaces_RemoteSpaceId",
                        column: x => x.RemoteSpaceId,
                        principalTable: "GameBoardSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePieceStateProperties",
                columns: table => new
                {
                    GamePieceId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePieceStateProperties", x => new { x.GamePieceId, x.Name });
                    table.ForeignKey(
                        name: "FK_GamePieceStateProperties_GamePieces_GamePieceId",
                        column: x => x.GamePieceId,
                        principalTable: "GamePieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpaceConnectionStateProperties",
                columns: table => new
                {
                    SpaceConnectionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceConnectionStateProperties", x => new { x.SpaceConnectionId, x.Name });
                    table.ForeignKey(
                        name: "FK_SpaceConnectionStateProperties_SpaceConnections_SpaceConnectionId",
                        column: x => x.SpaceConnectionId,
                        principalTable: "SpaceConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_GameSetId",
                table: "Cards",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_CardsInDecks_CardId",
                table: "CardsInDecks",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CardsInDecks_DeckId",
                table: "CardsInDecks",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_CardStateProperties_CardId",
                table: "CardStateProperties",
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
                name: "IX_Dice_GameSetId",
                table: "Dice",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_DieStateProperties_DieId",
                table: "DieStateProperties",
                column: "DieId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBoards_GameSetId",
                table: "GameBoards",
                column: "GameSetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameBoardSpaces_GameBoardId",
                table: "GameBoardSpaces",
                column: "GameBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBoardSpaceStateProperties_GameBoardSpaceId",
                table: "GameBoardSpaceStateProperties",
                column: "GameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBoardStateProperties_GameBoardId",
                table: "GameBoardStateProperties",
                column: "GameBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePieces_GameBoardSpaceId",
                table: "GamePieces",
                column: "GameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePieces_GameSetId",
                table: "GamePieces",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePieceStateProperties_GamePieceId",
                table: "GamePieceStateProperties",
                column: "GamePieceId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSets_GameId",
                table: "GameSets",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameSetStateProperties_GameSetId",
                table: "GameSetStateProperties",
                column: "GameSetId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStateProperties_GameId",
                table: "GameStateProperties",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStateProperties_PlayerId",
                table: "PlayerStateProperties",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceConnections_GameBoardSpaceId",
                table: "SpaceConnections",
                column: "GameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceConnections_RemoteSpaceId",
                table: "SpaceConnections",
                column: "RemoteSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceConnectionStateProperties_SpaceConnectionId",
                table: "SpaceConnectionStateProperties",
                column: "SpaceConnectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardsInDecks");

            migrationBuilder.DropTable(
                name: "CardStateProperties");

            migrationBuilder.DropTable(
                name: "DeckStateProperties");

            migrationBuilder.DropTable(
                name: "DieStateProperties");

            migrationBuilder.DropTable(
                name: "GameBoardSpaceStateProperties");

            migrationBuilder.DropTable(
                name: "GameBoardStateProperties");

            migrationBuilder.DropTable(
                name: "GamePieceStateProperties");

            migrationBuilder.DropTable(
                name: "GameSetStateProperties");

            migrationBuilder.DropTable(
                name: "GameStateProperties");

            migrationBuilder.DropTable(
                name: "PlayerStateProperties");

            migrationBuilder.DropTable(
                name: "SpaceConnectionStateProperties");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Dice");

            migrationBuilder.DropTable(
                name: "GamePieces");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SpaceConnections");

            migrationBuilder.DropTable(
                name: "GameBoardSpaces");

            migrationBuilder.DropTable(
                name: "GameBoards");

            migrationBuilder.DropTable(
                name: "GameSets");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
