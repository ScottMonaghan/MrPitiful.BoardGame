using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GamePieceApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GamePieceApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void SetAndGetGamePieceGameId()
        {
            //Arrange
            //Create a gamePiece
            var response = await _client.GetAsync("/api/genericGamePiece/create");
            GenericGamePiece createdGamePiece = JsonConvert.DeserializeObject<GenericGamePiece>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();

            //Act
            //set the gameId
            Guid newGameId = Guid.NewGuid();
            response = await _client.GetAsync(string.Format("/api/genericGamePiece/SetGamePieceGameId/{0}/{1}", createdGamePiece.Id, newGameId));
            response.Dispose();


            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            response = await _client.GetAsync(string.Format("/api/genericGamePiece/GetGamePieceGameId/{0}", createdGamePiece.Id));
            Guid gotGameId = JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );

            Assert.Equal<Guid>(newGameId, gotGameId);
        }

        [Fact]
        public async void SetAndGetGamePieceGameBoardSpaceId()
        {
            //Arrange
            //Create a gamePiece
            var response = await _client.GetAsync("/api/genericGamePiece/create");
            GenericGamePiece createdGamePiece = JsonConvert.DeserializeObject<GenericGamePiece>(
                    response.Content.ReadAsStringAsync().Result
                );
            response.Dispose();

            //Act
            //set the gameBoardSpaceId
            Guid newGameBoardSpaceId = Guid.NewGuid();
            response = await _client.GetAsync(string.Format("/api/genericGamePiece/SetGamePieceGameBoardSpaceId/{0}/{1}", createdGamePiece.Id, newGameBoardSpaceId));
            response.Dispose();


            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            response = await _client.GetAsync(string.Format("/api/genericGamePiece/GetGamePieceGameBoardSpaceId/{0}", createdGamePiece.Id));
            Guid gotGameBoardSpaceId = JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );

            Assert.Equal<Guid>(newGameBoardSpaceId, gotGameBoardSpaceId);
        }


    }
}
