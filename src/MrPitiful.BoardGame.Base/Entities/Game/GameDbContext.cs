using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public class GameDbContext:GameObjectDbContext
    {
        public GameDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
