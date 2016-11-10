using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MrPitiful.BoardGame.Database;

namespace MrPitiful.BoardGame.Web.Migrations
{
    [DbContext(typeof(BoardGameContext))]
    [Migration("20161110064411_InitialBoardGameMigration")]
    partial class InitialBoardGameMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrPitiful.BoardGame.Models.AdjacentSpace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direction");

                    b.Property<Guid>("GameBoardSpaceId");

                    b.Property<Guid?>("RemoteSpaceId");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardSpaceId");

                    b.HasIndex("RemoteSpaceId");

                    b.ToTable("AdjacentSpaces");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameSetId");

                    b.HasKey("Id");

                    b.HasIndex("GameSetId")
                        .IsUnique();

                    b.ToTable("GameBoards");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoardSpace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameBoardId");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardId");

                    b.ToTable("GameBoardSpaces");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoardSpaceStateProperty", b =>
                {
                    b.Property<Guid>("GameBoardSpaceId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("GameBoardSpaceId", "Name");

                    b.HasIndex("GameBoardSpaceId");

                    b.ToTable("GameBoardSpaceStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoardStateProperty", b =>
                {
                    b.Property<Guid>("GameBoardId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("GameBoardId", "Name");

                    b.HasIndex("GameBoardId");

                    b.ToTable("GameBoardStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GamePiece", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameBoardSpaceId");

                    b.Property<Guid>("GameSetId");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardSpaceId");

                    b.HasIndex("GameSetId");

                    b.ToTable("GamePieces");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GamePieceStateProperty", b =>
                {
                    b.Property<Guid>("GamePieceId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("GamePieceId", "Name");

                    b.HasIndex("GamePieceId");

                    b.ToTable("GamePieceStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("GameSets");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameSetStateProperty", b =>
                {
                    b.Property<Guid>("GameSetId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("GameSetId", "Name");

                    b.HasIndex("GameSetId");

                    b.ToTable("GameSetStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.AdjacentSpace", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameBoardSpace", "GameBoardSpace")
                        .WithMany("AdjacentSpaces")
                        .HasForeignKey("GameBoardSpaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MrPitiful.BoardGame.Models.GameBoardSpace", "RemoteSpace")
                        .WithMany()
                        .HasForeignKey("RemoteSpaceId");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoard", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithOne("GameBoard")
                        .HasForeignKey("MrPitiful.BoardGame.Models.GameBoard", "GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoardSpace", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameBoard", "GameBoard")
                        .WithMany("GameBoardSpaces")
                        .HasForeignKey("GameBoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoardSpaceStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameBoardSpace", "GameBoardSpace")
                        .WithMany("StateProperties")
                        .HasForeignKey("GameBoardSpaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameBoardStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameBoard", "GameBoard")
                        .WithMany("StateProperties")
                        .HasForeignKey("GameBoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GamePiece", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameBoardSpace", "GameBoardSpace")
                        .WithMany("GamePieces")
                        .HasForeignKey("GameBoardSpaceId");

                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithMany("GamePieces")
                        .HasForeignKey("GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GamePieceStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GamePiece", "GamePiece")
                        .WithMany("StateProperties")
                        .HasForeignKey("GamePieceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameSetStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithMany("StateProperties")
                        .HasForeignKey("GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
