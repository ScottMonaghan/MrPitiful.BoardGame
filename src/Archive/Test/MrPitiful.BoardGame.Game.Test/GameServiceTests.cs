using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MrPitiful.BoardGame.Game;
using MrPitiful.BoardGame.Interfaces;

namespace MrPitiful.BoardGame.Game.Test
{
    public class MockGameRepository : IGameRepository
    {
        public bool Saved = false;

        IGame IGameRepository.Create(IGame game)
        {
            return game;
        }

        void IGameRepository.Delete(IGame game)
        {
            //do nothing
        }

        IDictionary<Guid, IGame> IGameRepository.Get()
        {
            return new Dictionary<Guid, IGame>();
        }

        IGame IGameRepository.Get(Guid Id)
        {
            Game game = new Game(new Dictionary<string, string>());
            game.Id = Id;
            return game;
        }

        void IGameRepository.Save(IGame game)
        {
            Saved = true;
        }
    }

    public class GameServiceTests
    {

        [Fact]
        public void GameServiceTest()
        {
            //test gameservice constructor.  Only no exceptions expected.
            MockGameRepository gameRepository = new MockGameRepository();
            GameService gameService = new GameService(gameRepository);
        }
        
        [Fact]
        public void CreateTest()
        {
            //test to see if gameRepository.Create is run.  Injected game should be the same as returned game.
            MockGameRepository gameRepository = new MockGameRepository();
            GameService gameService = new GameService(gameRepository);
            Game injectedGame = new Game(new Dictionary<string, string>());
            Game createdGame = (Game)(gameService.Create(injectedGame));
            Assert.Same(injectedGame, createdGame);
        }
        
        [Fact]
        public void GetTest()
        {
            //should return a dictionary of IGame
            MockGameRepository gameRepository = new MockGameRepository();
            GameService gameService = new GameService(gameRepository);
            Assert.IsType(typeof(Dictionary<Guid, IGame>), gameService.Get());
        }

        [Fact]
        public void AddGamePieceIdToGameTest()
        {
            //the added gamepiece id should exist in Game.GamePieceIds
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gamePieceId = Guid.NewGuid();
            gameService.AddGamePieceIdToGame(gamePieceId, game);
            Assert.True(game.GamePieceIds.Contains(gamePieceId));
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void DuplicatePieceIdExceptionTest()
        {
            //the added gamepiece id should exist in Game.GamePieceIds
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gamePieceId = Guid.NewGuid();
            gameService.AddGamePieceIdToGame(gamePieceId, game);
            Assert.Throws<DuplicateGamePieceIdException>(()=>{
                gameService.AddGamePieceIdToGame(gamePieceId, game);
            });
        }

        [Fact]
        public void RemoveGamePieceIdFromGameTest()
        {
            //the added gamepiece should exist in the collection, and then be removed
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gamePieceId = Guid.NewGuid();
            gameService.AddGamePieceIdToGame(gamePieceId, game);
            Assert.True(game.GamePieceIds.Contains(gamePieceId));
            gameService.RemoveGamePieceIdFromGame(gamePieceId, game);
            Assert.False(game.GamePieceIds.Contains(gamePieceId));
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void GamePieceIdNotFoundExceptionTest()
        {
            //the asking for a non-existent GamePieceId should throw a GamePieceIdNotFoundException
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gamePieceId = Guid.NewGuid();
            Assert.Throws<GamePieceIdNotFoundException>(() => {
                gameService.RemoveGamePieceIdFromGame(gamePieceId, game);
            });
        }

        [Fact]
        public void AddGameBoardspaceIdToGameTest()
        {
            //the added gameBoardSpaceId should exist in Game.GameBoardspaceIds
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gameBoardSpaceId = Guid.NewGuid();
            gameService.AddGameBoardSpaceIdToGame(gameBoardSpaceId, game);
            Assert.True(game.GameBoardSpaceIds.Contains(gameBoardSpaceId));
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void DuplicateGameBoardSpaceIdExceptionTest()
        {
            //the added duplicate gameboardspaceid should throw an exception
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gameBoardSpaceId = Guid.NewGuid();
            gameService.AddGameBoardSpaceIdToGame(gameBoardSpaceId, game);
            Assert.True(game.GameBoardSpaceIds.Contains(gameBoardSpaceId));
            Assert.Throws<DuplicateGameBoardSpaceIdException>(() => {
                gameService.AddGameBoardSpaceIdToGame(gameBoardSpaceId, game);
            });
        }

        [Fact]
        public void RemoveGameBoardSpaceIdFromGameTest()
        {
            //the added gamepiece should exist in the collection, and then be removed
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gameBoardSpaceId = Guid.NewGuid();
            gameService.AddGameBoardSpaceIdToGame(gameBoardSpaceId, game);
            Assert.True(game.GameBoardSpaceIds.Contains(gameBoardSpaceId));
            gameService.RemoveGameBoardSpaceIdFromGame(gameBoardSpaceId, game);
            Assert.False(game.GameBoardSpaceIds.Contains(gameBoardSpaceId));
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void GameBoardSpaceIdNotFoundExceptionTest()
        {
            //the asking for a non-existent GameBoardSpaceId should throw a GameBoardSpaceIdNotFoundException
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid gameBoardSpaceId = Guid.NewGuid();
            Assert.Throws<GameBoardSpaceIdNotFoundException>(() => {
                gameService.RemoveGameBoardSpaceIdFromGame(gameBoardSpaceId, game);
            });
        }

        [Fact]
        public void AddPlayerIdToGameTest()
        {
            //the added PlayerId should exist in Game.PlayerIds
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid PlayerId = Guid.NewGuid();
            gameService.AddPlayerIdToGame(PlayerId, game);
            Assert.True(game.PlayerIds.Contains(PlayerId));
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void DuplicatePlayerIdExceptionTest()
        {
            //the added duplicate gameboardspaceid should throw an exception
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid PlayerId = Guid.NewGuid();
            gameService.AddPlayerIdToGame(PlayerId, game);
            Assert.True(game.PlayerIds.Contains(PlayerId));
            Assert.Throws<DuplicatePlayerIdException>(() => {
                gameService.AddPlayerIdToGame(PlayerId, game);
            });
        }

        [Fact]
        public void RemovePlayerIdFromGameTest()
        {
            //the added gamepiece should exist in the collection, and then be removed
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid playerId = Guid.NewGuid();
            gameService.AddPlayerIdToGame(playerId, game);
            Assert.True(game.PlayerIds.Contains(playerId));
            gameService.RemovePlayerIdFromGame(playerId, game);
            Assert.False(game.PlayerIds.Contains(playerId));
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void PlayerIdNotFoundExceptionTest()
        {
            //the asking for a non-existent PlayerId should throw a PlayerIdNotFoundException
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            Guid playerId = Guid.NewGuid();
            Assert.Throws<PlayerIdNotFoundException>(() => {
                gameService.RemovePlayerIdFromGame(playerId, game);
            });
        }

        [Fact]
        public void EndGameTest()
        {
            //test that game.EndTime is less than 5 seconds before DateTime.UtcNow;
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            gameService.EndGame(game);
            Assert.True(DateTime.UtcNow.Subtract(game.EndTime).Seconds < 5);
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void StartGameTest()
        {
            //test that game.StartTime is less than 5 seconds before DateTime.UtcNow;
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            gameService.StartGame(game);
            Assert.True(DateTime.UtcNow.Subtract(game.StartTime).Seconds < 5);
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void UpdateGameStatePropertyTest()
        {
            //the added PlayerId should exist in Game.PlayerIds
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            String name = "name";
            String value = "value";
            gameService.UpdateGameStateProperty(game, name, value);
            Assert.Equal(value, game.State[name]);
            Assert.True(gameRepository.Saved);
        }

        [Fact]
        public void GetGameStatePropertyTest()
        {
            //the added PlayerId should exist in Game.PlayerIds
            MockGameRepository gameRepository = new MockGameRepository();
            Game game = new Game(new Dictionary<string, string>());
            GameService gameService = new GameService(gameRepository);
            String name = "name";
            String value = "value";
            gameService.UpdateGameStateProperty(game, name, value);
            Assert.Equal(value, gameService.GetGameStateProperty(game, name));
        }
    }

}
