using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameAPIShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameAPIShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void ReturnAListOfEmptyGames()
        {
            //Act
            var response = await _client.GetAsync("/api/genericGame/");
            var result = JsonConvert.DeserializeObject<Dictionary<Guid,GenericGame>>(
                    response.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async void ReturnAGameWithAGuidAfterCreate()
        {
            var response = await _client.GetAsync("/api/genericGame/create");
            GenericGame result = JsonConvert.DeserializeObject<GenericGame>(
                    response.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.True(result.Id != Guid.Empty);
        }

        [Fact]
        public async void GetAGameByIdAfterCreatingIt()
        {
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.Equal<Guid>(createdGame.Id, gotGame.Id);
        }
        [Fact]
        public async void AddPlayerIdToGame()
        {
            //Arrange
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var playerId = Guid.NewGuid();

            //Act 
            await _client.GetAsync(String.Format("/api/genericGame/AddPlayerIdToGame/{0}/{1}", playerId, createdGame.Id));
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.True(gotGame.PlayerIds.Contains(playerId));
        }

        [Fact]
        public async void RemovePlayerIdFromGame()
        {
            //Arrange
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var playerId = Guid.NewGuid();

            //Act 
            await _client.GetAsync(String.Format("/api/genericGame/AddPlayerIdToGame/{0}/{1}", playerId, createdGame.Id));
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            Assert.True(gotGame.PlayerIds.Contains(playerId));
            await _client.GetAsync(String.Format("/api/genericGame/RemovePlayerIdFromGame/{0}/{1}", playerId, createdGame.Id));
            response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            
            //Assert
            Assert.False(gotGame.PlayerIds.Contains(playerId));
        }

        [Fact]
        public async void AddGamePieceIdToGame()
        {
            //Arrange
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var gamePieceId = Guid.NewGuid();

            //Act 
            await _client.GetAsync(String.Format("/api/genericGame/AddGamePieceIdToGame/{0}/{1}", gamePieceId, createdGame.Id));
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.True(gotGame.GamePieceIds.Contains(gamePieceId));
        }

        [Fact]
        public async void RemoveGamePieceIdFromGame()
        {
            //Arrange
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var gamePieceId = Guid.NewGuid();

            //Act 
            await _client.GetAsync(String.Format("/api/genericGame/AddGamePieceIdToGame/{0}/{1}", gamePieceId, createdGame.Id));
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            Assert.True(gotGame.GamePieceIds.Contains(gamePieceId));
            await _client.GetAsync(String.Format("/api/genericGame/RemoveGamePieceIdFromGame/{0}/{1}", gamePieceId, createdGame.Id));
            response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );

            //Assert
            Assert.False(gotGame.GamePieceIds.Contains(gamePieceId));
        }

        [Fact]
        public async void AddGameBoardSpaceIdToGame()
        {
            //Arrange
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var gameBoardSpaceId = Guid.NewGuid();

            //Act 
            await _client.GetAsync(String.Format("/api/genericGame/AddGameBoardSpaceIdToGame/{0}/{1}", gameBoardSpaceId, createdGame.Id));
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.True(gotGame.GameBoardSpaceIds.Contains(gameBoardSpaceId));
        }

        [Fact]
        public async void RemoveGameBoardSpaceIdFromGame()
        {
            //Arrange
            var response1 = await _client.GetAsync("/api/genericGame/create");
            GenericGame createdGame = JsonConvert.DeserializeObject<GenericGame>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var gameBoardSpaceId = Guid.NewGuid();

            //Act 
            await _client.GetAsync(String.Format("/api/genericGame/AddGameBoardSpaceIdToGame/{0}/{1}", gameBoardSpaceId, createdGame.Id));
            var response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            GenericGame gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );
            Assert.True(gotGame.GameBoardSpaceIds.Contains(gameBoardSpaceId));
            await _client.GetAsync(String.Format("/api/genericGame/RemoveGameBoardSpaceIdFromGame/{0}/{1}", gameBoardSpaceId, createdGame.Id));
            response2 = await _client.GetAsync(String.Format("/api/genericGame/{0}", createdGame.Id));
            gotGame = JsonConvert.DeserializeObject<GenericGame>(
                    response2.Content.ReadAsStringAsync().Result
                );

            //Assert
            Assert.False(gotGame.GameBoardSpaceIds.Contains(gameBoardSpaceId));
        }
    }
}
