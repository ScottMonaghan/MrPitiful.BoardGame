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

namespace MrPitiful.BoardGame.Web.Test
{
    public class GameApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private async Task DeleteGameSetForCleanup(GameSet gameSet)
        {
            await _client.DeleteAsync(string.Format("/api/GameSet/{0}", gameSet.Id));
        }
        private async Task DeleteGameForCleanup(Game game)
        {
            await _client.DeleteAsync(string.Format("/api/Game/{0}", game.Id));
        }
        public GameApiShould()
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
            var testObj = new Game();

            //Act
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    ,Encoding.UTF8
                    ,"application/json"
                    )        
                );
            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Assert
            Assert.NotEqual(Guid.Empty, postedObj.Id);
            await DeleteGameForCleanup(postedObj);
        }

        [Fact]
        public async void PostAndGetById()
        {
            //Arrange
            var testObj = new Game();

            //Act
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/Game/{0}", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(postedObj.Id, gotObj.Id);
            await DeleteGameForCleanup(postedObj);
        }

        [Fact]
        public async void PostAndGetByIdWithStateProperties()
        {
            //Arrange
            var testObj = new Game();
            var testproperty1 = "testproperty1";
            var originalValue = "originalvalue";
            testObj.StateProperties.Add(new GameStateProperty { Name = testproperty1, Value = originalValue });

            //Act
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/Game/{0}?includeStateProperties=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(testObj.StateProperties.Count(), gotObj.StateProperties.Count());
            await DeleteGameForCleanup(postedObj);
        }

        [Fact]
        public async void PostAndGetByIdWithGameSet() {
            //Arrange
            var testObj = new Game();
            testObj.GameSet = new GameSet();

            //Act
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/Game/{0}?includeGameSet=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.NotEqual(Guid.Empty, postedObj.GameSet.Id);
            Assert.Equal(postedObj.GameSet.Id, gotObj.GameSet.Id);
            await DeleteGameSetForCleanup(postedObj.GameSet);
            await DeleteGameForCleanup(postedObj);
        }

        [Fact]
        public async void PostAndGetByIdWithPlayers()
        {
            //Assert.True(false);
            //Arrange
            var testObj = new Game();
            testObj.Players.Add(new Player());
            testObj.Players.Add(new Player());

            //Act
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );

            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Get
            response = await _client.GetAsync(
                    string.Format("/api/Game/{0}?includePlayers=true", postedObj.Id)
                );
            var gotObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Assert   
            Assert.Equal(2, postedObj.Players.Count());
            await DeleteGameForCleanup(postedObj);
        }

        [Fact]
        public async void Delete()
        {
            //Arrange
            var testObj = new Game();

            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(testObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Act
            await _client.DeleteAsync(string.Format("/api/Game/{0}",postedObj.Id));

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => {
                //Get
                response = await _client.GetAsync(
                        string.Format("/api/Game/{0}", postedObj.Id)
                    );
            });
        }

        [Fact]
        public async void PostAndGetByStateProperties()
        {
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var goodvalue = "goodvalue";
            var badvalue = "badvalue";

            //Arrange
            //set up good object with good values
            var goodObj = new Game();
            goodObj.StateProperties.Add(new GameStateProperty { Name = testproperty1, Value = goodvalue });
            goodObj.StateProperties.Add(new GameStateProperty { Name = testproperty2, Value = goodvalue });
            //set up bad object with one bad value
            var badObj = new Game();
            badObj.StateProperties.Add(new GameStateProperty { Name = testproperty1, Value = goodvalue });
            badObj.StateProperties.Add(new GameStateProperty { Name = testproperty2, Value = badvalue });

            //set up filter
            var statePropertiesToFilter = new List<StateProperty>() { };
            statePropertiesToFilter.Add(new GameStateProperty { Name = testproperty1, Value = goodvalue });
            statePropertiesToFilter.Add(new GameStateProperty { Name = testproperty2, Value = goodvalue });

            //post goodObj
            var response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(goodObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            goodObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //post badObj
            response = await _client.PostAsync(
                "/api/Game", new StringContent(
                    JsonConvert.SerializeObject(badObj)
                    , Encoding.UTF8
                    , "application/json"
                    )
                );
            badObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Act 
            response = await _client.PostAsync(
               "/api/Game/GetByStateProperties", new StringContent(
                   JsonConvert.SerializeObject(statePropertiesToFilter)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );
            var gotObjects = JsonConvert.DeserializeObject<List<Game>>(
                    await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(1, gotObjects.Count());

            //Clean up
            //Delete goodObj & badObj
            await DeleteGameForCleanup(goodObj);
            await DeleteGameForCleanup(badObj);
        }

        [Fact]
        public async void SetAndChangeAStateProperty()
        {
            //Arrange
            var testObj = new Game();
            var testproperty1 = "testproperty1";
            var testproperty2 = "testproperty2";
            var originalValue = "originalValue";
            var updatedValue = "updatedValue";
            testObj.StateProperties.Add(new GameStateProperty { Name = testproperty1, Value = originalValue });
            testObj.StateProperties.Add(new GameStateProperty { Name = testproperty2, Value = originalValue });
            //Act 
            //Post test Object
            var response = await _client.PostAsync(
               "/api/Game", new StringContent(
                   JsonConvert.SerializeObject(testObj)
                   , Encoding.UTF8
                   , "application/json"
                   )
               );

            var postedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Get objectById with State Properties
            response = await _client.GetAsync(
                   string.Format("/api/Game/{0}?includeStateProperties=true", postedObj.Id)
               );
            var gotObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());//Assert

            //Assert
            //testproperty1 and testproperty2 should both be originalvalue
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, gotObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);

            //Arrange
            //now lets change testproperty1 to updatedValue without including any other stateproperties
            gotObj.StateProperties = new List<GameStateProperty>()
            {
                new GameStateProperty() {Name=testproperty1, Value=updatedValue }
            };

            //Act
            //update GotObj
            response = await _client.PutAsync(
                           "/api/Game", new StringContent(
                               JsonConvert.SerializeObject(gotObj)
                               , Encoding.UTF8
                               , "application/json"
                               )
                           );
            response = await _client.GetAsync(
                   string.Format("/api/Game/{0}?includeStateProperties=true", gotObj.Id)
               );
            var updatedObj = JsonConvert.DeserializeObject<Game>(
                await response.Content.ReadAsStringAsync());

            //Assert
            //testproperty1 should be updatedValue and testproperty2 should be originalvalue
            Assert.Equal(updatedValue, updatedObj.StateProperties.Where(x => x.Name == testproperty1).Single().Value);
            Assert.Equal(originalValue, updatedObj.StateProperties.Where(x => x.Name == testproperty2).Single().Value);
            await DeleteGameForCleanup(postedObj);
        }
    }
}
