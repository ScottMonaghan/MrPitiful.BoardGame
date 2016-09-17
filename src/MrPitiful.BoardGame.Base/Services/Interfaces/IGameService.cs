using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.BoardGame.Base.Services.Interfaces
{
    public interface IGameService:IGameObjectService
    {
        void StartGame(IGame game);
        void EndGame(IGame game);
        void AddPlayerIdToGame(Guid playerId, IGame game);
        void RemovePlayerIdFromGame(Guid playerId, IGame game);
        void AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, IGame game);
        void RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, IGame game);
        void AddGamePieceIdToGame(Guid gamePieceId, IGame game);
        void RemoveGamePieceIdFromGame(Guid gamePieceId, IGame game);
    }
}
