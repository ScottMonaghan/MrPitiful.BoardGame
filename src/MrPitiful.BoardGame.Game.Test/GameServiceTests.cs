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
            //do nothing
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
        }
}

}
