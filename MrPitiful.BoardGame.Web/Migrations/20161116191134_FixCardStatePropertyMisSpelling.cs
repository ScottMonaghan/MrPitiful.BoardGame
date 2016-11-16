using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MrPitiful.BoardGame.Web.Migrations
{
    public partial class FixCardStatePropertyMisSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardStateProperites_Cards_CardId",
                table: "CardStateProperites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardStateProperites",
                table: "CardStateProperites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardStateProperties",
                table: "CardStateProperites",
                columns: new[] { "CardId", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_CardStateProperties_Cards_CardId",
                table: "CardStateProperites",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_CardStateProperites_CardId",
                table: "CardStateProperites",
                newName: "IX_CardStateProperties_CardId");

            migrationBuilder.RenameTable(
                name: "CardStateProperites",
                newName: "CardStateProperties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardStateProperties_Cards_CardId",
                table: "CardStateProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardStateProperties",
                table: "CardStateProperties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardStateProperites",
                table: "CardStateProperties",
                columns: new[] { "CardId", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_CardStateProperites_Cards_CardId",
                table: "CardStateProperties",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_CardStateProperties_CardId",
                table: "CardStateProperties",
                newName: "IX_CardStateProperites_CardId");

            migrationBuilder.RenameTable(
                name: "CardStateProperties",
                newName: "CardStateProperites");
        }
    }
}
