using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameClient<TGame>:IGameObjectClient<TGame>
        where TGame:IGame
    {
        //playerIds
        Task AddPlayerIdToGame(Guid playerId, Guid gameId);
        Task<bool> GameContainsPlayerId(Guid gameId, Guid playerId);
        Task RemovePlayerIdFromGame(Guid playerId, Guid gameId);

        //gamePieceIds
        Task AddGamePieceIdToGame(Guid gamePieceId, Guid gameId);
        Task<bool> GameContainsGamePieceId(Guid gameId, Guid gamePieceId);
        Task RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId);

        //gameBoardSpaceIds
        Task AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId);
        Task<bool> GameContainsGameBoardSpaceId(Guid gameId, Guid gameBoardSpaceId);
        Task RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId);

        //gameBoard
        Task SetGameBoard(Guid gameId, Guid gameBoardId);
        Task<Guid> GetGameBoardId(Guid gameId);
    }
}
