using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MrPitiful.BoardGame.Base.Models;

namespace MrPitiful.BoardGame.Base.Test
{
    //now we can run our unit tests against Generic Game!
    public class GameTests
    {

        [Fact]
        public void GameTest()
        {
            //check to make sure game collections were initialized
            GenericGame game = new GenericGame();
            Assert.NotNull(game.GameBoardSpaceIds);
            Assert.NotNull(game.GamePieceIds);
            Assert.NotNull(game.PlayerIds);
            Assert.NotNull(game.State);
        }
        [Fact]
        public void GameBoardSpaceIdsTest()
        {
            //test get / set of GenericGame.GameBoardSpaceIds;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            GenericGame game = new GenericGame();
            List<Guid> gameBoardSpaceIds = new List<Guid>();
            game.GameBoardSpaceIds = gameBoardSpaceIds;
            Assert.Same(gameBoardSpaceIds, game.GameBoardSpaceIds);
        }
        [Fact]
        public void GamePieceIdsTest()
        {
            //test get / set of GenericGame.GamePieceIdsTest;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            GenericGame game = new GenericGame();
            List<Guid> gamePieceIds = new List<Guid>();
            game.GamePieceIds = gamePieceIds;
            Assert.Same(gamePieceIds, game.GamePieceIds);
        }
        [Fact]
        public void IdTest()
        {
            //test get / set of GenericGame.Id;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            GenericGame game = new GenericGame();
            Guid id = Guid.NewGuid();
            game.Id = id;
            Assert.Equal<Guid>(id, game.Id);
        }
        [Fact]
        public void PlayerIdsTest()
        {
            //test get / set of GenericGame.PlayerIds;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            GenericGame game = new GenericGame();
            List<Guid> playerIds = new List<Guid>();
            game.PlayerIds = playerIds;
            Assert.Same(playerIds, game.PlayerIds);
        }
        [Fact]
        public void StartTimeTest()
        {
            //test get / set of GenericGame.StartTime;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            GenericGame game = new GenericGame();
            DateTime startTime = new DateTime(1980, 12, 09);
            game.StartTime = startTime;
            Assert.Equal(startTime, game.StartTime);
        }
        [Fact]
        public void EndTimeTest()
        {
            //test get / set of GenericGame.EndTime;
            Dictionary<string, string> gameState = new Dictionary<string, string>();
            GenericGame game = new GenericGame();
            DateTime endTime = new DateTime(1980, 12, 09);
            game.EndTime = endTime;
            Assert.Equal(endTime, game.EndTime);
        }
    }
}
