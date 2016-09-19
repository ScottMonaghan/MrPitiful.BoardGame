using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess.Controllers
{
 
    [Route("api/[controller]")]
    public class UnicodeChessGameController: GameController
    {
        public UnicodeChessGameController(IGameRepository gameRepository, IGame game) : base(gameRepository, game)
        {           
        }
    }
}
