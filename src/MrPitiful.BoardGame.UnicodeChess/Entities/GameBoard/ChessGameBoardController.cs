using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    [Route("api/[controller]")]
    public class ChessGameBoardController : GameBoardController
    {
        public ChessGameBoardController(IGameBoardRepository gameBoardRepository, GameBoard gameBoard) : base(gameBoardRepository, gameBoard)
        {
        }
    }
}
