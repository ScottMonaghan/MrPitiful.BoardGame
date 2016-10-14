using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameBoardSpaceClient<TGameBoardSpace>:IGameObjectClient<TGameBoardSpace>
        where TGameBoardSpace:GameBoardSpace
    {
        //gamePieceIds
        Task AddGamePieceIdToGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId);
        Task<bool> GameBoardSpaceContainsGamePieceId(Guid gameBoardSpaceId, Guid gamePieceId);
        Task RemoveGamePieceIdFromGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId);
        Task AddAdjacentSpaceToGameBoardSpace(string direction, Guid adjacentSpaceId, Guid gameBoardSpaceId);
        Task RemoveAdjacentSpaceFromGameBoardSpace(string direction, Guid gameBoardSpaceId);
        Task<Guid> GetAdjacentSpaceIdByDirection(Guid gameBoardSpaceId, string direction);
        Task<List<string>> GetDirectionsByAdjacentSpaceId(Guid gameBoardSpaceId, Guid adjacentSpaceId);
        Task SetGameBoardSpaceGameId(Guid gameBoardSpaceId, Guid gameId);
        Task<Guid> GetGameBoardSpaceGameId(Guid gameBoardSpaceId);
        Task SetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId, Guid gameBoardId);
        Task<Guid> GetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId);
        Task<List<Guid>> GetGameBoardSpaceGamePieceIds(Guid gameBoardSpaceId);
    }
}
