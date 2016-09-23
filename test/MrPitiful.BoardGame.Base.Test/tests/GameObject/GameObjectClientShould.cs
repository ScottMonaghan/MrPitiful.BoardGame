using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameObjectClientShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public GameObjectClientShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void ReturnAListOfEmptyGameObjects()
        {
            //Arrange 
            //Create new GameObjectClient
            GenericGameObjectClient gameObjectClient
                = new GenericGameObjectClient(
                        _client
                        );
            //Act
            var result = await gameObjectClient.Get();

            //Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }


        [Fact]
        public async void ReturnAGameObjectWithAGuidAfterCreate()
        {
            //Arrange 
            //Create new GameObjectClient
            GenericGameObjectClient gameObjectClient
                = new GenericGameObjectClient(_client);

            var response = await gameObjectClient.Create();
            GenericGameObject result = (GenericGameObject)response;
            //Assert
            Assert.True(result.Id != Guid.Empty);
        }

        [Fact]
        public async void GetAGameByIdAfterCreatingIt()
        {
            //Arrange 
            //Create new GameObjectClient
            GenericGameObjectClient gameObjectClient
                = new GenericGameObjectClient(_client);

            GenericGameObject createdGameObject = await gameObjectClient.Create();
            GenericGameObject gotGameObject = await gameObjectClient.Get(createdGameObject.Id);

            //Assert
            Assert.Equal<Guid>(createdGameObject.Id, gotGameObject.Id);
        }

        [Fact]
        public async void GetAStatePropertyAfterSettingIt()
        {
            //Arrange 
            //Create new GameObjectClient
            GenericGameObjectClient gameObjectClient
                = new GenericGameObjectClient(_client);
            string propertyName = "name";
            string setValue = "value";

            //Create a gameobject
            GenericGameObject createdGameObject = await gameObjectClient.Create();

            //Act
            //Set a State Property
            await gameObjectClient.SetStateProperty(createdGameObject.Id, propertyName, setValue);
            string gotValue = await gameObjectClient.GetStateProperty(createdGameObject.Id, propertyName);
            //Assert
            Assert.Equal(setValue, gotValue);
        }

        [Fact]
        public async void ReturnAListOfGameObjectsByStateProperties()
        {
            //Arrange
            //Create new GameObjectClient
            GenericGameObjectClient gameObjectClient
                = new GenericGameObjectClient(_client);
            //define test state properties
            string property1 = "property1";
            string property2 = "property2";
            string goodValue = "goodValue";
            string badValue = "badValue";
            Guid gameId = Guid.NewGuid();

            //create first gameObject
            GenericGameObject createdGameObject1 = await gameObjectClient.Create();
            //add gameId to createdGameObject1
            await gameObjectClient.SetGameId(createdGameObject1.Id, gameId);

            //create second gameObject
            GenericGameObject createdGameObject2 = await gameObjectClient.Create();
            //add gameId to createdGameObject1
            await gameObjectClient.SetGameId(createdGameObject2.Id, gameId);

            //set properties of first game to return
            await gameObjectClient.SetStateProperty(createdGameObject1.Id, property1, goodValue);
            await gameObjectClient.SetStateProperty(createdGameObject1.Id, property2, goodValue);
            //set properites of second game to NOT return
            await gameObjectClient.SetStateProperty(createdGameObject2.Id, property1, goodValue);
            await gameObjectClient.SetStateProperty(createdGameObject2.Id, property2, badValue);

            //Act
            //Get list of gameObjects where both properties are set to goodValue
            Dictionary<string, string> stateProperties = new Dictionary<string, string>();
            stateProperties[property1] = goodValue;
            stateProperties[property2] = goodValue;

            List<GenericGameObject> gotGameObjects = await gameObjectClient.GetByStateProperties(gameId, stateProperties);

            //Assert that only one gameObject returns
            Assert.Equal(1, gotGameObjects.Count);

            //Assert that the Guid is the same as createdGameObject1
            Assert.Equal<Guid>(gotGameObjects[0].Id, createdGameObject1.Id);
        }

        [Fact]
        public async void SetAndGetGameId()
        {
            //Arrange
            //Create new GameObjectClient
            GenericGameObjectClient gameObjectClient
                = new GenericGameObjectClient(_client);

            //Create a gameObject
            GenericGameObject createdGameObject = await gameObjectClient.Create();

            //Act
            //set the gameId
            Guid newGameId = Guid.NewGuid();
            await gameObjectClient.SetGameId(createdGameObject.Id, newGameId);

            //Assert
            //make sure we get the Id that was just set and that it is the correct value 
            Guid gotGameId = await gameObjectClient.GetGameId(createdGameObject.Id);

            Assert.Equal<Guid>(newGameId, gotGameId);
        }
    }
}