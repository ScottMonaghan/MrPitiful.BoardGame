using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;


namespace MrPitiful.BoardGame.Base.Repositories
{
    public abstract class ListGameRepository : ListGameObjectRepository, IGameRepository
    {
        public ListGameRepository(IGame game) : base(game)
        {}
    }
}
