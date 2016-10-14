using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace MrPitiful.BoardGame.Base
{

  
    [Route("api/[controller]")]
    public abstract class GameBoardController : GameObjectController
    {
        private IGameBoardRepository _gameBoardRepository;
        private GameBoard _gameBoard;

        public GameBoardController(IGameBoardRepository gameBoardRepository, GameBoard gameBoard) : base(gameBoardRepository, gameBoard) {
            _gameBoardRepository = gameBoardRepository;
            _gameBoard = gameBoard;
        }

        /*
        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("SetGameBoardGameId/{gameBoardId}/{gameId}")]
        public async Task SetGameBoardGameId(Guid gameBoardId, Guid gameId)
        {
            GameBoard gameBoard = (GameBoard) await _gameBoardRepository.Get(gameBoardId);
            gameBoard.GameId = gameId;
        }
        */
        /*
        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("GetGameBoardGameId/{gameBoardId}")]
        public Guid GetGameBoardGameId(Guid gameBoardId)
        {
            return ((GameBoard)_gameBoardRepository.Get(gameBoardId)).GameId;
        }
        */

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("AddGameBoardSpaceIdToGameBoard/{gameBoardSpaceId}/{gameBoardId}")]
        public async Task AddGameBoardSpaceIdToGameBoard(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            GameBoard gameBoard = (GameBoard) await _gameBoardRepository.Get(gameBoardId);
            if (!(gameBoard.GameBoardSpaceIds.Contains(gameBoardSpaceId)))
            {
                gameBoard.GameBoardSpaceIds.Add(gameBoardSpaceId);
                await _gameBoardRepository.Save(gameBoard);
            }
            else
            {
                throw new DuplicateGameBoardSpaceIdException();
            }
        }

        [HttpGet("GameBoardContainsGameBoardSpaceId/{gameBoardId}/{gameBoardSpaceId}")]
        public async Task<bool> GameBoardContainsGameBoardSpaceId(Guid gameBoardId, Guid gameBoardSpaceId)
        {
            GameBoard gameBoard = (GameBoard) await _gameBoardRepository.Get(gameBoardId);

            return gameBoard.GameBoardSpaceIds.Contains(gameBoardSpaceId);
        }

        // GET api/game/RemoveGameBoardSpaceIdFromGame/12345/2345
        [HttpGet("RemoveGameBoardSpaceIdFromGameBoard/{gameBoardSpaceId}/{gameBoardId}")]
        public async Task RemoveGameBoardSpaceIdFromGameBoard(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            GameBoard gameBoard = (GameBoard) await _gameBoardRepository.Get(gameBoardId);
            if (gameBoard.GameBoardSpaceIds.Contains(gameBoardSpaceId))
            {
                gameBoard.GameBoardSpaceIds.Remove(gameBoardSpaceId);
                await _gameBoardRepository.Save(gameBoard);
            }
            else
            {
                throw new GameBoardSpaceIdNotFoundException();
            }

        }

    }
}
