using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Test
{
    //first we need to make a generic game to inherit from the base class of game
    public class GenericGame : Base.Models.Game
    {
        public override void AfterStep(string stepName, object parameters)
        {
            throw new NotImplementedException();
        }

        public override void BeforeStep(string stepName, object parameters)
        {
            throw new NotImplementedException();
        }

        public override void DuringStep(string stepName, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
