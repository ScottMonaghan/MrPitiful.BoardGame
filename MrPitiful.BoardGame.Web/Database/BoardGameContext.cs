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
            modelBuilder.Entity<GameSetStateProperty>()
                .HasKey(x => new { x.GameSetId, x.Name });
            modelBuilder.Entity<GameBoardStateProperty>()
                .HasKey(x => new { x.GameBoardId, x.Name });
            modelBuilder.Entity<GameBoardSpaceStateProperty>()
                .HasKey(x => new { x.GameBoardSpaceId, x.Name });
            modelBuilder.Entity<GamePieceStateProperty>()
                .HasKey(x => new { x.GamePieceId, x.Name });
        }
    }
}
