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

            //Add a GamePieceId to that game
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

        [Fact]
        public async void SetAndGetGameBoardSpaceGameId()
        {
            //Arrange
            //Create a gameBoardSpace
            var response = await _client.GetAsync("/api/genericGameBoardSpace/create");
            GenericGameBoardSpace createdGameBoardSpace = JsonConvert.DeserializeObject<GenericGameBoardSpace>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();

            //Act
            //set the gameId
            Guid newGameId = Guid.NewGuid();
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/SetGameBoardSpaceGameId/{0}/{1}", createdGameBoardSpace.Id, newGameId));
            response.Dispose();


            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/GetGameBoardSpaceGameId/{0}", createdGameBoardSpace.Id));
            Guid gotGameId = JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );

            Assert.Equal<Guid>(newGameId, gotGameId);
        }

        [Fact]
        public async void SetAndGetGameBoardSpaceGameBoardId()
        {
            //Arrange
            //Create a gameBoardSpace
            var response = await _client.GetAsync("/api/genericGameBoardSpace/create");
            GenericGameBoardSpace createdGameBoardSpace = JsonConvert.DeserializeObject<GenericGameBoardSpace>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();

            //Act
            //set the gameBoardId
            Guid newGameBoardId = Guid.NewGuid();
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/SetGameBoardSpaceGameBoardId/{0}/{1}", createdGameBoardSpace.Id, newGameBoardId));
            response.Dispose();


            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/GetGameBoardSpaceGameBoardId/{0}", createdGameBoardSpace.Id));
            Guid gotGameBoardId = JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );

            Assert.Equal<Guid>(newGameBoardId, gotGameBoardId);
        }

        [Fact]
        public async void AddQueryAndRemoveAdjacenctSpace()
        {
            //Arrange
            //Create a gameBoardSpace
            var response = await _client.GetAsync("/api/genericGameBoardSpace/create");
            GenericGameBoardSpace createdGameBoardSpace = JsonConvert.DeserializeObject<GenericGameBoardSpace>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();

            //Act 
            //Add AdjacentSpace to gameBoardSpace
            string direction = "direction";
            Guid adjacentSpaceId = Guid.NewGuid();
            response = await _client.GetAsync(String.Format("/api/genericGameBoardSpace/AddAdjacentSpaceToGameBoardSpace/{0}/{1}/{2}", direction, adjacentSpaceId, createdGameBoardSpace.Id));
            response.Dispose();

            //Assert
            //now we should be able to retrieve the adjacent space by direction!
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/GetAdjacentSpaceIdByDirection/{0}/{1}", createdGameBoardSpace.Id, direction));
            Guid gotAdjacentSpaceId = JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.Equal<Guid>(adjacentSpaceId, gotAdjacentSpaceId);

            //Assert
            //now we should be able to retrieve the dicrection by the spaceId!
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/GetDirectionsByAdjacentSpaceId/{0}/{1}", createdGameBoardSpace.Id, adjacentSpaceId));
            List<string> gotDirections = JsonConvert.DeserializeObject<List<string>>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.True(gotDirections.Contains(direction));

            //Act (some more?)
            //now lets remove the adjacent space
            response = await _client.GetAsync(String.Format("/api/genericGameBoardSpace/RemoveAdjacentSpaceFromGameBoardSpace/{0}/{1}", direction, createdGameBoardSpace.Id));
            response.Dispose();

            //Assert 
            //Make sure its gone?
            response = await _client.GetAsync(string.Format("/api/genericGameBoardSpace/GetDirectionsByAdjacentSpaceId/{0}/{1}", createdGameBoardSpace.Id, adjacentSpaceId));
            List<string> gotRemovedDirections = JsonConvert.DeserializeObject<List<string>>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            Assert.False(gotRemovedDirections.Contains(direction));

        }

        [Fact]
        public async void GetGameBoardSpaceGamePieceIds()
        {
            //Arrange
            //create dummy gamePieceId
            var gamePieceId = Guid.NewGuid();
            //Create a gameBoardSpace
            var response = await _client.GetAsync("/api/genericGameBoardSpace/create");
            GenericGameBoardSpace createdGameBoardSpace = JsonConvert.DeserializeObject<GenericGameBoardSpace>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();
            //Add a GamePieceId to that gameBoardSpace
            await _client.GetAsync(String.Format("/api/genericGameBoardSpace/AddGamePieceIdToGameBoardSpace/{0}/{1}", gamePieceId, createdGameBoardSpace.Id));

            //Act
            response = await _client.GetAsync(String.Format("/api/genericGameBoardSpace/GetGameBoardSpaceGamePieceIds/{0}",createdGameBoardSpace.Id));
            List<Guid> GamePieceIds = JsonConvert.DeserializeObject<List<Guid>>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();

            //Assert
            //the list should contain 1 value
            Assert.Equal(1, GamePieceIds.Count);
            //the lists first value should be gamePieceId
            Assert.Equal(gamePieceId, GamePieceIds[0]);
        }
    }
}
