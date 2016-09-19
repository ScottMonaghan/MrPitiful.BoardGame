using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace MrPitiful.BoardGame.Base
{

  
    [Route("api/[controller]")]
    public abstract class GameBoardSpaceController : GameObjectController
    {
        private IGameBoardSpaceRepository _gameBoardSpaceRepository;
        private IGameBoardSpace _gameBoardSpace;

        public GameBoardSpaceController(IGameBoardSpaceRepository gameBoardSpaceRepository, IGameBoardSpace gameBoardSpace) : base(gameBoardSpaceRepository, gameBoardSpace) {
            _gameBoardSpaceRepository = gameBoardSpaceRepository;
            _gameBoardSpace = gameBoardSpace;
        }

        //Add remove verify pieceIds
        [HttpGet("AddGamePieceIdToGameBoardSpace/{gamePieceId}/{gameBoardSpaceId}")]
        public void AddGamePieceIdToGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);

            if (!(gameBoardSpace.GamePieceIds.Contains(gamePieceId)))
            {
                gameBoardSpace.GamePieceIds.Add(gamePieceId);
                _gameBoardSpaceRepository.Save(gameBoardSpace);
            }
            else
            {
                throw new DuplicateGamePieceIdException();
            }
        }

        [HttpGet("GameBoardSpaceContainsGamePieceId/{gameBoardSpaceId}/{gamePieceId}")]
        public bool GameBoardSpaceContainsGamePieceId(Guid gameBoardSpaceId, Guid gamePieceId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);

            return gameBoardSpace.GamePieceIds.Contains(gamePieceId);
        }

        [HttpGet("RemoveGamePieceIdFromGameBoardSpace/{gamePieceId}/{gameBoardSpaceId}")]
        public void RemoveGamePieceIdFromGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);
            if (gameBoardSpace.GamePieceIds.Contains(gamePieceId))
            {
                gameBoardSpace.GamePieceIds.Remove(gamePieceId);
                _gameBoardSpaceRepository.Save(gameBoardSpace);
            }
            else
            {
                throw new GamePieceIdNotFoundException();
            }
        }

        //Add remove verify adjacentSpaces
        [HttpGet("AddAdjacentSpaceToGameBoardSpace/{direction}/{adjacentSpaceId}/{gameBoardSpaceId}")]
        public void AddAdjacentSpaceToGameBoardSpace(string direction, Guid adjacentSpaceId, Guid gameBoardSpaceId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);

            gameBoardSpace.AdjacentSpaceIds[direction] = adjacentSpaceId;
        }

        [HttpGet("RemoveAdjacentSpaceFromGameBoardSpace/{direction}/{gameBoardSpaceId}")]
        public void RemoveAdjacentSpaceFromGameBoardSpace(string direction, Guid gameBoardSpaceId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);
            gameBoardSpace.AdjacentSpaceIds.Remove(direction);
        }

        [HttpGet("GetAdjacentSpaceIdByDirection/{gameBoardSpaceId}/{direction}")]
        public Guid GetAdjacentSpaceIdByDirection(Guid gameBoardSpaceId, string direction)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);
            return gameBoardSpace.AdjacentSpaceIds[direction];
        }

        /*
         * This is a list because depending on the shape of the board 
         * (which could even be non-euclidian/escher-esque) 
         * a single adjacent space may exist in multiple directions.
         */
        [HttpGet("GetDirectionsByAdjacentSpaceId/{gameBoardSpaceId}/{adjacentSpaceId}")]
        public List<string> GetDirectionsByAdjacentSpaceId(Guid gameBoardSpaceId, string direction)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);
            List<string> adjacentSpaces = new List<string>();

            if (gameBoardSpace.AdjacentSpaceIds.ContainsValue(gameBoardSpaceId))
            {
                foreach (KeyValuePair<string,Guid> adjacentSpace in gameBoardSpace.AdjacentSpaceIds)
                {
                    if (adjacentSpace.Value == gameBoardSpaceId)
                    {
                        adjacentSpaces.Add(adjacentSpace.Key);
                    }
                } 
            }
            return adjacentSpaces;
        }

        [HttpGet("SetGameBoardSpaceGameId/{gameBoardSpaceId}/{gameId}")]
        public void SetGameBoardSpaceGameId(Guid gameBoardSpaceId, Guid gameId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);
            gameBoardSpace.GameId = gameId;
        }

        [HttpGet("GetGameBoardSpaceGameId/{gameBoardSpaceId}")]
        public Guid GetGameBoardSpaceGameId(Guid gameBoardSpaceId)
        {
            return ((IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId)).GameId;
        }

        [HttpGet("SetGameBoardSpaceGameBoardId/{gameBoardSpaceId}/{gameBoardId}")]
        public void SetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            IGameBoardSpace gameBoardSpace = (IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId);
            gameBoardSpace.GameBoardId = gameBoardId;
        }

        [HttpGet("GetGameBoardSpaceGameBoardId/{gameBoardSpaceId}")]
        public Guid GetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId)
        {
            return ((IGameBoardSpace)_gameBoardSpaceRepository.Get(gameBoardSpaceId)).GameBoardId;
        }
    }
}
