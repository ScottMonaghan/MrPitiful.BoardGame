using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public class GamePieceDbContext:GameObjectDbContext
    {
        public GamePieceDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<GamePiece> GamePieces { get; set; }
    }
}
