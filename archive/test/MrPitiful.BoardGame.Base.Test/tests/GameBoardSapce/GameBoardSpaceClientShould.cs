using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameBoardSpaceClientShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GameBoardSpaceClientShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void AddQueryAndRemoveGamePieceIds()
        {
            //Arrange 
            //Create new GameBoardSpaceClient
            GenericGameBoardSpaceClient gameBoardSpaceClient
                = new GenericGameBoardSpaceClient(_client);

            //Create mock gamePieceId
            var gamePieceId = Guid.NewGuid();

            //Create a gameBoardSpace 
            GenericGameBoardSpace createdGameBoardSpace = await gameBoardSpaceClient.Create();

            //Ensure GamePieceId doesn't already exist in gameBoardSpace
            bool gameBoardSpaceContainsGamePieceId = await gameBoardSpaceClient.GameBoardSpaceContainsGamePieceId(createdGameBoardSpace.Id, gamePieceId);
            Assert.False(gameBoardSpaceContainsGamePieceId);

            //Add a player Id to that gameBoardSpace
            await gameBoardSpaceClient.AddGamePieceIdToGameBoardSpace(gamePieceId, createdGameBoardSpace.Id);

            //Ensure gamePieceId DID get added to gameBoardSpace
            gameBoardSpaceContainsGamePieceId = await gameBoardSpaceClient.GameBoardSpaceContainsGamePieceId(createdGameBoardSpace.Id, gamePieceId);
            Assert.True(gameBoardSpaceContainsGamePieceId);

            //Now remove GamePieceId from gameBoardSpace
            await gameBoardSpaceClient.RemoveGamePieceIdFromGameBoardSpace(gamePieceId, createdGameBoardSpace.Id);

            //Ensure gamePieceId DID get removed from gameBoardSpace
            gameBoardSpaceContainsGamePieceId = await gameBoardSpaceClient.GameBoardSpaceContainsGamePieceId(createdGameBoardSpace.Id, gamePieceId);
            Assert.False(gameBoardSpaceContainsGamePieceId);
        }

        [Fact]
        public async void SetAndGetGameBoardSpaceGameId()
        {
            //Arrange 
            //Create new GameBoardSpaceClient
            GenericGameBoardSpaceClient gameBoardSpaceClient
                = new GenericGameBoardSpaceClient(_client);
            //Create a GameBoardSpace
            GenericGameBoardSpace createdGameBoardSpace = await gameBoardSpaceClient.Create();

            //Act 
            //set the GameId
            Guid newGameId = Guid.NewGuid();
            await gameBoardSpaceClient.SetGameBoardSpaceGameId(createdGameBoardSpace.Id, newGameId);

            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            Guid gotGameId = await gameBoardSpaceClient.GetGameBoardSpaceGameId(createdGameBoardSpace.Id);
            Assert.Equal(newGameId, gotGameId);
        }

        [Fact]
        public async void SetAndGetGameBoardSpaceGameBoardId()
        {
            //Arrange 
            //Create new GameBoardSpaceClient
            GenericGameBoardSpaceClient gameBoardSpaceClient
                = new GenericGameBoardSpaceClient(_client);
            //Create a GameBoardSpace
            GenericGameBoardSpace createdGameBoardSpace = await gameBoardSpaceClient.Create();

            //Act 
            //set the GameBoardId
            Guid newGameBoardId = Guid.NewGuid();
            await gameBoardSpaceClient.SetGameBoardSpaceGameBoardId(createdGameBoardSpace.Id, newGameBoardId);

            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            Guid gotGameBoardId = await gameBoardSpaceClient.GetGameBoardSpaceGameBoardId(createdGameBoardSpace.Id);
            Assert.Equal(newGameBoardId, gotGameBoardId);
        }

        [Fact]
        public async void AddQueryAndRemoveAdjacenctSpace()
        {
            //Arrange 
            //Create new GameBoardSpaceClient
            GenericGameBoardSpaceClient gameBoardSpaceClient
                = new GenericGameBoardSpaceClient(_client);
            //Create a GameBoardSpace
            GenericGameBoardSpace createdGameBoardSpace = await gameBoardSpaceClient.Create();

            //Act 
            //Add AdjacentSpace to gameBoardSpace
            string direction = "direction";
            Guid adjacentSpaceId = Guid.NewGuid();
            await gameBoardSpaceClient.AddAdjacentSpaceToGameBoardSpace(direction, adjacentSpaceId, createdGameBoardSpace.Id);

            //Assert
            //now we should be able to retrieve the adjacent space by direction!
            Guid gotAdjacentSpaceId = await gameBoardSpaceClient.GetAdjacentSpaceIdByDirection(createdGameBoardSpace.Id, direction);
            Assert.Equal<Guid>(adjacentSpaceId, gotAdjacentSpaceId);

            //Assert
            //now we should be able to retrieve the dicrection by the spaceId!
            List<string> gotDirections = await gameBoardSpaceClient.GetDirectionsByAdjacentSpaceId(createdGameBoardSpace.Id, adjacentSpaceId);
            Assert.True(gotDirections.Contains(direction));

            //Act (some more?)
            //now lets remove the adjacent space
            await gameBoardSpaceClient.RemoveAdjacentSpaceFromGameBoardSpace(direction, createdGameBoardSpace.Id);

            //Make sure its gone
            gotDirections = await gameBoardSpaceClient.GetDirectionsByAdjacentSpaceId(createdGameBoardSpace.Id, adjacentSpaceId);
            Assert.False(gotDirections.Contains(direction));

        }

        [Fact]
        async void GetGameBoardSpaceGamePieceIds()
        {
            //Arrange
            //Create new GameBoardSpaceClient
            GenericGameBoardSpaceClient gameBoardSpaceClient
                = new GenericGameBoardSpaceClient(_client);
            //create dummy gamePieceId
            var gamePieceId = Guid.NewGuid();
            //Create a GameBoardSpace
            GenericGameBoardSpace createdGameBoardSpace = await gameBoardSpaceClient.Create();
            //Add a GamePieceId to that gameBoardSpace
            await gameBoardSpaceClient.AddGamePieceIdToGameBoardSpace(gamePieceId, createdGameBoardSpace.Id);

            //Act
            List<Guid> GamePieceIds = await gameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(createdGameBoardSpace.Id);

            //Assert
            //the list should contain 1 value
            Assert.Equal(1, GamePieceIds.Count);
            //the lists first value should be gamePieceId
            Assert.Equal(gamePieceId, GamePieceIds[0]);
        }
    }
}
