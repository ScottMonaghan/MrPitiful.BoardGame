using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGameBoardSpaceDbContext:GameDbContext
    {
        public ChessGameBoardSpaceDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<ChessGameBoardSpace> ChessGameBoardSpaces { get; set; }
    }
}
