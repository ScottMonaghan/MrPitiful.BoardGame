﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;
namespace MrPitiful.BoardGame.Base.Controllers
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
        public void SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue)
        {
                IGameObject gameObject = _gameObjectRepository.Get(gameObjectId);
                gameObject.State[propertyName] = propertyValue;
                _gameObjectRepository.Save(gameObject);
        }

          // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
