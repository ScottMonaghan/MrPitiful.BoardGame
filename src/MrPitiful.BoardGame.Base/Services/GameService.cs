using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Services.Interfaces;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;

namespace MrPitiful.BoardGame.Base.Services
{
    public class GameNotFoundException : Exception {}
    public class PlayerIdNotFoundException : Exception { }
    public class GamePieceIdNotFoundException : Exception { }
    public class GameBoardSpaceIdNotFoundException : Exception { }
    public class DuplicatePlayerIdException : Exception {}
    public class DuplicateGamePieceIdException : Exception { }
    public class DuplicateGameBoardSpaceIdException : Exception { }

    public abstract class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;   
        }

        public IGame Create(IGame game)
        {
            return _gameRepository.Create(game);
        }

        public IDictionary<Guid,IGame> Get(){
            return _gameRepository.Get();
        }

        public IGame Get(Guid id)
        {
            return _gameRepository.Get(id);
        }

        public void AddGamePieceIdToGame(Guid gamePieceId, IGame game)
        {
            if (!(game.GamePieceIds.Contains(gamePieceId))) {
                game.GamePieceIds.Add(gamePieceId);
                _gameRepository.Save(game);
            } else
            {
                throw new DuplicateGamePieceIdException();
            }
        }

        public void AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, IGame game)
        {
            if (!(game.GameBoardSpaceIds.Contains(gameBoardSpaceId))) {
                game.GameBoardSpaceIds.Add(gameBoardSpaceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicateGameBoardSpaceIdException();
            }
        }

        public void AddPlayerIdToGame(Guid playerId, IGame game)
        {
            if (!(game.PlayerIds.Contains(playerId))) {
                game.PlayerIds.Add(playerId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new DuplicatePlayerIdException();
            }
        }

        public void EndGame(IGame game)
        {
            game.EndTime = DateTime.UtcNow;
            _gameRepository.Save(game);
        }

        public void StartGame(IGame game)
        {
            game.StartTime = DateTime.UtcNow;
            _gameRepository.Save(game);
        }

        public void RemoveGamePieceIdFromGame(Guid gamePieceId, IGame game)
        {
            if (game.GamePieceIds.Contains(gamePieceId)) {
                game.GamePieceIds.Remove(gamePieceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new GamePieceIdNotFoundException();
            }
        }

        public void RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, IGame game)
        {
            if (game.GameBoardSpaceIds.Contains(gameBoardSpaceId))
            {
                game.GameBoardSpaceIds.Remove(gameBoardSpaceId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new GameBoardSpaceIdNotFoundException();
            }
        }

        public void RemovePlayerIdFromGame(Guid playerId, IGame game)
        {
            if (game.PlayerIds.Contains(playerId))
            {
                game.PlayerIds.Remove(playerId);
                _gameRepository.Save(game);
            }
            else
            {
                throw new PlayerIdNotFoundException();
            }
        }
 
        public void UpdateGameStateProperty(IGame game, string gameStatePropertyName, string gameStatePropertyValue)
        {
            game.State[gameStatePropertyName] = gameStatePropertyValue;
            _gameRepository.Save(game);
        }

        public string GetGameStateProperty(IGame game, string gameStatePropertyName)
        {
            return game.State[gameStatePropertyName];
        }
    }
}
