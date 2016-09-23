using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameObjectApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameObjectApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void ReturnAListOfEmptyGameObjects()
        {
            //Act
            var response = await _client.GetAsync("/api/genericGameObject/");
            var result = JsonConvert.DeserializeObject<Dictionary<Guid,GenericGameObject>>(
                    response.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async void ReturnAGameObjectWithAGuidAfterCreate()
        {
            var response = await _client.GetAsync("/api/genericGameObject/create");
            GenericGameObject result = JsonConvert.DeserializeObject<GenericGameObject>(
                    response.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.True(result.Id != Guid.Empty);
        }

        [Fact]
        public async void GetAGameByIdAfterCreatingIt()
        {
            var response1 = await _client.GetAsync("/api/genericGameObject/create");
            GenericGameObject createdGameObject = JsonConvert.DeserializeObject<GenericGameObject>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var response2 = await _client.GetAsync(String.Format("/api/genericGameObject/{0}", createdGameObject.Id));
            GenericGameObject gotGameObject = JsonConvert.DeserializeObject<GenericGameObject>(
                    response2.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.Equal<Guid>(createdGameObject.Id, gotGameObject.Id);
        }

        [Fact]
        public async void GetAStatePropertyAfterSettingIt()
        {
            //Arrange
            string propertyName = "name";
            string setValue = "value";

            //Create a gameobject
            var response = await _client.GetAsync("/api/genericGameObject/create");
            GenericGameObject createdGameObject = JsonConvert.DeserializeObject<GenericGameObject>(
                    response.Content.ReadAsStringAsync().Result
                );
            //clear the response.
            response.Dispose();

            //Act
            //Set a State Property
            response = await _client.GetAsync(string.Format("/api/genericGameObject/SetStateProperty/{0}/{1}/{2}", createdGameObject.Id, propertyName, setValue));
            response.Dispose();
            response = await _client.GetAsync(string.Format("/api/genericGameObject/getStateProperty/{0}/{1}", createdGameObject.Id, propertyName));
            string returnedValue = response.Content.ReadAsStringAsync().Result;
  
            //Assert
            Assert.Equal(setValue, returnedValue);
        }

        [Fact]
        public async void ReturnAListOfGameObjectsByStateProperties()
        {
            //Arrange
            //define test state properties
            string property1 = "property1";
            string property2 = "property2";
            string goodValue = "goodValue";
            string badValue = "badValue";

            //create first gameObject
            var response = await _client.GetAsync("/api/genericGameObject/create");
            GenericGameObject createdGameObject1 = JsonConvert.DeserializeObject<GenericGameObject>(
                    response.Content.ReadAsStringAsync().Result
                );
            //clear the response.
            response.Dispose();

            //create second gameObject
            response = await _client.GetAsync("/api/genericGameObject/create");
            GenericGameObject createdGameObject2 = JsonConvert.DeserializeObject<GenericGameObject>(
                    response.Content.ReadAsStringAsync().Result
                );
            //clear the response.
            response.Dispose();

            //set properties of first game to return
            response = await _client.GetAsync(string.Format("/api/genericGameObject/SetStateProperty/{0}/{1}/{2}", createdGameObject1.Id, property1, goodValue));
            response.Dispose();
            response = await _client.GetAsync(string.Format("/api/genericGameObject/SetStateProperty/{0}/{1}/{2}", createdGameObject1.Id, property2, goodValue));
            response.Dispose();

            //set properites of second game to return
            response = await _client.GetAsync(string.Format("/api/genericGameObject/SetStateProperty/{0}/{1}/{2}", createdGameObject2.Id, property1, goodValue));
            response.Dispose();
            response = await _client.GetAsync(string.Format("/api/genericGameObject/SetStateProperty/{0}/{1}/{2}", createdGameObject2.Id, property2, badValue));
            response.Dispose();

            //Act
            //Get list of gameObjects where both properties 
            response = await _client.GetAsync(String.Format("/api/genericGameObject/GetByStateProperties/{0}:{1}/{2}:{3}",property1, goodValue, property2, goodValue));
            List<GenericGameObject> gotGameObjects = JsonConvert.DeserializeObject<List<GenericGameObject>>(
                    response.Content.ReadAsStringAsync().Result
             );


            //Assert that only one gameObject returns
            Assert.Equal(1, gotGameObjects.Count);

            //Assert that the Guid is the same as createdGameObject1
            Assert.Equal<Guid>(gotGameObjects[0].Id, createdGameObject1.Id);
        }
    }
}
