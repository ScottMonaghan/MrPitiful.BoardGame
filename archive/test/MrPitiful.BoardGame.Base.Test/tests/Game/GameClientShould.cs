using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameClientShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GameClientShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void AddQueryAndRemovePlayerIds()
        {
            //Arrange 
            //Create new GameClient
            GenericGameClient gameClient
                = new GenericGameClient(_client);

            //Create mock playerId
            var playerId = Guid.NewGuid();

            //Create a game 
            GenericGame createdGame = await gameClient.Create();

            //Ensure PlayerId doesn't already exist in game
            bool gameContainsPlayerId = await gameClient.GameContainsPlayerId(createdGame.Id, playerId);
            Assert.False(gameContainsPlayerId);

            //Add a player Id to that game
            await gameClient.AddPlayerIdToGame(playerId, createdGame.Id);

            //Ensure playerId DID get added to game
            gameContainsPlayerId = await gameClient.GameContainsPlayerId(createdGame.Id, playerId);
            Assert.True(gameContainsPlayerId);

            //Now remove PlayerId from game
            await gameClient.RemovePlayerIdFromGame(playerId, createdGame.Id);

            //Ensure playerId DID get removed from game
            gameContainsPlayerId = await gameClient.GameContainsPlayerId(createdGame.Id, playerId);
            Assert.False(gameContainsPlayerId);
        }

        [Fact]
        public async void AddQueryAndRemoveGamePieceIds()
        {
            //Arrange 
            //Create new GameClient
            GenericGameClient gameClient
                = new GenericGameClient(_client);

            //Create mock gamePieceId
            var gamePieceId = Guid.NewGuid();

            //Create a game 
            GenericGame createdGame = await gameClient.Create();

            //Ensure GamePieceId doesn't already exist in game
            bool gameContainsGamePieceId = await gameClient.GameContainsGamePieceId(createdGame.Id, gamePieceId);
            Assert.False(gameContainsGamePieceId);

            //Add a player Id to that game
            await gameClient.AddGamePieceIdToGame(gamePieceId, createdGame.Id);

            //Ensure gamePieceId DID get added to game
            gameContainsGamePieceId = await gameClient.GameContainsGamePieceId(createdGame.Id, gamePieceId);
            Assert.True(gameContainsGamePieceId);

            //Now remove GamePieceId from game
            await gameClient.RemoveGamePieceIdFromGame(gamePieceId, createdGame.Id);

            //Ensure gamePieceId DID get removed from game
            gameContainsGamePieceId = await gameClient.GameContainsGamePieceId(createdGame.Id, gamePieceId);
            Assert.False(gameContainsGamePieceId);
        }

        [Fact]
        public async void AddQueryAndRemoveGameBoardSpaceIds()
        {
            //Arrange 
            //Create new GameClient
            GenericGameClient gameClient
                = new GenericGameClient(_client);

            //Create mock gameBoardSpaceId
            var gameBoardSpaceId = Guid.NewGuid();

            //Create a game 
            GenericGame createdGame = await gameClient.Create();

            //Ensure GameBoardSpaceId doesn't already exist in game
            bool gameContainsGameBoardSpaceId = await gameClient.GameContainsGameBoardSpaceId(createdGame.Id, gameBoardSpaceId);
            Assert.False(gameContainsGameBoardSpaceId);

            //Add a player Id to that game
            await gameClient.AddGameBoardSpaceIdToGame(gameBoardSpaceId, createdGame.Id);

            //Ensure gameBoardSpaceId DID get added to game
            gameContainsGameBoardSpaceId = await gameClient.GameContainsGameBoardSpaceId(createdGame.Id, gameBoardSpaceId);
            Assert.True(gameContainsGameBoardSpaceId);

            //Now remove GameBoardSpaceId from game
            await gameClient.RemoveGameBoardSpaceIdFromGame(gameBoardSpaceId, createdGame.Id);

            //Ensure gameBoardSpaceId DID get removed from game
            gameContainsGameBoardSpaceId = await gameClient.GameContainsGameBoardSpaceId(createdGame.Id, gameBoardSpaceId);
            Assert.False(gameContainsGameBoardSpaceId);
        }

        [Fact]
        public async void SetAndGetGameBoardId()
        {
            //Arrange 
            //Create new GameClient
            GenericGameClient gameClient
                = new GenericGameClient(_client);

            //create dummy gameBoardId
            Guid gameBoardId = Guid.NewGuid();

            //Create a game 
            GenericGame createdGame = await gameClient.Create();

            //setGameBoardId
            await gameClient.SetGameBoardId(createdGame.Id, gameBoardId);

            //getGameBoardId
            Guid gotGameBoardId = await gameClient.GetGameBoardId(createdGame.Id);

            //make sure gotGameBoardId == gameBoardId
            Assert.Equal(gotGameBoardId, gameBoardId);
        }
    }
}
