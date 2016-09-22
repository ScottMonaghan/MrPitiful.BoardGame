using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    [Route("api/[controller]")]
    public class ChessGamePieceController : GamePieceController
    {
        public ChessGamePieceController(IGamePieceRepository gamePieceRepository, IGamePiece gamePiece) : base(gamePieceRepository, gamePiece)
        {
        }
    }
}
