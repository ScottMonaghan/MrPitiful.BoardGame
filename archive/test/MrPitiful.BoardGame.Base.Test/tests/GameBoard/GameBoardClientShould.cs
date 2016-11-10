using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameBoardClientShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GameBoardClientShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void AddQueryAndRemoveGameBoardSpaceIds()
        {
            //Arrange 
            //Create new GameBoardClient
            GenericGameBoardClient gameBoardClient
                = new GenericGameBoardClient(_client);

            //Create mock gameBoardSpaceId
            var gameBoardSpaceId = Guid.NewGuid();

            //Create a gameBoard 
            GenericGameBoard createdGameBoard = await gameBoardClient.Create();

            //Ensure GameBoardSpaceId doesn't already exist in gameBoard
            bool gameBoardContainsGameBoardSpaceId = await gameBoardClient.GameBoardContainsGameBoardSpaceId(createdGameBoard.Id, gameBoardSpaceId);
            Assert.False(gameBoardContainsGameBoardSpaceId);

            //Add a player Id to that gameBoard
            await gameBoardClient.AddGameBoardSpaceIdToGameBoard(gameBoardSpaceId, createdGameBoard.Id);

            //Ensure gameBoardSpaceId DID get added to gameBoard
            gameBoardContainsGameBoardSpaceId = await gameBoardClient.GameBoardContainsGameBoardSpaceId(createdGameBoard.Id, gameBoardSpaceId);
            Assert.True(gameBoardContainsGameBoardSpaceId);

            //Now remove GameBoardSpaceId from gameBoard
            await gameBoardClient.RemoveGameBoardSpaceIdFromGameBoard(gameBoardSpaceId, createdGameBoard.Id);

            //Ensure gameBoardSpaceId DID get removed from gameBoard
            gameBoardContainsGameBoardSpaceId = await gameBoardClient.GameBoardContainsGameBoardSpaceId(createdGameBoard.Id, gameBoardSpaceId);
            Assert.False(gameBoardContainsGameBoardSpaceId);
        }

    }
}
