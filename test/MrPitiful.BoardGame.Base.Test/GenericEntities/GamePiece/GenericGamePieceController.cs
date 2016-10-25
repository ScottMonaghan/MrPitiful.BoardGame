using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base.Test
{
    [Route("api/[controller]")]
    public class GenericGamePieceController : GamePieceController
    {
        public GenericGamePieceController(IGamePieceRepository gamePieceRepository, IGamePiece gamePiece) : base(gamePieceRepository, gamePiece)
        {
        }
    }
}
