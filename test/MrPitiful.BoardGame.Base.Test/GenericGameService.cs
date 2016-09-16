using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;
using MrPitiful.BoardGame.Base.Services.Interfaces;

namespace MrPitiful.BoardGame.Base.Test
{
    //first we need to make a generic game to inherit from the base class of game
    public class GenericGameService : Base.Services.GameService
    {
        public GenericGameService(IGameRepository gameRepository) : base(gameRepository) {}
    }
}
