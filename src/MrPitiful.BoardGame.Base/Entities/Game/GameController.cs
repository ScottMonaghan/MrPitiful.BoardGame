using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        private Game _game; 
        public GameController(IGameRepository gameRepository, Game game) : base(gameRepository, game) {
            _gameRepository = gameRepository;
            _game = game;
        }

        // GET api/game/AddPlayerIdToGame/12345/2345
        [HttpGet("AddPlayerIdToGame/{playerId}/{gameId}")]
        public async Task<IActionResult> AddPlayerIdToGame(Guid playerId, Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);

            if (!(game.PlayerIds.Contains(playerId)))
            {
                game.PlayerIds.Add(playerId);
                await _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicatePlayerIdException();
            }
            return new NoContentResult();
        }

        [HttpGet("GameContainsPlayerId/{gameId}/{playerId}")]
        public async Task<IActionResult> GameContainsPlayerId(Guid gameId, Guid playerId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);

            return new JsonResult(game.PlayerIds.Contains(playerId));
        }

        // GET api/game/RemovePlayerIdFromGame/12345/2345
        [HttpGet("RemovePlayerIdFromGame/{playerId}/{gameId}")]
        public async Task<IActionResult> RemovePlayerIdFromGame(Guid playerId, Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);

            if (game.PlayerIds.Contains(playerId))
            {
                game.PlayerIds.Remove(playerId);
                await _gameRepository.Save(game);
            }
            else
            {
                throw new PlayerIdNotFoundException();
            }
            return new NoContentResult();
        }

        // GET api/game/AddGamePieceIdToGame/12345/2345
        [HttpGet("AddGamePieceIdToGame/{gamePieceId}/{gameId}")]
        public async Task<IActionResult> AddGamePieceIdToGame(Guid gamePieceId, Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);

            if (!(game.GamePieceIds.Contains(gamePieceId)))
            {
                game.GamePieceIds.Add(gamePieceId);
                await _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicateGamePieceIdException();
            }
            return new NoContentResult();
        }

        [HttpGet("GameContainsGamePieceId/{gameId}/{gamePieceId}")]
        public async Task<IActionResult> GameContainsGamePieceId(Guid gameId, Guid gamePieceId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);

            return new JsonResult(game.GamePieceIds.Contains(gamePieceId));
        }

        // GET api/game/RemoveGamePieceIdFromGame/12345/2345
        [HttpGet("RemoveGamePieceIdFromGame/{gamePieceId}/{gameId}")]
        public async Task<IActionResult> RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);
            if (game.GamePieceIds.Contains(gamePieceId))
            {
                game.GamePieceIds.Remove(gamePieceId);
                await _gameRepository.Save(game);
            }
            else
            {
                throw new GamePieceIdNotFoundException();
            }
            return new NoContentResult();
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("AddGameBoardSpaceIdToGame/{gameBoardSpaceId}/{gameId}")]
        public async Task<IActionResult> AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);
            if (!(game.GameBoardSpaceIds.Contains(gameBoardSpaceId)))
            {
                game.GameBoardSpaceIds.Add(gameBoardSpaceId);
                await _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicateGameBoardSpaceIdException();
            }
            return new NoContentResult();
        }

        [HttpGet("GameContainsGameBoardSpaceId/{gameId}/{gameBoardSpaceId}")]
        public async Task<bool> GameContainsGameBoardSpaceId(Guid gameId, Guid gameBoardSpaceId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);

            return game.GameBoardSpaceIds.Contains(gameBoardSpaceId);
        }

        // GET api/game/RemoveGameBoardSpaceIdFromGame/12345/2345
        [HttpGet("RemoveGameBoardSpaceIdFromGame/{gameBoardSpaceId}/{gameId}")]
        public async Task<IActionResult> RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);
            if (game.GameBoardSpaceIds.Contains(gameBoardSpaceId))
            {
                game.GameBoardSpaceIds.Remove(gameBoardSpaceId);
                await _gameRepository.Save(game);
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
            Game game = (Game) await _gameRepository.Get(gameId);
            game.EndTime = DateTime.UtcNow;
            _gameRepository.Save(game);
        }

        [HttpGet("StartGame/{gameId}")]
        public void StartGame(Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);
            game.StartTime = DateTime.UtcNow;
            _gameRepository.Save(game);
        }
        */

        [HttpGet("SetGameBoardId/{gameId}/{gameBoardId}")]
        public async Task<IActionResult> SetGameBoardId(Guid gameId, Guid gameBoardId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);
            game.GameBoardId = gameBoardId;
            return new NoContentResult();
        }

        [HttpGet("GetGameBoardId/{gameId}")]
        public async Task<IActionResult> GetGameBoardId(Guid gameId)
        {
            Game game = (Game) await _gameRepository.Get(gameId);
            return new JsonResult(game.GameBoardId);
        }
    }
}
