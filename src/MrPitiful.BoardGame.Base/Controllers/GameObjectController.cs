using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Services.Interfaces;
namespace MrPitiful.BoardGame.Base.Controllers
{
 
    [Route("api/[controller]")]
    public abstract class GameObjectController : Controller
    {

        private IGameObjectService _gameObjectService;
        private IGameObject _gameObject;
        // GET api/values
 
        public GameObjectController(IGameObjectService gameObjectService, IGameObject gameObject)
        {
            _gameObjectService = gameObjectService;
            _gameObject = gameObject;
        }

        [HttpGet]
        public Dictionary<Guid, IGameObject> Get()
        {
            return _gameObjectService.Get();
        }

        // GET api/gameObject/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return new ObjectResult(
                   _gameObjectService.Get(id)
            );
        }
        
        // GET api/gameObject/Create
        [HttpGet("Create")]
        public ActionResult Create()
        {
            return new ObjectResult(
                   _gameObjectService.Create(_gameObject)
            );
        }

        // GET api/gameObject/GetGameStateProperty/12345/Name
        [HttpGet("GetStateProperty/{gameObjectId}/{propertyName}")]
        public ActionResult GetStateProperty(Guid gameObjectId, string propertyName)
        {
            return new ObjectResult(
                _gameObjectService.GetStateProperty(_gameObjectService.Get(gameObjectId), propertyName)
            );
        }

        // GET api/gameObject/SetStateProperty/12345/Name/KnightsOfValor
        [HttpGet("SetStateProperty/{gameObjectId}/{propertyName}/{propertyValue}")]
        public void SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue)
        {
            _gameObjectService.SetStateProperty(
                _gameObjectService.Get(gameObjectId),
                propertyName,
                propertyValue
            );
        }

          // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
