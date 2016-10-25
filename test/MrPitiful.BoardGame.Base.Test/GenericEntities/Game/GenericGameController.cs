﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base.Test
{
    [Route("api/[controller]")]
    public class GenericGameController : GameController
    {
        public GenericGameController(IGameRepository gameRepository, Game game) : base(gameRepository, game)
        {
        }
    }
}