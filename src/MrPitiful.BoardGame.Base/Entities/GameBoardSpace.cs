using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class GameBoardSpace : GameObject
    {
        public GameBoardSpace(){}
        public GameBoard GameBoard { get; set; }
        public List<GamePiece> GamePieces { get; set; }
        public List<AdjacentSpace> AdjacentSpaces { get; set; }
    }
}
