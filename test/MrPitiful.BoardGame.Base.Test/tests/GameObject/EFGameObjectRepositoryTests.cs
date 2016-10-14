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
    public class EFGameObjectRepositoryTests
    {
        private readonly GameObjectDbContext _context;
        private EFGameObjectRepository _efGameObjectRepository;

        public EFGameObjectRepositoryTests()
        {
            _context = new GameObjectDbContext(CreateNewContextOptions());
            _efGameObjectRepository = new GenericEFGameObjectRepository(_context, new GenericGameObject());
        }

        private static DbContextOptions<GameObjectDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<GameObjectDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Fact]
        public async Task CreateAndRetrieveOneGameObjectById()
        {
            //arrange
            string testProperty = "testProperty";
            string testValue = "testValue";

            //create a new gameObject
            var initialGameObject = new GameObject();
            initialGameObject.State[testProperty] = testValue;

            //act 
            var createdGameObject = await _efGameObjectRepository.Create(initialGameObject);

            //assert
            var gotGameObject = await _efGameObjectRepository.Get(createdGameObject.Id);
            Assert.Equal(testValue, gotGameObject.State[testProperty]);
            
        }

        [Fact]
        public async Task CreateAndRetrieveTwoGameObjects()
        {
            //arrange
 
            //create a new gameObjects
            var initialGameObject1 = new GameObject();
            var initialGameObject2 = new GameObject();

            //act 
            var createdGameObject1 = await _efGameObjectRepository.Create(initialGameObject1);
            var createdGameObject2 = await _efGameObjectRepository.Create(initialGameObject2);

            //assert
            var gotGameObjects = await _efGameObjectRepository.Get();
            Assert.Equal(2, gotGameObjects.Count);
        }

        [Fact]
        public async Task CreateAndDeleteAGameObject()
        {
            //arrange

            //create a new gameObjects
            var initialGameObject1 = new GameObject();
            var initialGameObject2 = new GameObject();

            //act 
            var createdGameObject1 = await _efGameObjectRepository.Create(initialGameObject1);
            var createdGameObject2 = await _efGameObjectRepository.Create(initialGameObject2);
            await _efGameObjectRepository.Delete(initialGameObject2);

            //assert
            var gotGameObjects = await _efGameObjectRepository.Get();
            Assert.Equal(1, gotGameObjects.Count);
        }

        [Fact]
        public async Task GetObjectsByStateProperties()
        {
            //Arrange
            //create fake GameId
            Guid gameId = Guid.NewGuid();

            //define test state properties
            string property1 = "property1";
            string property2 = "property2";
            string goodValue = "goodValue";
            string badValue = "badValue";

            //create first gameObject
            var createdGameObject1 = new GameObject();
            //set the game id for gameObject1
            createdGameObject1.GameId = gameId;
            //create second gameObject
            var createdGameObject2 = new GameObject();
            //set the game id for gameObject2
            createdGameObject2.GameId = gameId;

            //set properties of first gameObject to return
            createdGameObject1.State[property1] = goodValue;
            createdGameObject1.State[property2] = goodValue;

            //set properites of second game to NOT return
            createdGameObject2.State[property1] = goodValue;
            createdGameObject2.State[property2] = badValue;

            //save the games
            await _efGameObjectRepository.Create(createdGameObject1);
            await _efGameObjectRepository.Create(createdGameObject2);

            //Act
            //Get list of gameObjects where both properties are good
            var gotGameObjects = await _efGameObjectRepository.GetByStateProperties(gameId,
               new Dictionary<string,string>(){
                   {property1, goodValue},
                   {property2, goodValue}
                });

            //Assert that only one gameObject returns
            Assert.Equal(1, gotGameObjects.Count);

            //Assert that the Guid is the same as createdGameObject1
            Assert.Equal(gotGameObjects[0].Id, createdGameObject1.Id);
        }
    }
}
