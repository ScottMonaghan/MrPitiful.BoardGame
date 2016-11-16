using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MrPitiful.BoardGame.Database;

namespace MrPitiful.BoardGame.Web.Migrations
{
    [DbContext(typeof(BoardGameContext))]
    [Migration("20161116035206_AddedCardsAndDecks")]
    partial class AddedCardsAndDecks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameSetId");

                    b.HasKey("Id");

                    b.HasIndex("GameSetId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.CardInDeck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CardId");

                    b.Property<Guid?>("CardId1");

                    b.Property<Guid>("DeckId");

                    b.Property<int>("Position");

                    b.HasKey("Id");

                    b.HasIndex("CardId1")
                        .IsUnique();

                    b.HasIndex("DeckId");

                    b.ToTable("CardsInDecks");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.CardStateProperty", b =>
                {
                    b.Property<Guid>("CardId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("CardId", "Name");

                    b.HasIndex("CardId");

                    b.ToTable("CardStateProperites");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Deck", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameSetId");

                    b.HasKey("Id");

                    b.HasIndex("GameSetId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.DeckStateProperty", b =>
                {
                    b.Property<Guid>("DeckId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("DeckId1");

                    b.Property<string>("Value");

                    b.HasKey("DeckId", "Name");

                    b.HasIndex("DeckId");

                    b.HasIndex("DeckId1");

                    b.ToTable("DeckStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Die", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameSetId");

                    b.Property<int>("Sides");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("GameSetId");

                    b.ToTable("Dice");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.DieStateProperty", b =>
                {
                    b.Property<Guid>("DieId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("DieId", "Name");

                    b.HasIndex("DieId");

                    b.ToTable("DieStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Games");
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

                    b.Property<Guid?>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

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

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameStateProperty", b =>
                {
                    b.Property<Guid>("GameId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("GameId", "Name");

                    b.HasIndex("GameId");

                    b.ToTable("GameStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.PlayerStateProperty", b =>
                {
                    b.Property<Guid>("PlayerId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("PlayerId", "Name");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.SpaceConnection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameBoardSpaceId");

                    b.Property<Guid?>("RemoteSpaceId");

                    b.HasKey("Id");

                    b.HasIndex("GameBoardSpaceId");

                    b.HasIndex("RemoteSpaceId");

                    b.ToTable("SpaceConnections");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.SpaceConnectionStateProperty", b =>
                {
                    b.Property<Guid>("SpaceConnectionId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("SpaceConnectionId", "Name");

                    b.HasIndex("SpaceConnectionId");

                    b.ToTable("SpaceConnectionStateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Card", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithMany("Cards")
                        .HasForeignKey("GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.CardInDeck", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Card", "Card")
                        .WithOne("CardInDeck")
                        .HasForeignKey("MrPitiful.BoardGame.Models.CardInDeck", "CardId1");

                    b.HasOne("MrPitiful.BoardGame.Models.Deck", "Deck")
                        .WithMany("CardsInDeck")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.CardStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Card", "Card")
                        .WithMany("StateProperties")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Deck", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithMany("Decks")
                        .HasForeignKey("GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.DeckStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Deck")
                        .WithMany("StateProperties")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MrPitiful.BoardGame.Models.Card", "Deck")
                        .WithMany()
                        .HasForeignKey("DeckId1");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Die", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithMany()
                        .HasForeignKey("GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.DieStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Die", "Die")
                        .WithMany("StateProperties")
                        .HasForeignKey("DieId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameSet", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Game", "Game")
                        .WithOne("GameSet")
                        .HasForeignKey("MrPitiful.BoardGame.Models.GameSet", "GameId");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameSetStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameSet", "GameSet")
                        .WithMany("StateProperties")
                        .HasForeignKey("GameSetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.GameStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Game", "Game")
                        .WithMany("StateProperties")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.Player", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.PlayerStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.Player", "Player")
                        .WithMany("StateProperties")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.SpaceConnection", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.GameBoardSpace", "GameBoardSpace")
                        .WithMany("SpaceConnections")
                        .HasForeignKey("GameBoardSpaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MrPitiful.BoardGame.Models.GameBoardSpace", "RemoteSpace")
                        .WithMany()
                        .HasForeignKey("RemoteSpaceId");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Models.SpaceConnectionStateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Models.SpaceConnection", "ConnectedSpace")
                        .WithMany("StateProperties")
                        .HasForeignKey("SpaceConnectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
