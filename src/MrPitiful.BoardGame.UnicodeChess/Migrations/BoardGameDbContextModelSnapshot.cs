using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.BoardGame.UnicodeChess.Migrations
{
    [DbContext(typeof(BoardGameDbContext))]
    partial class BoardGameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrPitiful.BoardGame.Base.AdjacentSpace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AdjacentGameBoardSpaceId");

                    b.Property<string>("Direction");

                    b.Property<Guid>("ParentGameBoardSpaceId");

                    b.HasKey("Id");

                    b.HasIndex("AdjacentGameBoardSpaceId");

                    b.HasIndex("ParentGameBoardSpaceId");

                    b.ToTable("AdjacentSpaces");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameBox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("GameBoxes");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid>("GameBoxId");

                    b.HasKey("Id");

                    b.HasIndex("GameBoxId");

                    b.ToTable("GameObject");

                    b.HasDiscriminator<string>("Discriminator").HasValue("GameObject");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.StateProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameObjectId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("GameObjectId");

                    b.ToTable("StateProperties");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.Game", b =>
                {
                    b.HasBaseType("MrPitiful.BoardGame.Base.GameObject");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.ToTable("Game");

                    b.HasDiscriminator().HasValue("Game");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameBoard", b =>
                {
                    b.HasBaseType("MrPitiful.BoardGame.Base.GameObject");

                    b.Property<Guid>("GameId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("GameBoard");

                    b.HasDiscriminator().HasValue("GameBoard");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameBoardSpace", b =>
                {
                    b.HasBaseType("MrPitiful.BoardGame.Base.GameObject");

                    b.Property<Guid>("GameBoardId");

                    b.HasIndex("GameBoardId");

                    b.ToTable("GameBoardSpace");

                    b.HasDiscriminator().HasValue("GameBoardSpace");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GamePiece", b =>
                {
                    b.HasBaseType("MrPitiful.BoardGame.Base.GameObject");

                    b.Property<Guid>("GameBoardSpaceId");

                    b.HasIndex("GameBoardSpaceId");

                    b.ToTable("GamePiece");

                    b.HasDiscriminator().HasValue("GamePiece");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.AdjacentSpace", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Base.GameBoardSpace", "AdjacentGameBoardSpace")
                        .WithMany()
                        .HasForeignKey("AdjacentGameBoardSpaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MrPitiful.BoardGame.Base.GameBoardSpace", "ParentGameBoardSpace")
                        .WithMany("AdjacentSpaces")
                        .HasForeignKey("ParentGameBoardSpaceId");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameObject", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Base.GameBox", "GameBox")
                        .WithMany("GameObjects")
                        .HasForeignKey("GameBoxId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.StateProperty", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Base.GameObject", "GameObject")
                        .WithMany("StateProperties")
                        .HasForeignKey("GameObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameBoard", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Base.Game", "Game")
                        .WithOne("GameBoard")
                        .HasForeignKey("MrPitiful.BoardGame.Base.GameBoard", "GameId");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GameBoardSpace", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Base.GameBoard", "GameBoard")
                        .WithMany("GameBoardSpaces")
                        .HasForeignKey("GameBoardId");
                });

            modelBuilder.Entity("MrPitiful.BoardGame.Base.GamePiece", b =>
                {
                    b.HasOne("MrPitiful.BoardGame.Base.GameBoardSpace", "GameBoardSpace")
                        .WithMany("GamePieces")
                        .HasForeignKey("GameBoardSpaceId");
                });
        }
    }
}
