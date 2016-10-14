using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGameDbContext:GameDbContext
    {
        public ChessGameDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<ChessGame> ChessGames { get; set; }
    }
}
