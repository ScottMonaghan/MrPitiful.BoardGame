using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public class GameBoardSpaceDbContext:GameObjectDbContext
    {
        public GameBoardSpaceDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<GameBoardSpace> GameBoardSpaces { get; set; }
    }
}
