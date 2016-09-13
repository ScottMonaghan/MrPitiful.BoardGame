using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Interfaces;

namespace MrPitiful.BoardGame.Game
{
    public class GameNotFoundException : Exception {}
    public class PlayerIdNotFoundException : Exception { }
    public class GamePieceIdNotFoundException : Exception { }
    public class GameBoardSpaceIdNotFoundException : Exception { }
    public class DuplicatePlayerIdException : Exception {}
    public class DuplicateGamePieceException : Exception { }
    public class DuplicateGameBoardSpaceException : Exception { }

    public class GameService : IGameService
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
                throw new DuplicateGamePieceException();
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
                throw new DuplicateGameBoardSpaceException();
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
            throw new NotImplementedException();
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

        public void StartGame(IGame game)
        {
            throw new NotImplementedException();
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
