using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoardStateProperty : GameStateProperty
    {
        public GameBoard GameBoard { get; set; }
        public Guid GameBoardId {get;set;}
    }
}
