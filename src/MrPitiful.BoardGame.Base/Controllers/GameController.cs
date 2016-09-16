using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Services.Interfaces;
namespace MrPitiful.BoardGame.Base.Controllers
{
 
    [Route("api/[controller]")]
    public abstract class GameController : Controller
    {

        private IGameService _gameService;
        private IGame _game;
        // GET api/values
 
        public GameController(IGameService gameService, IGame game)
        {
            _gameService = gameService;
            _game = game;
        }

        [HttpGet]
        public IDictionary<Guid, IGame> Get()
        {
            return _gameService.Get();
        }

        // GET api/game/5
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return new ObjectResult(
                   _gameService.Get(id)
            );
        }
        
        // GET api/game/Create
        [HttpGet("Create")]
        public ActionResult Create()
        {
            return new ObjectResult(
                   _gameService.Create(
                       _game
                   )
            );
        }

        // GET api/game/AddPlayerIdToGame/12345/2345
        [HttpGet("AddPlayerIdToGame/{playerId}/{gameId}")]
        public void AddPlayerIdToGame(Guid playerId, Guid gameId)
        {
            _gameService.AddPlayerIdToGame(
                playerId,
                _gameService.Get(gameId)
            );          
        }

        // GET api/game/RemovePlayerIdFromGame/12345/2345
        [HttpGet("RemovePlayerIdFromGame/{playerId}/{gameId}")]
        public void RemovePlayerIdFromGame(Guid playerId, Guid gameId)
        {
            _gameService.RemovePlayerIdFromGame(
                playerId,
                _gameService.Get(gameId)
            );
        }

        // GET api/game/AddGamePieceIdToGame/12345/2345
        [HttpGet("AddGamePieceIdToGame/{gamePieceId}/{gameId}")]
        public void AddGamePieceIdToGame(Guid gamePieceId, Guid gameId)
        {
            _gameService.AddGamePieceIdToGame(
                gamePieceId,
                _gameService.Get(gameId)
            );
        }

        // GET api/game/RemoveGamePieceIdFromGame/12345/2345
        [HttpGet("RemoveGamePieceIdFromGame/{gamePieceId}/{gameId}")]
        public void RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId)
        {
            _gameService.RemoveGamePieceIdFromGame(
                gamePieceId,
                _gameService.Get(gameId)
            );
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("AddGameBoardSpaceIdToGame/{gameBoardSpaceId}/{gameId}")]
        public void AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId)
        {
            _gameService.AddGameBoardSpaceIdToGame(
                gameBoardSpaceId,
                _gameService.Get(gameId)
            );
        }

        // GET api/game/RemoveGameBoardSpaceIdFromGame/12345/2345
        [HttpGet("RemoveGameBoardSpaceIdFromGame/{gameBoardSpaceId}/{gameId}")]
        public void RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId)
        {
            _gameService.RemoveGameBoardSpaceIdFromGame(
                gameBoardSpaceId,
                _gameService.Get(gameId)
            );
        }

        // GET api/game/UpdateGameStateProperty/12345/Name/KnightsOfValor
        [HttpGet("UpdateGameStateProperty/{gameId}/{gameStatePropertyName}/{gameStatePropertyValue}")]
        public void UpdateGameStateProperty(Guid gameId, string gameStatePropertyName, string gameStatePropertyValue)
        {
            _gameService.UpdateGameStateProperty(
                _gameService.Get(gameId),
                gameStatePropertyName,
                gameStatePropertyValue
            );
        }

        // GET api/game/GetGameStateProperty/12345/Name
        [HttpGet("GetGameStateProperty/{gameId}/{gameStatePropertyName}")]
        public ActionResult GetGameStateProperty(Guid gameId, string gameStatePropertyName)
        {
            return new ObjectResult(
                _gameService.GetGameStateProperty(_gameService.Get(gameId), gameStatePropertyName)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
