using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    [Route("api/[controller]")]
    public class ChessGameController : GameController
    {
        public ChessGameController(IGameRepository gameRepository, IStatePropertyRepository statePropertyRepository, IGame game) : base(gameRepository, statePropertyRepository, game)
        {
        }
    }
}
