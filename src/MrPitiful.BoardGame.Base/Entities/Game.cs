using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class Game:GameObject
    {
        public Game(){}
        public GameBoard GameBoard { get; set; }
        //public Guid GameBoardId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
