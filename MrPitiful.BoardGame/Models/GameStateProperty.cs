using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public abstract class GameStateProperty
    {
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
