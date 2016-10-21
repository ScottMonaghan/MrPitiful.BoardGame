using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public class BoardGameDbContext:DbContext
    {
        public BoardGameDbContext(DbContextOptions<BoardGameDbContext> options) : base(options) { }
        public DbSet<GameObject> GameObjects { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBoard> GameBoards { get; set; }
        public DbSet<GameBoardSpace> GameBoardSpaces { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<AdjacentSpace> AdjacentSpaces { get; set; }
        public DbSet<StateProperty> StateProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameObject>()
                .Ignore(go => go.GameId);
            modelBuilder.Entity<Game>()
                .Ignore(g => g.GameId);

        }
    }
}
