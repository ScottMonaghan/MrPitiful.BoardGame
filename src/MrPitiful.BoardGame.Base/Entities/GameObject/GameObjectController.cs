using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public abstract class GameObjectController : Controller
    {

        private IGameObjectRepository _gameObjectRepository;
        private GameObject _gameObject;
        // GET api/values
 
        public GameObjectController(IGameObjectRepository gameObjectRepository, GameObject gameObject)
        {
            _gameObjectRepository = gameObjectRepository;
            _gameObject = gameObject;
        }

        [HttpGet]
        public async Task<Dictionary<Guid, GameObject>> Get()
        {
            return await _gameObjectRepository.Get();
        }

        // GET api/gameObject/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            return new ObjectResult(
                   await _gameObjectRepository.Get(id)
            );
        }

        // GET api/gameObject/Create
        [HttpGet("Create")]
        public async Task<ActionResult> Create()
        {
            return new ObjectResult(
                   await _gameObjectRepository.Create(_gameObject)
            );
        }

        // GET api/gameObject/GetGameStateProperty/12345/Name
        [HttpGet("GetStateProperty/{gameObjectId}/{propertyName}")]
        public async Task<ActionResult> GetStateProperty(Guid gameObjectId, string propertyName)
        {
            GameObject gameObject = await _gameObjectRepository.Get(gameObjectId);
            return new ObjectResult(
                gameObject.State[propertyName] 
            );
        }

        // GET api/gameObject/SetStateProperty/12345/Name/KnightsOfValor
        [HttpGet("SetStateProperty/{gameObjectId}/{propertyName}")]
        public async Task<ActionResult> SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue)
        {
            GameObject gameObject = await _gameObjectRepository.Get(gameObjectId);
            gameObject.State[propertyName] = WebUtility.UrlDecode(propertyValue);
            await _gameObjectRepository.Save(gameObject);
            return new NoContentResult();           
        }

        [HttpGet("ClearStateProperty/{gameObjectId}/{propertyName}")]
        public async Task<ActionResult> ClearStateProperty(Guid gameObjectId, string propertyName)
        {
            GameObject gameObject = await _gameObjectRepository.Get(gameObjectId);
            if (gameObject.State.ContainsKey(propertyName))
            {
                gameObject.State[propertyName] = "";
            } else
            {
                gameObject.State.Add(propertyName, "");
            }
            await _gameObjectRepository.Save(gameObject);
            return new NoContentResult();
        }

        //returns objects with matching state properties
        // GET api/gameObject/GetByStateProperties/propertyName:propertyValue/propertyName:propertyValue...
        [HttpGet("GetByStateProperties/{gameId}/{*stateProperties}")]
        public async Task<IActionResult> GetByStateProperties(Guid gameId, string stateProperties)
        {
            Dictionary<string, string> statePropertiesDictionary = new Dictionary<string, string>();
            string[] propertyValuePairs = stateProperties.Split('/');
            foreach (string propertyValuePair in propertyValuePairs)
            {
                statePropertiesDictionary.Add(propertyValuePair.Split(':')[0], propertyValuePair.Split(':')[1]);
            }
            return new ObjectResult(
                await _gameObjectRepository.GetByStateProperties(gameId, statePropertiesDictionary)
            );
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("SetGameId/{gameObjectId}/{gameId}")]
        public async Task SetGameBoardGameId(Guid gameObjectId, Guid gameId)
        {
            GameObject gameObject = await _gameObjectRepository.Get(gameObjectId);
            gameObject.GameId = gameId;
            await _gameObjectRepository.Save(gameObject);

        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("GetGameId/{gameObjectId}")]
        public async Task<Guid> GetGameBoardGameId(Guid gameObjectId)
        {
            return (await _gameObjectRepository.Get(gameObjectId)).GameId;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
