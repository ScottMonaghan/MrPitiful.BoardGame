using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base.Controllers;
using MrPitiful.BoardGame.Base.Services.Interfaces;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.BoardGame.Base.Test
{

    [Route("api/[controller]")]
    public class GenericGameObjectController : GameObjectController
    {
        public GenericGameObjectController(IGameObjectService gameObjectService, IGameObject gameObject) : base(gameObjectService, gameObject)
        {
        }
    }
}
