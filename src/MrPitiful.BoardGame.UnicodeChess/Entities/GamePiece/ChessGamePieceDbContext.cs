using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGamePieceDbContext:GameDbContext
    {
        public ChessGamePieceDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<ChessGamePiece> ChessGamePieces { get; set; }
    }
}
