﻿using System;
using System.Collections.Generic;


namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGameBoardSpaceRepository : ListGameObjectRepository, IGameBoardSpaceRepository
    {
        public ListGameBoardSpaceRepository(GameBoardSpace gameBoardSpace) : base(gameBoardSpace)
        {}
    }
}