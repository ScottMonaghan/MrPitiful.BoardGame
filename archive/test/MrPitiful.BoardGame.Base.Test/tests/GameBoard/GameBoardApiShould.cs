using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameBoardApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameBoardApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void AddQueryAndRemoveGameBoardSpaceIds()
        {
            //Arrange
            bool result;
            var gameBoardSpaceId = Guid.NewGuid();

            //Create a game
            var response = await _client.GetAsync("/api/genericGameBoard/create");
            GenericGameBoard createdGameBoard = JsonConvert.DeserializeObject<GenericGameBoard>(
                    await response.Content.ReadAsStringAsync()
                );
            response.Dispose();

            //Act
            //Ensure GameBoardSpaceId doesn't already exist in game
            response = await _client.GetAsync(String.Format("/api/genericGameBoard/GameBoardContainsGameBoardSpaceId/{0}/{1}", createdGameBoard.Id, gameBoardSpaceId));
            result = JsonConvert.DeserializeObject<bool>(
                    await response.Content.ReadAsStringAsync()
                );
            response.Dispose();
            Assert.False(result);

            //Add a GameBoardSpaceId to that GameBoard
            await _client.GetAsync(String.Format("/api/genericGameBoard/AddGameBoardSpaceIdToGameBoard/{0}/{1}", gameBoardSpaceId, createdGameBoard.Id));
            
            //Ensure gameBoardSpaceId DID get added to gameBoard
            response = await _client.GetAsync(String.Format("/api/genericGameBoard/GameBoardContainsGameBoardSpaceId/{0}/{1}", createdGameBoard.Id, gameBoardSpaceId));
            result = JsonConvert.DeserializeObject<bool>(
                    await response.Content.ReadAsStringAsync()
                );
            response.Dispose();
            Assert.True(result);

            //Now remove GameBoardSpaceId from gameBoard
            await _client.GetAsync(String.Format("/api/genericGameBoard/RemoveGameBoardSpaceIdFromGameBoard/{0}/{1}", gameBoardSpaceId, createdGameBoard.Id));
            
            //Ensure gameBoardSpaceId DID get removed from gameBoard
            response = await _client.GetAsync(String.Format("/api/genericGameBoard/GameBoardContainsGameBoardSpaceId/{0}/{1}", createdGameBoard.Id, gameBoardSpaceId));
            result = JsonConvert.DeserializeObject<bool>(
                    await response.Content.ReadAsStringAsync()
                );
            response.Dispose();
            Assert.False(result);
        }

    }
}
