using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public class GameObjectDbContext : DbContext
    {
        public GameObjectDbContext(DbContextOptions<GameObjectDbContext> options)
            : base(options) { }

        public DbSet<GameObject> GameObjects { get; set; }
    }
}
