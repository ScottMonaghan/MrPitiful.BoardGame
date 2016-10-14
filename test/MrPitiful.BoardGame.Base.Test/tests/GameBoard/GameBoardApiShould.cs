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
/*
        [Fact]
        public async void SetAndGetGameBoardGameId()
        {
            //Arrange
            //Create a gameBoard
            var response = await _client.GetAsync("/api/genericGameBoard/create");
            GenericGameBoard createdGameBoard = JsonConvert.DeserializeObject<GenericGameBoard>(
                    await response.Content.ReadAsStringAsync()
                );
            response.Dispose();

            //Act
            //set the gameId
            Guid newGameId = Guid.NewGuid();
            response = await _client.GetAsync(string.Format("/api/genericGameBoard/SetGameBoardGameId/{0}/{1}",createdGameBoard.Id,newGameId));
            response.Dispose();


            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            response = await _client.GetAsync(string.Format("/api/genericGameBoard/GetGameBoardGameId/{0}", createdGameBoard.Id));
            Guid gotGameId = JsonConvert.DeserializeObject<Guid>(
                    await response.Content.ReadAsStringAsync()
                );

            Assert.Equal<Guid>(newGameId, gotGameId);
        }
        */
    }
}
