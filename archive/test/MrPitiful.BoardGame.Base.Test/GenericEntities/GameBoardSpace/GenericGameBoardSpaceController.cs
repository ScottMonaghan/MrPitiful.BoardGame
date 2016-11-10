using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base.Test
{
    [Route("api/[controller]")]
    public class GenericGameBoardSpaceController : GameBoardSpaceController
    {
        public GenericGameBoardSpaceController(IGameBoardSpaceRepository gameBoardSpaceRepository, IStatePropertyRepository statePropertyRepository, IGameBoardSpace gameBoardSpace) : base(gameBoardSpaceRepository, statePropertyRepository, gameBoardSpace)
        {
        }
    }
}
