﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace MrPitiful.BoardGame.Base
{

  
    [Route("api/[controller]")]
    public abstract class GameBoardController : GameObjectController
    {
        private IGameBoardRepository _gameBoardRepository;
        private IGameBoard _gameBoard;

        public GameBoardController(IGameBoardRepository gameBoardRepository, IStatePropertyRepository statePropertyRepository, IGameBoard gameBoard) : base(gameBoardRepository, statePropertyRepository, gameBoard) {
            _gameBoardRepository = gameBoardRepository;
            _gameBoard = gameBoard;
        }

        // GET api/game/AddGameBoardSpaceIdToGame/12345/2345
        [HttpGet("AddGameBoardSpaceIdToGameBoard/{gameBoardSpaceId}/{gameBoardId}")]
        public void AddGameBoardSpaceIdToGameBoard(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            IGameBoard gameBoard = (IGameBoard)_gameBoardRepository.Get(gameBoardId);
            if (!(gameBoard.GameBoardSpaceIds.Contains(gameBoardSpaceId)))
            {
                gameBoard.GameBoardSpaceIds.Add(gameBoardSpaceId);
                _gameBoardRepository.Save(gameBoard);
            }
            else
            {
                throw new DuplicateGameBoardSpaceIdException();
            }
        }

        [HttpGet("GameBoardContainsGameBoardSpaceId/{gameBoardId}/{gameBoardSpaceId}")]
        public bool GameBoardContainsGameBoardSpaceId(Guid gameBoardId, Guid gameBoardSpaceId)
        {
            IGameBoard gameBoard = (IGameBoard)_gameBoardRepository.Get(gameBoardId);

            return gameBoard.GameBoardSpaceIds.Contains(gameBoardSpaceId);
        }

        // GET api/game/RemoveGameBoardSpaceIdFromGame/12345/2345
        [HttpGet("RemoveGameBoardSpaceIdFromGameBoard/{gameBoardSpaceId}/{gameBoardId}")]
        public void RemoveGameBoardSpaceIdFromGameBoard(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            IGameBoard gameBoard = (IGameBoard)_gameBoardRepository.Get(gameBoardId);
            if (gameBoard.GameBoardSpaceIds.Contains(gameBoardSpaceId))
            {
                gameBoard.GameBoardSpaceIds.Remove(gameBoardSpaceId);
                _gameBoardRepository.Save(gameBoard);
            }
            else
            {
                throw new GameBoardSpaceIdNotFoundException();
            }

        }

    }
}