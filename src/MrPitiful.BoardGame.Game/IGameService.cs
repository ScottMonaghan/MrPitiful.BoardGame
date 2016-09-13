using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Interfaces;

namespace MrPitiful.BoardGame.Game
{
    public interface IGameService
    {
        IGame Create(IGame game);
        IDictionary<Guid, IGame> Get();
        IGame Get(Guid Id);
        void StartGame(IGame game);
        void EndGame(IGame game);
        void AddPlayerIdToGame(Guid playerId, IGame game);
        void RemovePlayerIdFromGame(Guid playerId, IGame game);
        void AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, IGame game);
        void RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, IGame game);
        void AddGamePieceIdToGame(Guid gamePieceId, IGame game);
        void RemoveGamePieceIdFromGame(Guid gamePieceId, IGame game);
        void UpdateGameStateProperty(IGame game, string gameStatePropertyName, string gameStatePropertyValue);
        string GetGameStateProperty(IGame game, string gameStatePropertyName);
    }
}
