﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    [Route("api/[controller]")]
    public class ChessGameBoardSpaceController : GameBoardSpaceController
    {
        public ChessGameBoardSpaceController(IGameBoardSpaceRepository gameBoardSpaceRepository, IStatePropertyRepository statePropertyRepository, IGameBoardSpace gameBoardSpace) : base(gameBoardSpaceRepository, statePropertyRepository, gameBoardSpace)
        {
        }
    }
}