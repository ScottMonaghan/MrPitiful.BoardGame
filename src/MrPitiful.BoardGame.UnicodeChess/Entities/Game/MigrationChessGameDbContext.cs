using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class MigrationChessGameDbContext : DbContext
    {
        public MigrationChessGameDbContext(DbContextOptions<MigrationChessGameDbContext> options)
            : base(options) { }

        public DbSet<GameObject> GameObjects { get; set; }
        public DbSet<ChessGame> ChessGames { get; set; }
    }
}
