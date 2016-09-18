using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Repositories;

namespace MrPitiful.BoardGame.Base.Test
{
    //first we need to make a generic listgamerepository to inherit from the base class of game
    public class GenericListGameObjectRepository : ListGameObjectRepository
    {
        public GenericListGameObjectRepository(IGameObject gameObject) : base(gameObject){}
    }
}
