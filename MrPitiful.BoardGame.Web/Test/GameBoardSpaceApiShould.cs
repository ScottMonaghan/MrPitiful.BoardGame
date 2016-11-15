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
    public class GameBoardSpaceApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameBoardSpaceApiShould()
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
        private async Task<GameBoard> GetTestGameBoard(Guid gameSetId)
        {
            var testGameBoard = new GameBoard() {GameSetId = gameSetId};
            var response = await _client.PostAsync(
                "/api/GameBoard", new StringContent(
                    JsonConvert.SerializeObject(testGameBoard)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            return JsonConvert.DeserializeObject<GameBoard>(
                await response.Content.ReadAsStringAsync());
        }
        private async Task DeleteGameSetForCleanup(GameSet gameSet)
        {
            await _client.DeleteAsync(string.Format("/api/GameSet/{0}", gameSet.Id));
        }

        [Fact]
        public async void PostAndGetAssignedId()
        {
            //Arrange

            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;
            
            //Act
            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    ,Encoding.UTF8
                    ,"application/json"
                    )        
                );
            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Assert
            Assert.NotEqual(Guid.Empty, postedObj.Id);
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void PostAndGetById()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoardSpace/{0}", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(postedObj.Id, gotObj.Id);
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void PostAndGetByIdWithStateProperties()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;

            var testproperty1 = "testproperty1";
            var originalValue = "originalvalue";
            testObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty1, Value = originalValue });

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoardSpace/{0}?includeStateProperties=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(testObj.StateProperties.Count(), gotObj.StateProperties.Count());
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void PostAndGetByIdWithGamePieces()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;

            testObj.GamePieces = new List<GamePiece>()
                {
                    { new GamePiece() { GameSetId=testGameSet.Id} },
                    { new GamePiece() { GameSetId=testGameSet.Id} }
                };

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoardSpace/{0}?includeGamePieces=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, gotObj.GamePieces.Count());
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void PostAndGetByIdWithSpaceConnections()
        { 
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;

            testObj.SpaceConnections.Add(new SpaceConnection());               
            testObj.SpaceConnections.Add(new SpaceConnection());               

            //Act
            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/GameBoardSpace/{0}?includeSpaceConnections=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, gotObj.SpaceConnections.Count());
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void Delete()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;

            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Act
            await _client.DeleteAsync(string.Format("/api/GameBoardSpace/{0}",postedObj.Id));

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => {
                //Get
                response = await _client.GetAsync(
                        string.Format("/api/GameBoardSpace/{0}", postedObj.Id)
                    );
            });
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void SetAndChangeAStateProperty()
        {
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            var testObj = new GameBoardSpace();
            testObj.GameBoardId = testGameBoard.Id;
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var originalValue = "originalValue";
            var updatedValue = "updatedValue";
            testObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty1, Value = originalValue });
            testObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty2, Value = originalValue });
            //Act 
            //Post test Object
            var response = await _client.PostAsync(
               "/api/GameBoardSpace", new StringContent(
                   JsonConvert.SerializeObject(testObj)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );

            var postedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Get objectById with State Properties
            response = await _client.GetAsync(
                   string.Format("/api/GameBoardSpace/{0}?includeStateProperties=true", postedObj.Id)
               );
            var gotObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());//Assert

            //Assert
            //testproperty1 and testproperty2 should both be originalvalue
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);

            //Arrange
            //now lets change testproperty1 to updatedValue without including any other stateproperties
            gotObj.StateProperties = new List<GameBoardSpaceStateProperty>()
            {
                new GameBoardSpaceStateProperty() {Name=testproperty1, Value=updatedValue }
            };

            //Act
            //update GotObj
            response = await _client.PutAsync(
                           "/api/GameBoardSpace", new StringContent(
                               JsonConvert.SerializeObject(gotObj)
                               , Encoding.UTF8
                               , "application/json"
                               )
                           );
            response = await _client.GetAsync(
                   string.Format("/api/GameBoardSpace/{0}?includeStateProperties=true", gotObj.Id)
               );
            var updatedObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Assert
            //testproperty1 should be updatedValue and testproperty2 should be originalvalue
            Assert.Equal(updatedValue, updatedObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, updatedObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);
            await DeleteGameSetForCleanup(testGameSet);
        }

        [Fact]
        public async void PostAndGetByStateProperties()
        {
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var goodvalue = "goodvalue";
            var badvalue = "badvalue";

            //Arrange
            //Arrange
            var testGameSet = await GetTestGameSet();
            var testGameBoard = await GetTestGameBoard(testGameSet.Id);
            //set up good object with good values
            var goodObj = new GameBoardSpace();
            goodObj.GameBoardId = testGameBoard.Id;
            goodObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty1, Value = goodvalue });
            goodObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty2, Value = goodvalue });
            //set up bad object with one bad value
            var badObj = new GameBoardSpace();
            badObj.GameBoardId = testGameBoard.Id;
            badObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty1, Value = goodvalue });
            badObj.StateProperties.Add(new GameBoardSpaceStateProperty { Name = testproperty2, Value = badvalue });

            //set up filter
            var statePropertiesToFilter = new List<StateProperty>() { };
            statePropertiesToFilter.Add(new GameBoardSpaceStateProperty { Name = testproperty1, Value = goodvalue });
            statePropertiesToFilter.Add(new GameBoardSpaceStateProperty { Name = testproperty2, Value = goodvalue });

            //post goodObj
            var response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(goodObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            goodObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //post badObj
            response = await _client.PostAsync(
                "/api/GameBoardSpace", new StringContent(
                    JsonConvert.SerializeObject(badObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            badObj = JsonConvert.DeserializeObject<GameBoardSpace>(
                await response.Content.ReadAsStringAsync());

            //Act 
            response = await _client.PostAsync(
               String.Format("/api/GameBoardSpace/GetByStateProperties/{0}",testGameBoard.Id), new StringContent(
                   JsonConvert.SerializeObject(statePropertiesToFilter)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );
            var gotObjects = JsonConvert.DeserializeObject<List<GameBoardSpace>>(
                    await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(1, gotObjects.Count());

            //Clean up
            await DeleteGameSetForCleanup(testGameSet);
        }

    }
}
