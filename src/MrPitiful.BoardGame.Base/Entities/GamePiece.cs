using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class GamePiece : GameObject
    {
        public GamePiece() { }
        public Game Game {get; set;}
        public Guid GameBoardId { get; set; }
        public GameBoard GameBoard { get; set; }
        public Guid GameBoardSpaceId { get; set; }
        public GameBoard GameBoardSpace { get; set; }
    }
}
