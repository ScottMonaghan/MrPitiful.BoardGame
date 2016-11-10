using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Models;

namespace MrPitiful.BoardGame.Database
{
    public class BoardGameContext:DbContext
    {
        public BoardGameContext(DbContextOptions<BoardGameContext> options)
            : base(options)
        { }
        //public DbSet<GameStateProperty> GameStateProperties { get; set; }
        public DbSet<GameSet> GameSets { get; set; }
        public DbSet<GameSetStateProperty> GameSetStateProperties { get; set; }
        public DbSet<GameBoard> GameBoards { get; set; }
        public DbSet<GameBoardStateProperty> GameBoardStateProperties { get; set; }
        public DbSet<GameBoardSpace> GameBoardSpaces { get; set; }
        public DbSet<GameBoardSpaceStateProperty> GameBoardSpaceStateProperties { get; set; }
        public DbSet<AdjacentSpace> AdjacentSpaces { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<GamePieceStateProperty> GamePieceStateProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adjacent Spaces
            modelBuilder.Entity<AdjacentSpace>()
                    .HasOne(ajs => ajs.GameBoardSpace)
                    .WithMany(gbs => gbs.AdjacentSpaces)
                    .HasForeignKey(ajs => ajs.GameBoardSpaceId);

            modelBuilder.Entity<AdjacentSpace>()
                .HasOne(adj => adj.RemoteSpace);
            /*
            modelBuilder.Entity<GamePiece>()
                .HasOne(gp => gp.GameBoardSpace)
                .WithMany(gbs => gbs.GamePieces)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.SetNull);


            //GameSet
            /*
                //GameSetStateProperties
                modelBuilder.Entity<GameSetStateProperty>()
                    .HasOne(sp => (GameSet)sp.GameItem)
                    .WithMany(gs => gs.StateProperties.Cast<GameSetStateProperty>())
                    .HasForeignKey(sp => sp.GameItemId);
                //GameBoard
                modelBuilder.Entity<GameBoard>()
                    .HasOne(gb => (GameSet)gb.GameSet)
                    .WithOne(gs => (GameBoard)gs.GameBoard)
                    .HasForeignKey("GameBoardId");
                //GameBoardSpace
                modelBuilder.Entity<GameBoardSpace>()
                    .HasOne(gbs => (GameSet)gbs.GameSet)
                    .WithMany(gs => gs.GamePieces.Cast<GameBoardSpace>())
                    .HasForeignKey(gbs => gbs.GameSetId);
                //GamePieces
                modelBuilder.Entity<GamePiece>()
                        .HasOne(gp => gp.GameSet)
                        .WithMany(gs => gs.GamePieces.Cast<GamePiece>())
                        .HasForeignKey(gp => gp.GameSetId);
            //GameBoard
                //GameBoardStateProperties
                modelBuilder.Entity<GameBoardStateProperty>()
                    .HasOne(sp => (GameBoard)sp.GameItem)
                    .WithMany(gb => gb.StateProperties.Cast<GameBoardStateProperty>())
                    .HasForeignKey(sp => sp.GameItemId);
                //GameBoardSpaces
                modelBuilder.Entity<GameBoardSpace>()
                    .HasOne(gbs => (GameBoard)gbs.GameBoard)
                    .WithMany(gb => gb.GameBoardSpaces.Cast<GameBoardSpace>())
                    .HasForeignKey(gbs => gbs.GameBoardId);
            //GameBoardSpace
                //GameBoardSpaceStateProperties
                modelBuilder.Entity<GameBoardSpaceStateProperty>()
                    .HasOne(sp => (GameBoardSpace)sp.GameItem)
                    .WithMany(gi => gi.StateProperties.Cast<GameBoardSpaceStateProperty>())
                    .HasForeignKey(sp => sp.GameItemId);
                //GamePieces
                modelBuilder.Entity<GamePiece>()
                    .HasOne(gp => gp.GameBoardSpace)
                    .WithMany(gbs => gbs.GamePieces.Cast<GamePiece>())
                    .HasForeignKey(gp => gp.GameBoardSpaceId);
            //GamePiece
                //GameBoardSpaceStateProperties
                modelBuilder.Entity<GamePieceStateProperty>()
                    .HasOne(sp => (GamePiece)sp.GameItem)
                    .WithMany(gi => gi.StateProperties.Cast<GamePieceStateProperty>())
                    .HasForeignKey(sp => sp.GameItemId);
        */
        }
    }
}
