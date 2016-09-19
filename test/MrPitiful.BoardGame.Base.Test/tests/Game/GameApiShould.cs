using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void AddQueryAndRemovePlayerIds()
        {
            //Arrange
            bool result;
            //Create a game
            var response = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response.Content.ReadAsStringAsync().Result
                );
            var playerId = Guid.NewGuid();
            response.Dispose();

            //Act
            //Ensure PlayerId doesn't already exist in game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsPlayerId/{0}/{1}", createdGame.Id, playerId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);

            //Add a player Id to that game
            await _client.GetAsync(String.Format("/api/genericGame/AddPlayerIdToGame/{0}/{1}", playerId, createdGame.Id));
            //Ensure playerId DID get added to game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsPlayerId/{0}/{1}", createdGame.Id, playerId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.True(result);
            
            //Now remove PlayerId from game
            await _client.GetAsync(String.Format("/api/genericGame/RemovePlayerIdFromGame/{0}/{1}", playerId, createdGame.Id));
            //Ensure playerId DID get removed from game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsPlayerId/{0}/{1}", createdGame.Id, playerId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);
        }

        [Fact]
        public async void AddQueryAndRemoveGamePieceIds()
        {
            //Arrange
            bool result;
            //Create a game
            var response = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response.Content.ReadAsStringAsync().Result
                );
            var gamePieceId = Guid.NewGuid();
            response.Dispose();

            //Act
            //Ensure GamePieceId doesn't already exist in game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsGamePieceId/{0}/{1}", createdGame.Id, gamePieceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);

            //Add a player Id to that game
            await _client.GetAsync(String.Format("/api/genericGame/AddGamePieceIdToGame/{0}/{1}", gamePieceId, createdGame.Id));
            //Ensure gamePieceId DID get added to game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsGamePieceId/{0}/{1}", createdGame.Id, gamePieceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.True(result);

            //Now remove GamePieceId from game
            await _client.GetAsync(String.Format("/api/genericGame/RemoveGamePieceIdFromGame/{0}/{1}", gamePieceId, createdGame.Id));
            //Ensure gamePieceId DID get removed from game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsGamePieceId/{0}/{1}", createdGame.Id, gamePieceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);
        }

        [Fact]
        public async void AddQueryAndRemoveGameBoardSpaceIds()
        {
            //Arrange
            bool result;
            //Create a game
            var response = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response.Content.ReadAsStringAsync().Result
                );
            var gameBoardSpaceId = Guid.NewGuid();
            response.Dispose();

            //Act
            //Ensure GameBoardSpaceId doesn't already exist in game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsGameBoardSpaceId/{0}/{1}", createdGame.Id, gameBoardSpaceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);

            //Add a player Id to that game
            await _client.GetAsync(String.Format("/api/genericGame/AddGameBoardSpaceIdToGame/{0}/{1}", gameBoardSpaceId, createdGame.Id));
            //Ensure gameBoardSpaceId DID get added to game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsGameBoardSpaceId/{0}/{1}", createdGame.Id, gameBoardSpaceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.True(result);

            //Now remove GameBoardSpaceId from game
            await _client.GetAsync(String.Format("/api/genericGame/RemoveGameBoardSpaceIdFromGame/{0}/{1}", gameBoardSpaceId, createdGame.Id));
            //Ensure gameBoardSpaceId DID get removed from game
            response = await _client.GetAsync(String.Format("/api/genericGame/GameContainsGameBoardSpaceId/{0}/{1}", createdGame.Id, gameBoardSpaceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);
        }

    }
}
