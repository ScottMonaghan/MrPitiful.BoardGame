using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGameBoardDbContext:GameBoardDbContext
    {
        public ChessGameBoardDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<ChessGameBoard> ChessGameBoards { get; set; }
    }
}
