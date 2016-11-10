using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GameSetStateProperty : GameStateProperty
    {
        public GameSet GameSet { get; set; }
        public Guid GameSetId {get;set;}
    }
}
