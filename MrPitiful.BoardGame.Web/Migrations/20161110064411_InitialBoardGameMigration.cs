using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPitiful.BoardGame.Web.Migrations
{
    public partial class InitialBoardGameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSets", x => x.Id);
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
                name: "AdjacentSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Direction = table.Column<string>(nullable: true),
                    GameBoardSpaceId = table.Column<Guid>(nullable: false),
                    RemoteSpaceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjacentSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdjacentSpaces_GameBoardSpaces_GameBoardSpaceId",
                        column: x => x.GameBoardSpaceId,
                        principalTable: "GameBoardSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdjacentSpaces_GameBoardSpaces_RemoteSpaceId",
                        column: x => x.RemoteSpaceId,
                        principalTable: "GameBoardSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_AdjacentSpaces_GameBoardSpaceId",
                table: "AdjacentSpaces",
                column: "GameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdjacentSpaces_RemoteSpaceId",
                table: "AdjacentSpaces",
                column: "RemoteSpaceId");

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
                name: "IX_GameSetStateProperties_GameSetId",
                table: "GameSetStateProperties",
                column: "GameSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjacentSpaces");

            migrationBuilder.DropTable(
                name: "GameBoardSpaceStateProperties");

            migrationBuilder.DropTable(
                name: "GameBoardStateProperties");

            migrationBuilder.DropTable(
                name: "GamePieceStateProperties");

            migrationBuilder.DropTable(
                name: "GameSetStateProperties");

            migrationBuilder.DropTable(
                name: "GamePieces");

            migrationBuilder.DropTable(
                name: "GameBoardSpaces");

            migrationBuilder.DropTable(
                name: "GameBoards");

            migrationBuilder.DropTable(
                name: "GameSets");
        }
    }
}
