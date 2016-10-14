using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base.Test
{

    [Route("api/[controller]")]
    public class GenericGameObjectController : GameObjectController
    {
        public GenericGameObjectController(IGameObjectRepository gameObjectRepository, GameObject gameObject) : base(gameObjectRepository, gameObject)
        {
        }
    }
}
