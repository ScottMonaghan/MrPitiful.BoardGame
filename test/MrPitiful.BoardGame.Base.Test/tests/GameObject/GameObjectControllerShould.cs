using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MrPitiful.BoardGame.Base.Test
{
    //now we can run our unit tests against Generic Game!
    public class GameObjectControllerShould
    {
        private readonly BoardGameDbContext _context;
        private readonly GameObjectController _gameObjectController;

        public GameObjectControllerShould()
        {
            _context = new BoardGameDbContext(CreateNewContextOptions());
            _gameObjectController = new GameObjectController(_context);
        }

        private static DbContextOptions<BoardGameDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<BoardGameDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Fact]
        public async Task PostAndGetAnEmptyGameObject()
        {
            //Arrange

            //Act 
            await _gameObjectController.Post();

            //Assert
            Assert.Equal(1, (await _gameObjectController.Get()).Count); 
        }

        [Fact]
        public async Task PostAGameObjectWithGameIdAndGetById()
        {
            //Arrange
            Guid testGameBoxId = Guid.NewGuid();
            GameObject testGameObject = new GameObject() { GameBoxId = testGameBoxId };

            //Act 
            GameObject postedGameObject = await _gameObjectController.Post(testGameObject);

            //Assert
            Assert.Equal(testGameBoxId, (await _gameObjectController.Get(postedGameObject.Id)).GameBoxId);
        }

        [Fact]
        public async Task PostAndPutGameObject()
        {
            //Arrange
            Guid testGameBoxId = Guid.NewGuid();
            Guid updatedGameBoxId = Guid.NewGuid();
            //post a game object
            GameObject postedGameObject = await _gameObjectController.Post(new GameObject() { GameBoxId = testGameBoxId });
            //change GameBoxId
            postedGameObject.GameBoxId = updatedGameBoxId;

            //Act 
            await _gameObjectController.Put(postedGameObject);

            Assert.Equal(updatedGameBoxId, (await _gameObjectController.Get(postedGameObject.Id)).GameBoxId);
        }

        [Fact]
        public async Task PostAndDeleteGameObject()
        {
            //Arrange 
            GameObject postedGameObject = await _gameObjectController.Post();

            //Act
            await _gameObjectController.Delete(postedGameObject.Id);
            
            //Assert
            Assert.Equal(0, (await _gameObjectController.Get()).Count);
        }

        [Fact]
        public async Task SetAndGetStateProperty()
        {
            //arrange
            string propertyName = "propertyName";
            string propertyValue = "propertyValue";
            GameObject postedGameObject = await _gameObjectController.Post();
            //act
            await _gameObjectController.SetStateProperty(postedGameObject.Id, propertyName, propertyValue);

            //assert
            Assert.Equal(propertyValue, (await _gameObjectController.GetStateProperty(postedGameObject.Id, propertyName)).Value);
        }

        [Fact]
        public async Task SetUpdateAndGetStateProperty()
        {
            //arrange
            string propertyName = "propertyName";
            string originalPropertyValue = "originalPropertyValue";
            string updatedPropertyValue = "updatedPropertyValue";
            GameObject postedGameObject = await _gameObjectController.Post();
            //act
            await _gameObjectController.SetStateProperty(postedGameObject.Id, propertyName, originalPropertyValue);
            await _gameObjectController.SetStateProperty(postedGameObject.Id, propertyName, updatedPropertyValue);

            //assert
            Assert.Equal(updatedPropertyValue, (await _gameObjectController.GetStateProperty(postedGameObject.Id, propertyName)).Value);
        }

        [Fact]
        public async Task GetAGameObjectByStateProperties()
        {
            /*
             * For this test we'll create two gameObjects
             * We'll set two state properties for each
             * Only the first gameObject should return based 
             * on the state properties we set 
            */


            //arrange
            Guid mockGameBoxId = Guid.NewGuid();
            string statePropertyName1 = "statePropertyName1";
            string statePropertyName2 = "statePropertyName2";
            string statePropertyGoodValue = "statePropertyGoodValue";
            string statePropertyBadValue = "statePropertyBadValue";

            //create filter
            var statePropertiesToFilter = new List<StateProperty>()
            {
                new StateProperty() {Name = statePropertyName1, Value = statePropertyGoodValue},
                new StateProperty() {Name = statePropertyName2, Value = statePropertyGoodValue}
            };

            //create good game object we expect to return with state that match filter
            var goodGameObject = new GameObject()
            {
                GameBoxId = mockGameBoxId,
                StateProperties = new List<StateProperty> {
                    new StateProperty() {Name = statePropertyName1, Value = statePropertyGoodValue},
                    new StateProperty() {Name = statePropertyName2, Value = statePropertyGoodValue}
                }
            };

            //create bad game object we DON'T expect to return with state properties that don't match filter
            var badGameObject = new GameObject()
            {
                GameBoxId = mockGameBoxId,
                StateProperties = new List<StateProperty> {
                    new StateProperty() {Name = statePropertyName1, Value = statePropertyGoodValue},
                    new StateProperty() {Name = statePropertyName2, Value = statePropertyBadValue}
                }
            };

            //post the games
            goodGameObject = await _gameObjectController.Post(goodGameObject);
            badGameObject = await _gameObjectController.Post(badGameObject);

            //act
            //get games filtered by stateproperties
            var gotGameObjects = await _gameObjectController.GetByStateProperties(
                mockGameBoxId, 
                statePropertiesToFilter
                );

            //assert
            Assert.Equal(1, gotGameObjects.Count());
            Assert.Equal(goodGameObject.Id, gotGameObjects[0].Id);
        }

    }
}
