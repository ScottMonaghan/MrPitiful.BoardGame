using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public class GameBoardDbContext:GameObjectDbContext
    {
        public GameBoardDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<GameBoard> GameBoards { get; set; }
    }
}
