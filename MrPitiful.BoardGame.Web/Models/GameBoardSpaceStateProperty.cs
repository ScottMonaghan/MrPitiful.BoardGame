using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoardSpaceStateProperty : StateProperty
    {
        public GameBoardSpace GameBoardSpace { get; set; }
        public Guid GameBoardSpaceId {get;set;}
    }
}
