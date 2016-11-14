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
using MrPitiful.BoardGame.Database;

namespace MrPitiful.BoardGame.Web.Test
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
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<GameSet> GetTestGameSet()
        {
            var testGameSet = new GameSet();
            var response = await _client.PostAsync(
                "/api/GameSet", new StringContent(
                    JsonConvert.SerializeObject(testGameSet)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            return JsonConvert.DeserializeObject<GameSet>(
                await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async void PostAndGetAssignedId()
        {
            //Arrange

            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;
            
            //Act
            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    ,Encoding.UTF8
                    ,"application/json"
                    )        
                );
            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Assert
            Assert.NotEqual(Guid.Empty, postedObj.Id);
        }

        [Fact]
        public async void PostAndGetById()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoard/{0}", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(postedObj.Id, gotObj.Id);
        }

        [Fact]
        public async void PostAndGetByIdWithStateProperties()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;
            var testproperty1 = "testproperty1";
            var originalValue = "originalvalue";
            testObj.StateProperties.Add(new GameBoardStateProperty { Name = testproperty1, Value = originalValue });

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoard/{0}?includeStateProperties=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(testObj.StateProperties.Count(), gotObj.StateProperties.Count());
        }

        [Fact]
        public async void PostAndGetByIdWithGameBoardSpaces()
        {
            //Assert.True(false);
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;
            testObj.GameBoardSpaces.Add(new GameBoardSpace());
            testObj.GameBoardSpaces.Add(new GameBoardSpace());

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoard/{0}?includeGameboardSpaces=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, postedObj.GameBoardSpaces.Count());
        }

        [Fact]
        public async void PostAndGetByIdWithGamePieces()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;
            testObj.GameBoardSpaces.Add(new GameBoardSpace()
            {GamePieces = new List<GamePiece>()
                {
                    { new GamePiece() { GameSetId=testGameSet.Id} },
                    { new GamePiece() { GameSetId=testGameSet.Id} }
                }
            });

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoard/{0}?includeGamePieces=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, gotObj.GameBoardSpaces[0].GamePieces.Count());
        }

        [Fact]
        public async void Delete()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;

            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Act
            await _client.DeleteAsync(string.Format("/api/GameBoard/{0}",postedObj.Id));

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => {
                //Get
                response = await _client.GetAsync(
                        string.Format("/api/GameBoard/{0}", postedObj.Id)
                    );
            });
        }

        [Fact]
        public async void SetAndChangeAStateProperty()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testObj = new GameBoard();
            testObj.GameSetId = testGameSet.Id;
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var originalValue = "originalValue";
            var updatedValue = "updatedValue";
            testObj.StateProperties.Add(new GameBoardStateProperty { Name = testproperty1, Value = originalValue });
            testObj.StateProperties.Add(new GameBoardStateProperty { Name = testproperty2, Value = originalValue });
            //Act 
            //Post test Object
            var response = await _client.PostAsync(
               "/api/GameBoard", new StringContent(
                   JsonConvert.SerializeObject(testObj)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );

            var postedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Get objectById with State Properties
            response = await _client.GetAsync(
                   string.Format("/api/GameBoard/{0}?includeStateProperties=true", postedObj.Id)
               );
            var gotObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());//Assert

            //Assert
            //testproperty1 and testproperty2 should both be originalvalue
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);

            //Arrange
            //now lets change testproperty1 to updatedValue without including any other stateproperties
            gotObj.StateProperties = new List<GameBoardStateProperty>()
            {
                new GameBoardStateProperty() {Name=testproperty1, Value=updatedValue }
            };

            //Act
            //update GotObj
            response = await _client.PutAsync(
                           "/api/GameBoard", new StringContent(
                               JsonConvert.SerializeObject(gotObj)
                               , Encoding.UTF8
                               , "application/json"
                               )
                           );
            response = await _client.GetAsync(
                   string.Format("/api/GameBoard/{0}?includeStateProperties=true", gotObj.Id)
               );
            var updatedObj = JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());

            //Assert
            //testproperty1 should be updatedValue and testproperty2 should be originalvalue
            Assert.Equal(updatedValue, updatedObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, updatedObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);

        }
    }
}
