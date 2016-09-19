using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameBoardSpaceApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameBoardSpaceApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void AddQueryAndRemoveGamePieceIds()
        {
            //Arrange
            bool result;
            //Create a gameBoardSpace
            var response = await _client.GetAsync("/api/genericGameBoardSpace/create");
            GenericGameBoardSpace createdGameBoardSpace = JsonConvert.DeserializeObject<GenericGameBoardSpace>(
                    response.Content.ReadAsStringAsync().Result
                );
            var gamePieceId = Guid.NewGuid();
            response.Dispose();

            //Act
            //Ensure GamePieceId doesn't already exist in game
            response = await _client.GetAsync(String.Format("/api/genericGameBoardSpace/GameBoardSpaceContainsGamePieceId/{0}/{1}", createdGameBoardSpace.Id, gamePieceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);

            //Add a player Id to that game
            await _client.GetAsync(String.Format("/api/genericGameBoardSpace/AddGamePieceIdToGameBoardSpace/{0}/{1}", gamePieceId, createdGameBoardSpace.Id));
            //Ensure gamePieceId DID get added to game
            response = await _client.GetAsync(String.Format("/api/genericGameBoardSpace/GameBoardSpaceContainsGamePieceId/{0}/{1}", createdGameBoardSpace.Id, gamePieceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.True(result);

            //Now remove GamePieceId from game
            await _client.GetAsync(String.Format("/api/genericGameBoardSpace/RemoveGamePieceIdFromGameBoardSpace/{0}/{1}", gamePieceId, createdGameBoardSpace.Id));
            //Ensure gamePieceId DID get removed from game
            response = await _client.GetAsync(String.Format("/api/genericGameBoardSpace/GameBoardSpaceContainsGamePieceId/{0}/{1}", createdGameBoardSpace.Id, gamePieceId));
            result = JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(result);
        }

    }
}
