using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.SlackChess
{
    public class SlackChessGameDbContext:DbContext
    {
        public SlackChessGameDbContext(DbContextOptions<SlackChessGameDbContext> options)
            : base(options) { }

        public DbSet<SlackChessGame> SlackChessGames { get; set; }
    }
}
