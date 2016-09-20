using System;
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
        
    }
}
