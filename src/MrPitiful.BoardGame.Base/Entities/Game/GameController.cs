using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.BoardGame.Base
{

    public class GameNotFoundException : Exception { }
    public class GameBoardNotFoundException : Exception { }
    public class PlayerIdNotFoundException : Exception { }
    public class GamePieceIdNotFoundException : Exception { }
    public class GameBoardSpaceIdNotFoundException : Exception { }
    public class DuplicatePlayerIdException : Exception { }
    public class DuplicateGamePieceIdException : Exception { }
    public class DuplicateGameBoardSpaceIdException : Exception { }

    [Route("api/[controller]")]
    public abstract class GameController : GameObjectController
    {
        private IGameRepository _gameRepository;
        private IGame _game; 
        public GameController(IGameRepository gameRepository, IStatePropertyRepository statePropertyRepository, IGame game) : base(gameRepository, statePropertyRepository, game) {
            _gameRepository = gameRepository;
            _game = game;
        }

        // GET api/game/AddPlayerIdToGame/12345/2345
        [HttpGet("AddPlayerIdToGame/{playerId}/{gameId}")]
        public IActionResult AddPlayerIdToGame(Guid playerId, Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);

            if (!(game.PlayerIds.Contains(playerId)))
            {
                game.PlayerIds.Add(playerId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicatePlayerIdException();
            }
            return new NoContentResult();
        }

        [HttpGet("GameContainsPlayerId/{gameId}/{playerId}")]
        public IActionResult GameContainsPlayerId(Guid gameId, Guid playerId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);

            return new JsonResult(game.PlayerIds.Contains(playerId));
        }

        // GET api/game/RemovePlayerIdFromGame/12345/2345
        [HttpGet("RemovePlayerIdFromGame/{playerId}/{gameId}")]
        public IActionResult RemovePlayerIdFromGame(Guid playerId, Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);

            if (game.PlayerIds.Contains(playerId))
            {
                game.PlayerIds.Remove(playerId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new PlayerIdNotFoundException();
            }
            return new NoContentResult();
        }

        // GET api/game/AddGamePieceIdToGame/12345/2345
        [HttpGet("AddGamePieceIdToGame/{gamePieceId}/{gameId}")]
        public IActionResult AddGamePieceIdToGame(Guid gamePieceId, Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);

            if (!(game.GamePieceIds.Contains(gamePieceId)))
            {
                game.GamePieceIds.Add(gamePieceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicateGamePieceIdException();
            }
            return new NoContentResult();
        }

        [HttpGet("GameContainsGamePieceId/{gameId}/{gamePieceId}")]
        public IActionResult GameContainsGamePieceId(Guid gameId, Guid gamePieceId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);

            return new JsonResult(game.GamePieceIds.Contains(gamePieceId));
        }

        // GET api/game/RemoveGamePieceIdFromGame/12345/2345
        [HttpGet("RemoveGamePieceIdFromGame/{gamePieceId}/{gameId}")]
        public IActionResult RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            if (game.GamePieceIds.Contains(gamePieceId))
            {
                game.GamePieceIds.Remove(gamePieceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new GamePieceIdNotFoundException();
            }
            return new NoContentResult();
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("AddGameBoardSpaceIdToGame/{gameBoardSpaceId}/{gameId}")]
        public IActionResult AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            if (!(game.GameBoardSpaceIds.Contains(gameBoardSpaceId)))
            {
                game.GameBoardSpaceIds.Add(gameBoardSpaceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicateGameBoardSpaceIdException();
            }
            return new NoContentResult();
        }

        [HttpGet("GameContainsGameBoardSpaceId/{gameId}/{gameBoardSpaceId}")]
        public bool GameContainsGameBoardSpaceId(Guid gameId, Guid gameBoardSpaceId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);

            return game.GameBoardSpaceIds.Contains(gameBoardSpaceId);
        }

        // GET api/game/RemoveGameBoardSpaceIdFromGame/12345/2345
        [HttpGet("RemoveGameBoardSpaceIdFromGame/{gameBoardSpaceId}/{gameId}")]
        public IActionResult RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            if (game.GameBoardSpaceIds.Contains(gameBoardSpaceId))
            {
                game.GameBoardSpaceIds.Remove(gameBoardSpaceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new GameBoardSpaceIdNotFoundException();
            }

            return new NoContentResult();

        }

        /*
        [HttpGet("EndGame/{gameId}")]
        public void EndGame(Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            game.EndTime = DateTime.UtcNow;
            _gameRepository.Save(game);
        }

        [HttpGet("StartGame/{gameId}")]
        public void StartGame(Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            game.StartTime = DateTime.UtcNow;
            _gameRepository.Save(game);
        }
        */

        [HttpGet("SetGameBoardId/{gameId}/{gameBoardId}")]
        public IActionResult SetGameBoardId(Guid gameId, Guid gameBoardId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            game.GameBoardId = gameBoardId;
            return new NoContentResult();
        }

        [HttpGet("GetGameBoardId/{gameId}")]
        public IActionResult GetGameBoardId(Guid gameId)
        {
            IGame game = (IGame)_gameRepository.Get(gameId);
            return new JsonResult(game.GameBoardId);
        }
    }
}
