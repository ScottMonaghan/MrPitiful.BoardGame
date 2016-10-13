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
        private EFGameObjectRepository _efGameRepository;

        public EFGameObjectRepositoryTests()
        {
            _context = new GameObjectDbContext(CreateNewContextOptions());
            _efGameRepository = new GenericEFGameObjectRepository(_context, new GenericGameObject());
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
        public async Task CreateAndRetrieve()
        {
            //arrange
            string testProperty = "testProperty";
            string testValue = "testValue";

            //create a new gameObject
            var initialGameObject = new GenericGameObject();
            initialGameObject.State[testProperty] = testValue;

            //act 
            var createdGameObject = await _efGameRepository.Create(initialGameObject);

            //assert
            var gotGameObject = await _efGameRepository.Get(createdGameObject.Id);
            Assert.Equal(testValue, gotGameObject.State[testProperty]);
            
        }

    }
}
