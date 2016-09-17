using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Services.Interfaces;
namespace MrPitiful.BoardGame.Base.Controllers
{
 
    [Route("api/[controller]")]
    public abstract class GameController : GameObjectController
    {
        private IGameService _gameService;
        private IGame _game; 
        public GameController(IGameService gameService, IGame game) : base(gameService, game) {
            _gameService = gameService;
            _game = game;
        }

        // GET api/game/AddPlayerIdToGame/12345/2345
        [HttpGet("AddPlayerIdToGame/{playerId}/{gameId}")]
        public void AddPlayerIdToGame(Guid playerId, Guid gameId)
        {
            _gameService.AddPlayerIdToGame(
                playerId,
                (IGame)_gameService.Get(gameId)
            );          
        }

        // GET api/game/RemovePlayerIdFromGame/12345/2345
        [HttpGet("RemovePlayerIdFromGame/{playerId}/{gameId}")]
        public void RemovePlayerIdFromGame(Guid playerId, Guid gameId)
        {
            _gameService.RemovePlayerIdFromGame(
                playerId,
                (IGame)_gameService.Get(gameId)
            );
        }

        // GET api/game/AddGamePieceIdToGame/12345/2345
        [HttpGet("AddGamePieceIdToGame/{gamePieceId}/{gameId}")]
        public void AddGamePieceIdToGame(Guid gamePieceId, Guid gameId)
        {
            _gameService.AddGamePieceIdToGame(
                gamePieceId,
                (IGame)_gameService.Get(gameId)
            );
        }

        // GET api/game/RemoveGamePieceIdFromGame/12345/2345
        [HttpGet("RemoveGamePieceIdFromGame/{gamePieceId}/{gameId}")]
        public void RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId)
        {
            _gameService.RemoveGamePieceIdFromGame(
                gamePieceId,
                (IGame)_gameService.Get(gameId)
            );
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("AddGameBoardSpaceIdToGame/{gameBoardSpaceId}/{gameId}")]
        public void AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId)
        {
            _gameService.AddGameBoardSpaceIdToGame(
                gameBoardSpaceId,
                (IGame)_gameService.Get(gameId)
            );
        }

        // GET api/game/RemoveGameBoardSpaceIdFromGame/12345/2345
        [HttpGet("RemoveGameBoardSpaceIdFromGame/{gameBoardSpaceId}/{gameId}")]
        public void RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId)
        {
            _gameService.RemoveGameBoardSpaceIdFromGame(
                gameBoardSpaceId,
                (IGame)_gameService.Get(gameId)
            );
        }
    }
}
