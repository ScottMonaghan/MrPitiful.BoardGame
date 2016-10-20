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
        public GameBoard(Guid gameId):this()
        {
           this.GameId = gameId;
        }
        public List<GameBoardSpace> GameBoardSpaces
        { get; set; }
    }
}