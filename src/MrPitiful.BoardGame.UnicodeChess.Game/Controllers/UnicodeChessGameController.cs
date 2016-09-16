using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base.Controllers;
using MrPitiful.BoardGame.Base.Services.Interfaces;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.UnicodeChess.Controllers
{
 
    [Route("api/[controller]")]
    public class UnicodeChessGameController: GameController
    {
        public UnicodeChessGameController(IGameService gameService, IGame game) : base(gameService, game)
        {           
        }
    }
}
