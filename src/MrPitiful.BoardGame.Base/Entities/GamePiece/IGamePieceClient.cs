using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MrPitiful.BoardGame.Base
{
    public interface IGamePieceClient<TGamePiece>:IGameObjectClient<TGamePiece>
        where TGamePiece:IGamePiece
    {
        //game
        Task SetGamePieceGameId(Guid gamePieceId, Guid gameId);
        Task<Guid> GetGamePieceGameId(Guid gamePieceId);

        //gameBoard
        Task SetGamePieceGameBoardId(Guid gamePieceId, Guid gameBoardId);
        Task<Guid> GetGamePieceGameBoardId(Guid gamePieceId);

        //gameBoardSpace
        Task SetGamePieceGameBoardSpaceId(Guid gamePieceId, Guid gameBoardSpaceId);
        Task<Guid> GetGamePieceGameBoardSpaceId(Guid gamePieceId);
    }
}
