using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class Game:GameObject
    {
        public Game(){}
        public List<GameBoardSpace> GameBoardSpaces { get; set; }
        public List<GamePiece> GamePiece { get; set; }
        public GameBoard GameBoard { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
