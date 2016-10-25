﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base.Test
{
    [Route("api/[controller]")]
    public class GenericGameBoardController : GameBoardController
    {
        public GenericGameBoardController(IGameBoardRepository gameBoardRepository, GameBoard gameBoard) : base(gameBoardRepository, gameBoard)
        {
        }
    }
}