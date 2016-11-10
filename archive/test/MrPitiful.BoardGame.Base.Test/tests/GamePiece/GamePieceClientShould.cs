using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GamePieceClientShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GamePieceClientShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void SetAndGetGamePieceGameId()
        {
            //Arrange 
            //Create new GamePieceClient
            GenericGamePieceClient gamePieceClient
                = new GenericGamePieceClient(_client);
            //Create a GamePiece
            GenericGamePiece createdGamePiece = await gamePieceClient.Create();

            //Act 
            //set the GameId
            Guid newGameId = Guid.NewGuid();
            await gamePieceClient.SetGamePieceGameId(createdGamePiece.Id, newGameId);

            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            Guid gotGameId = await gamePieceClient.GetGamePieceGameId(createdGamePiece.Id);
            Assert.Equal(newGameId, gotGameId);
        }


        [Fact]
        public async void SetAndGetGamePieceGameBoardId()
        {
            //Arrange 
            //Create new GamePieceClient
            GenericGamePieceClient gamePieceClient
                = new GenericGamePieceClient(_client);
            //Create a GamePiece
            GenericGamePiece createdGamePiece = await gamePieceClient.Create();

            //Act 
            //set the GameBoardId
            Guid newGameBoardId = Guid.NewGuid();
            await gamePieceClient.SetGamePieceGameBoardId(createdGamePiece.Id, newGameBoardId);

            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            Guid gotGameBoardId = await gamePieceClient.GetGamePieceGameBoardId(createdGamePiece.Id);
            Assert.Equal(newGameBoardId, gotGameBoardId);
        }

        [Fact]
        public async void SetAndGetGamePieceGameBoardSpaceId()
        {
            //Arrange 
            //Create new GamePieceClient
            GenericGamePieceClient gamePieceClient
                = new GenericGamePieceClient(_client);
            //Create a GamePiece
            GenericGamePiece createdGamePiece = await gamePieceClient.Create();

            //Act 
            //set the GameBoardSpaceId
            Guid newGameBoardSpaceId = Guid.NewGuid();
            await gamePieceClient.SetGamePieceGameBoardSpaceId(createdGamePiece.Id, newGameBoardSpaceId);

            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            Guid gotGameBoardSpaceId = await gamePieceClient.GetGamePieceGameBoardSpaceId(createdGamePiece.Id);
            Assert.Equal(newGameBoardSpaceId, gotGameBoardSpaceId);
        }
    }
}
