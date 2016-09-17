using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;

namespace MrPitiful.BoardGame.Base.Test
{
    public class MockGameRepository : MockGameObjectRepository, IGameRepository
    {}
}
