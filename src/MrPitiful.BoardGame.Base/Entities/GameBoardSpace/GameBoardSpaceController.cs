using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace MrPitiful.BoardGame.Base
{

  
    [Route("api/[controller]")]
    public abstract class GameBoardSpaceController : GameObjectController
    {
        private IGameBoardSpaceRepository _gameBoardSpaceRepository;
        private GameBoardSpace _gameBoardSpace;

        public GameBoardSpaceController(IGameBoardSpaceRepository gameBoardSpaceRepository, GameBoardSpace gameBoardSpace) : base(gameBoardSpaceRepository, gameBoardSpace) {
            _gameBoardSpaceRepository = gameBoardSpaceRepository;
            _gameBoardSpace = gameBoardSpace;
        }

        //Add remove verify pieceIds
        [HttpGet("AddGamePieceIdToGameBoardSpace/{gamePieceId}/{gameBoardSpaceId}")]
        public async Task AddGamePieceIdToGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);

            if (!(gameBoardSpace.GamePieceIds.Contains(gamePieceId)))
            {
                gameBoardSpace.GamePieceIds.Add(gamePieceId);
                await _gameBoardSpaceRepository.Save(gameBoardSpace);
            }
            else
            {
                throw new DuplicateGamePieceIdException();
            }
        }

        [HttpGet("GameBoardSpaceContainsGamePieceId/{gameBoardSpaceId}/{gamePieceId}")]
        public async Task<bool> GameBoardSpaceContainsGamePieceId(Guid gameBoardSpaceId, Guid gamePieceId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);

            return gameBoardSpace.GamePieceIds.Contains(gamePieceId);
        }

        [HttpGet("RemoveGamePieceIdFromGameBoardSpace/{gamePieceId}/{gameBoardSpaceId}")]
        public async Task RemoveGamePieceIdFromGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);
            if (gameBoardSpace.GamePieceIds.Contains(gamePieceId))
            {
                gameBoardSpace.GamePieceIds.Remove(gamePieceId);
                await _gameBoardSpaceRepository.Save(gameBoardSpace);
            }
            else
            {
                throw new GamePieceIdNotFoundException();
            }
        }

        //Add remove verify adjacentSpaces
        [HttpGet("AddAdjacentSpaceToGameBoardSpace/{direction}/{adjacentSpaceId}/{gameBoardSpaceId}")]
        public async Task AddAdjacentSpaceToGameBoardSpace(string direction, Guid adjacentSpaceId, Guid gameBoardSpaceId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);

            gameBoardSpace.AdjacentSpaceIds[direction] = adjacentSpaceId;
            await _gameBoardSpaceRepository.Save(gameBoardSpace);
        }

        [HttpGet("RemoveAdjacentSpaceFromGameBoardSpace/{direction}/{gameBoardSpaceId}")]
        public async Task RemoveAdjacentSpaceFromGameBoardSpace(string direction, Guid gameBoardSpaceId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);
            gameBoardSpace.AdjacentSpaceIds.Remove(direction);
            await _gameBoardSpaceRepository.Save(gameBoardSpace);
        }

        [HttpGet("GetAdjacentSpaceIdByDirection/{gameBoardSpaceId}/{direction}")]
        public async Task<Guid> GetAdjacentSpaceIdByDirection(Guid gameBoardSpaceId, string direction)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);
            return gameBoardSpace.AdjacentSpaceIds[direction];
        }

        /*
         * This is a list because depending on the shape of the board 
         * (which could even be non-euclidian/escher-esque) 
         * a single adjacent space may exist in multiple directions.
         */
        [HttpGet("GetDirectionsByAdjacentSpaceId/{gameBoardSpaceId}/{adjacentSpaceId}")]
        public async Task<List<string>> GetDirectionsByAdjacentSpaceId(Guid gameBoardSpaceId, Guid adjacentSpaceId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);
            List<string> adjacentSpaces = new List<string>();

            if (gameBoardSpace.AdjacentSpaceIds.ContainsValue(adjacentSpaceId))
            {
                foreach (KeyValuePair<string,Guid> adjacentSpace in gameBoardSpace.AdjacentSpaceIds)
                {
                    if (adjacentSpace.Value == adjacentSpaceId)
                    {
                        adjacentSpaces.Add(adjacentSpace.Key);
                    }
                } 
            }
            return adjacentSpaces;
        }

        [HttpGet("SetGameBoardSpaceGameId/{gameBoardSpaceId}/{gameId}")]
        public async Task SetGameBoardSpaceGameId(Guid gameBoardSpaceId, Guid gameId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);
            gameBoardSpace.GameId = gameId;
        }

        [HttpGet("GetGameBoardSpaceGameId/{gameBoardSpaceId}")]
        public async Task<Guid> GetGameBoardSpaceGameId(Guid gameBoardSpaceId)
        {
            return ((GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId)).GameId;
        }

        [HttpGet("SetGameBoardSpaceGameBoardId/{gameBoardSpaceId}/{gameBoardId}")]
        public async Task SetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            GameBoardSpace gameBoardSpace = (GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId);
            gameBoardSpace.GameBoardId = gameBoardId;
        }

        [HttpGet("GetGameBoardSpaceGameBoardId/{gameBoardSpaceId}")]
        public async Task<Guid> GetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId)
        {
            return ((GameBoardSpace) await _gameBoardSpaceRepository.Get(gameBoardSpaceId)).GameBoardId;
        }

        [HttpGet("GetGameBoardSpaceGamePieceIds/{gameBoardSpaceId}")]
        public async Task<ActionResult> GetGameBoardSpaceGamePieceIds(Guid gameBoardSpaceId)
        {
            return new ObjectResult(
                ((GameBoardSpace)(await _gameBoardSpaceRepository.Get(gameBoardSpaceId))).GamePieceIds
                );       
        }


    }
}
