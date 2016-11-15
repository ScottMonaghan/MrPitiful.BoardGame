﻿using System;
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
    public class PlayerApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public PlayerApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private async Task<Game> GetTestGame()
        {
            var testGame = new Game();
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testGame)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            return JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());
        }
        private async Task DeleteGameForCleanup(Game game)
        {
            await _client.DeleteAsync(string.Format("/api/Game/{0}", game.Id));
        }

        [Fact]
        public async void PostAndGetAssignedId()
        {
            //Arrange
            var testGame = await GetTestGame();
            var testObj = new Player();
            testObj.GameId = testGame.Id;
            
            //Act
            var response = await _client.PostAsync(
                "/api/Player", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    ,Encoding.UTF8
                    ,"application/json"
                    )        
                );
            var postedObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Assert
            Assert.NotEqual(Guid.Empty, postedObj.Id);
            await DeleteGameForCleanup(testGame);
        }

        [Fact]
        public async void PostAndGetById()
        {
            //Arrange
            var testGame = await GetTestGame();
            var testObj = new Player();
            testObj.GameId = testGame.Id;

            //Act
            var response = await _client.PostAsync(
                "/api/Player", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/Player/{0}", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(postedObj.Id, gotObj.Id);
            await DeleteGameForCleanup(testGame);
        }

        [Fact]
        public async void PostAndGetByIdWithStateProperties()
        {
            //Arrange
            //Arrange
            var testGame = await GetTestGame();
            var testObj = new Player();
            testObj.GameId = testGame.Id;

            var testproperty1 = "testproperty1";
            var originalValue = "originalvalue";
            testObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty1, Value = originalValue });

            //Act
            var response = await _client.PostAsync(
                "/api/Player", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/Player/{0}?includeStateProperties=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(testObj.StateProperties.Count(), gotObj.StateProperties.Count());
            await DeleteGameForCleanup(testGame);
        }

       [Fact]
        public async void Delete()
        {
            //Arrange
            var testGame = await GetTestGame();
            var testObj = new Player();
            testObj.GameId = testGame.Id;

            var response = await _client.PostAsync(
                "/api/Player", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            var postedObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Act
            await _client.DeleteAsync(string.Format("/api/Player/{0}",postedObj.Id));

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => {
                //Get
                response = await _client.GetAsync(
                        string.Format("/api/Player/{0}", postedObj.Id)
                    );
            });
            await DeleteGameForCleanup(testGame);
        }

        [Fact]
        public async void SetAndChangeAStateProperty()
        {
            //Arrange
            var testGame = await GetTestGame();
            var testObj = new Player();
            testObj.GameId = testGame.Id;
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var originalValue = "originalValue";
            var updatedValue = "updatedValue";
            testObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty1, Value = originalValue });
            testObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty2, Value = originalValue });
            //Act 
            //Post test Object
            var response = await _client.PostAsync(
               "/api/Player", new StringContent(
                   JsonConvert.SerializeObject(testObj)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );

            var postedObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Get objectById with State Properties
            response = await _client.GetAsync(
                   string.Format("/api/Player/{0}?includeStateProperties=true", postedObj.Id)
               );
            var gotObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());//Assert

            //Assert
            //testproperty1 and testproperty2 should both be originalvalue
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);

            //Arrange
            //now lets change testproperty1 to updatedValue without including any other stateproperties
            gotObj.StateProperties = new List<PlayerStateProperty>()
            {
                new PlayerStateProperty() {Name=testproperty1, Value=updatedValue }
            };

            //Act
            //update GotObj
            response = await _client.PutAsync(
                           "/api/Player", new StringContent(
                               JsonConvert.SerializeObject(gotObj)
                               , Encoding.UTF8
                               , "application/json"
                               )
                           );
            response = await _client.GetAsync(
                   string.Format("/api/Player/{0}?includeStateProperties=true", gotObj.Id)
               );
            var updatedObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Assert
            //testproperty1 should be updatedValue and testproperty2 should be originalvalue
            Assert.Equal(updatedValue, updatedObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, updatedObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);
            await DeleteGameForCleanup(testGame);
        }

        [Fact]
        public async void PostAndGetByStateProperties()
        {
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var goodvalue = "goodvalue";
            var badvalue = "badvalue";

            //Arrange
            var testGame = await GetTestGame();
            //set up good object with good values
            var goodObj = new Player();
            goodObj.GameId = testGame.Id;
            goodObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty1, Value = goodvalue });
            goodObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty2, Value = goodvalue });
            //set up bad object with one bad value
            var badObj = new Player();
            badObj.GameId = testGame.Id;
            badObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty1, Value = goodvalue });
            badObj.StateProperties.Add(new PlayerStateProperty { Name = testproperty2, Value = badvalue });

            //set up filter
            var statePropertiesToFilter = new List<StateProperty>() { };
            statePropertiesToFilter.Add(new PlayerStateProperty { Name = testproperty1, Value = goodvalue });
            statePropertiesToFilter.Add(new PlayerStateProperty { Name = testproperty2, Value = goodvalue });

            //post goodObj
            var response = await _client.PostAsync(
                "/api/Player", new StringContent(
                    JsonConvert.SerializeObject(goodObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            goodObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //post badObj
            response = await _client.PostAsync(
                "/api/Player", new StringContent(
                    JsonConvert.SerializeObject(badObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            badObj = JsonConvert.DeserializeObject<Player>(
                await response.Content.ReadAsStringAsync());

            //Act 
            response = await _client.PostAsync(
               String.Format("/api/Player/GetByStateProperties/{0}",testGame.Id), new StringContent(
                   JsonConvert.SerializeObject(statePropertiesToFilter)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );
            var gotObjects = JsonConvert.DeserializeObject<List<Player>>(
                    await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(1, gotObjects.Count());

            //Clean up
            await DeleteGameForCleanup(testGame);
        }

    }
}
