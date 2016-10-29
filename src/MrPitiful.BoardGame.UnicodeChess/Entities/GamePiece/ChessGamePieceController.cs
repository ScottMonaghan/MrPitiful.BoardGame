using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    [Route("api/[controller]")]
    public class ChessGamePieceController : GamePieceController
    {
        public ChessGamePieceController(IGamePieceRepository gamePieceRepository, IStatePropertyRepository statePropertyRepository, IGamePiece gamePiece) : base(gamePieceRepository, statePropertyRepository, gamePiece)
        {
        }
    }
}
