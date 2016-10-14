using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Test
{
    //first we need to make a generic listgamerepository to inherit from the base class of game
    public class GenericListGameObjectRepository : ListGameObjectRepository
    {
        public GenericListGameObjectRepository(GameObject gameObject) : base(gameObject){}
    }
}
