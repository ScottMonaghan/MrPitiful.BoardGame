using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;
using MrPitiful.BoardGame.Base.Services;
using MrPitiful.BoardGame.Base.Services.Interfaces;

namespace MrPitiful.BoardGame.Base.Test
{
    //first we need to make a generic game to inherit from the base class of game
    public class GenericGameObjectService : GameObjectService
    {
        public GenericGameObjectService(IGameObjectRepository gameObjectRepository) : base(gameObjectRepository) {
        }

        public override void AfterGameStep(string gameStep, object Parameters)
        {
            throw new NotImplementedException();
        }

        public override void BeforeGameStep(string gameStep, object Parameters)
        {
            throw new NotImplementedException();
        }

        public override void DuringGameStep(string gameStep, object Parameters)
        {
            throw new NotImplementedException();
        }
    }
}
