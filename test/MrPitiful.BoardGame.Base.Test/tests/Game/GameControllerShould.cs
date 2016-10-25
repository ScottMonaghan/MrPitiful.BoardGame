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
    public class GameControllerShould
    {
        private readonly BoardGameDbContext _context;
        private readonly GameController _gameController;

        public GameControllerShould()
        {
            _context = new BoardGameDbContext(CreateNewContextOptions());
            _gameController = new GameController(_context);
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
        public async Task PostAndGetAnEmptyGame()
        {
            //Arrange

            //Act 
            await _gameController.Post();

            //Assert
            Assert.Equal(1, (await _gameController.Get()).Count); 
        }

        [Fact]
        public async Task PostAGameWithGameIdAndGetById()
        {
            //Arrange
            Guid testGameBoxId = Guid.NewGuid();
            Game testGame = new Game() { GameBoxId = testGameBoxId };

            //Act 
            Game postedGame = await _gameController.Post(testGame);

            //Assert
            Assert.Equal(testGameBoxId, (await _gameController.Get(postedGame.Id)).GameBoxId);
        }

        [Fact]
        public async Task PostAndPutGame()
        {
            //Arrange
            Guid testGameBoxId = Guid.NewGuid();
            Guid updatedGameBoxId = Guid.NewGuid();
            //post a game object
            Game postedGame = await _gameController.Post(new Game() { GameBoxId = testGameBoxId });
            //change GameBoxId
            postedGame.GameBoxId = updatedGameBoxId;

            //Act 
            await _gameController.Put(postedGame);

            Assert.Equal(updatedGameBoxId, (await _gameController.Get(postedGame.Id)).GameBoxId);
        }

        [Fact]
        public async Task PostAndDeleteGame()
        {
            //Arrange 
            Game postedGame = await _gameController.Post();

            //Act
            await _gameController.Delete(postedGame.Id);
            
            //Assert
            Assert.Equal(0, (await _gameController.Get()).Count);
        }

        [Fact]
        public async Task SetAndGetStateProperty()
        {
            //arrange
            string propertyName = "propertyName";
            string propertyValue = "propertyValue";
            Game postedGame = await _gameController.Post();
            //act
            await _gameController.SetStateProperty(postedGame.Id, propertyName, propertyValue);

            //assert
            Assert.Equal(propertyValue, (await _gameController.GetStateProperty(postedGame.Id, propertyName)).Value);
        }

        [Fact]
        public async Task SetUpdateAndGetStateProperty()
        {
            //arrange
            string propertyName = "propertyName";
            string originalPropertyValue = "originalPropertyValue";
            string updatedPropertyValue = "updatedPropertyValue";
            Game postedGame = await _gameController.Post();
            //act
            await _gameController.SetStateProperty(postedGame.Id, propertyName, originalPropertyValue);
            await _gameController.SetStateProperty(postedGame.Id, propertyName, updatedPropertyValue);

            //assert
            Assert.Equal(updatedPropertyValue, (await _gameController.GetStateProperty(postedGame.Id, propertyName)).Value);
        }

        [Fact]
        public async Task GetAGameByStateProperties()
        {
            /*
             * For this test we'll create two games
             * We'll set two state properties for each
             * Only the first game should return based 
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
            var goodGame = new Game()
            {
                GameBoxId = mockGameBoxId,
                StateProperties = new List<StateProperty> {
                    new StateProperty() {Name = statePropertyName1, Value = statePropertyGoodValue},
                    new StateProperty() {Name = statePropertyName2, Value = statePropertyGoodValue}
                }
            };

            //create bad game object we DON'T expect to return with state properties that don't match filter
            var badGame = new Game()
            {
                GameBoxId = mockGameBoxId,
                StateProperties = new List<StateProperty> {
                    new StateProperty() {Name = statePropertyName1, Value = statePropertyGoodValue},
                    new StateProperty() {Name = statePropertyName2, Value = statePropertyBadValue}
                }
            };

            //post the games
            goodGame = await _gameController.Post(goodGame);
            badGame = await _gameController.Post(badGame);

            //act
            //get games filtered by stateproperties
            var gotGames = await _gameController.GetByStateProperties(
                mockGameBoxId, 
                statePropertiesToFilter
                );

            //assert
            Assert.Equal(1, gotGames.Count());
            Assert.Equal(goodGame.Id, gotGames[0].Id);
        }

    }
}
