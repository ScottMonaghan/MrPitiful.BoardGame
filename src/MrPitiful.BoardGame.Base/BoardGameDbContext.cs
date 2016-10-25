using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MrPitiful.BoardGame.Base
{
    public class BoardGameDbContext:DbContext
    {
        public BoardGameDbContext(DbContextOptions<BoardGameDbContext> options) : base(options) { }
        public DbSet<GameBox> GameBoxes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBoard> GameBoards { get; set; }
        public DbSet<GameBoardSpace> GameBoardSpaces { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<AdjacentSpace> AdjacentSpaces { get; set; }
        public DbSet<StateProperty> StateProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdjacentSpace>()
                .HasOne(a => a.ParentGameBoardSpace)
                .WithMany(gbs => gbs.AdjacentSpaces)
                .HasForeignKey(a => a.ParentGameBoardSpaceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AdjacentSpace>()
                .HasOne(a => a.AdjacentGameBoardSpace);
            
            modelBuilder.Entity<GameBoard>()
                .HasOne(gb => gb.Game)
                .WithOne(g => g.GameBoard)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameBoardSpace>()
                .HasOne(gbs => gbs.GameBoard)
                .WithMany(gb => gb.GameBoardSpaces)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GamePiece>()
                .HasOne(gp => gp.GameBoardSpace)
                .WithMany(gbs => gbs.GamePieces)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
