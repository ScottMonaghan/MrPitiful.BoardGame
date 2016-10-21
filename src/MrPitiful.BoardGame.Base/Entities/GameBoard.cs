﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{ 
    public class GameBoard : GameObject
    {
        public GameBoard(){} 
        public Game Game { get; set; }
        public Guid GameId { get; set; }  
        public List<GameBoardSpace> GameBoardSpaces
        { get; set; }
    }
}
