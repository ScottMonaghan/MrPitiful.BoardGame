using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPitiful.BoardGame.UnicodeChess.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameBoxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    GameBoxId = table.Column<Guid>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    GameId = table.Column<Guid>(nullable: true),
                    GameBoardId = table.Column<Guid>(nullable: true),
                    GameBoardSpaceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameObject_GameObject_GameId",
                        column: x => x.GameId,
                        principalTable: "GameObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObject_GameObject_GameBoardId",
                        column: x => x.GameBoardId,
                        principalTable: "GameObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObject_GameBoxes_GameBoxId",
                        column: x => x.GameBoxId,
                        principalTable: "GameBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameObject_GameObject_GameBoardSpaceId",
                        column: x => x.GameBoardSpaceId,
                        principalTable: "GameObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdjacentSpaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdjacentGameBoardSpaceId = table.Column<Guid>(nullable: false),
                    Direction = table.Column<string>(nullable: true),
                    ParentGameBoardSpaceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjacentSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdjacentSpaces_GameObject_AdjacentGameBoardSpaceId",
                        column: x => x.AdjacentGameBoardSpaceId,
                        principalTable: "GameObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdjacentSpaces_GameObject_ParentGameBoardSpaceId",
                        column: x => x.ParentGameBoardSpaceId,
                        principalTable: "GameObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StateProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameObjectId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProperties_GameObject_GameObjectId",
                        column: x => x.GameObjectId,
                        principalTable: "GameObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdjacentSpaces_AdjacentGameBoardSpaceId",
                table: "AdjacentSpaces",
                column: "AdjacentGameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AdjacentSpaces_ParentGameBoardSpaceId",
                table: "AdjacentSpaces",
                column: "ParentGameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObject_GameBoxId",
                table: "GameObject",
                column: "GameBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObject_GameId",
                table: "GameObject",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameObject_GameBoardId",
                table: "GameObject",
                column: "GameBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObject_GameBoardSpaceId",
                table: "GameObject",
                column: "GameBoardSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProperties_GameObjectId",
                table: "StateProperties",
                column: "GameObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjacentSpaces");

            migrationBuilder.DropTable(
                name: "StateProperties");

            migrationBuilder.DropTable(
                name: "GameObject");

            migrationBuilder.DropTable(
                name: "GameBoxes");
        }
    }
}
