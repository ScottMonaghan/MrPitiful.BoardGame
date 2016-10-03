using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public abstract class GameObjectController : Controller
    {

        private IGameObjectRepository _gameObjectRepository;
        private IGameObject _gameObject;
        // GET api/values
 
        public GameObjectController(IGameObjectRepository gameObjectRepository, IGameObject gameObject)
        {
            _gameObjectRepository = gameObjectRepository;
            _gameObject = gameObject;
        }

        [HttpGet]
        public Dictionary<Guid, IGameObject> Get()
        {
            return _gameObjectRepository.Get();
        }

        // GET api/gameObject/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return new ObjectResult(
                   _gameObjectRepository.Get(id)
            );
        }

        // GET api/gameObject/Create
        [HttpGet("Create")]
        public ActionResult Create()
        {
            return new ObjectResult(
                   _gameObjectRepository.Create(_gameObject)
            );
        }

        // GET api/gameObject/GetGameStateProperty/12345/Name
        [HttpGet("GetStateProperty/{gameObjectId}/{propertyName}")]
        public ActionResult GetStateProperty(Guid gameObjectId, string propertyName)
        {
            IGameObject gameObject = _gameObjectRepository.Get(gameObjectId);
            return new ObjectResult(
                gameObject.State[propertyName] 
            );
        }

        // GET api/gameObject/SetStateProperty/12345/Name/KnightsOfValor
        [HttpGet("SetStateProperty/{gameObjectId}/{propertyName}/{propertyValue}")]
        public ActionResult SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue)
        {
            IGameObject gameObject = _gameObjectRepository.Get(gameObjectId);
            gameObject.State[propertyName] = propertyValue;
            _gameObjectRepository.Save(gameObject);
            return new NoContentResult();           
        }

        [HttpGet("ClearStateProperty/{gameObjectId}/{propertyName}")]
        public ActionResult ClearStateProperty(Guid gameObjectId, string propertyName)
        {
            IGameObject gameObject = _gameObjectRepository.Get(gameObjectId);
            gameObject.State[propertyName] = "";
            _gameObjectRepository.Save(gameObject);
            return new NoContentResult();
        }

        //returns objects with matching state properties
        // GET api/gameObject/GetByStateProperties/propertyName:propertyValue/propertyName:propertyValue...
        [HttpGet("GetByStateProperties/{gameId}/{*stateProperties}")]
        public IActionResult GetByStateProperties(Guid gameId, string stateProperties)
        {
            Dictionary<string, string> statePropertiesDictionary = new Dictionary<string, string>();
            string[] propertyValuePairs = stateProperties.Split('/');
            foreach (string propertyValuePair in propertyValuePairs)
            {
                statePropertiesDictionary.Add(propertyValuePair.Split(':')[0], propertyValuePair.Split(':')[1]);
            }
            return new ObjectResult(
                _gameObjectRepository.GetByStateProperties(gameId, statePropertiesDictionary)
            );
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("SetGameId/{gameObjectId}/{gameId}")]
        public void SetGameBoardGameId(Guid gameObjectId, Guid gameId)
        {
            IGameObject gameObject = _gameObjectRepository.Get(gameObjectId);
            gameObject.GameId = gameId;
            _gameObjectRepository.Save(gameObject);

        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("GetGameId/{gameObjectId}")]
        public Guid GetGameBoardGameId(Guid gameObjectId)
        {
            return (_gameObjectRepository.Get(gameObjectId)).GameId;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
