using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xunit;
using MrPitiful.BoardGame.Models;
using System.Text;

namespace MrPitiful.BoardGame.Web.Test
{
    public class GameSetApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameSetApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        [Fact]
        public async void PostAndGetAssignedId()
        {
            //Arrange
            var testObj = new GameSet();

            //Act
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    ,Encoding.UTF8
                    ,"application/json"
                    )        
                );
            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Assert
            Assert.NotEqual(Guid.Empty, postedObj.Id);
        }

        [Fact]
        public async void PostAndGetById()
        {
            //Arrange
            var testObj = new GameSet();

            //Act
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameSet/{0}", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(postedObj.Id, gotObj.Id);
        }

        [Fact]
        public async void PostAndGetByIdWithStateProperties()
        {
            //Arrange
            var testObj = new GameSet();
            var testproperty1 = "testproperty1";
            var originalValue = "originalvalue";
            testObj.StateProperties.Add(new GameSetStateProperty { Name = testproperty1, Value = originalValue });

            //Act
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameSet/{0}?includeStateProperties=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(testObj.StateProperties.Count(), gotObj.StateProperties.Count());
        }

        [Fact]
        public async void PostAndGetByIdWithGameBoard() {
            //Arrange
            var testObj = new GameSet();
            testObj.GameBoard = new GameBoard();

            //Act
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameSet/{0}?includeGameboard=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.NotEqual(Guid.Empty, postedObj.GameBoard.Id);
            Assert.Equal(postedObj.GameBoard.Id, gotObj.GameBoard.Id);
        }

        [Fact]
        public async void PostAndGetByIdWithGameBoardSpaces()
        {
            //Assert.True(false);
            //Arrange
            var testObj = new GameSet();
            testObj.GameBoard = new GameBoard();
            testObj.GameBoard.GameBoardSpaces = new List<GameBoardSpace>()
            {new GameBoardSpace(), new GameBoardSpace() };

            //Act
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameSet/{0}?includeGameboardSpaces=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, postedObj.GameBoard.GameBoardSpaces.Count());
        }

        [Fact]
        public async void PostAndGetByIdWithGamePieces()
        {
            //Arrange
            var testObj = new GameSet();
            testObj.GamePieces = new List<GamePiece>()
            {new GamePiece(), new GamePiece() };

            //Act
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameSet/{0}?includeGamePieces=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, gotObj.GamePieces.Count());
        }


        [Fact]
        public async void Delete()
        {
            //Arrange
            var testObj = new GameSet();

            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            var postedObj = JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());

            //Act
            await _client.DeleteAsync(string.Format("/api/GameSet/{0}",postedObj.Id));

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => {
                //Get
                response = await _client.GetAsync(
                        string.Format("/api/GameSet/{0}", postedObj.Id)
                    );
            });
        }
    }

}
