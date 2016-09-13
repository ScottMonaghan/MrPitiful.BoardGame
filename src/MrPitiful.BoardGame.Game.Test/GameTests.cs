using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MrPitiful.BoardGame.Game;

namespace MrPitiful.BoardGame.Game.Test
{
    public class GameTests
    {

        [Fact]
        public void GameTest()
        {
            //test contstructor and verify gameState is properly injected
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            Assert.Same(gameState, game.State);
        }
        [Fact]
        public void GameBoardSpaceIdsTest()
        {
            //test get / set of Game.GameBoardSpaceIds;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            List<Guid> gameBoardSpaceIds = new List<Guid>();
            game.GameBoardSpaceIds = gameBoardSpaceIds;
            Assert.Same(gameBoardSpaceIds, game.GameBoardSpaceIds);
        }
        [Fact]
        public void GamePieceIdsTest()
        {
            //test get / set of Game.GamePieceIdsTest;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            List<Guid> gamePieceIds = new List<Guid>();
            game.GamePieceIds = gamePieceIds;
            Assert.Same(gamePieceIds, game.GamePieceIds);
        }
        [Fact]
        public void IdTest()
        {
            //test get / set of Game.Id;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            Guid id = Guid.NewGuid();
            game.Id = id;
            Assert.Equal<Guid>(id, game.Id);
        }
        [Fact]
        public void PlayerIdsTest()
        {
            //test get / set of Game.PlayerIds;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            List<Guid> playerIds = new List<Guid>();
            game.PlayerIds = playerIds;
            Assert.Same(playerIds, game.PlayerIds);
        }
        [Fact]
        public void StartTimeTest()
        {
            //test get / set of Game.StartTime;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            DateTime startTime = new DateTime(1980, 12, 09);
            game.StartTime = startTime;
            Assert.Equal(startTime, game.StartTime);
        }
        [Fact]
        public void EndTimeTest()
        {
            //test get / set of Game.EndTime;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            Game game = new Game(gameState);
            DateTime endTime = new DateTime(1980, 12, 09);
            game.EndTime = endTime;
            Assert.Equal(endTime, game.EndTime);
        }
    }
}
