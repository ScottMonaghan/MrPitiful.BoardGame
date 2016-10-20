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
    public class GameBoardSpaceControllerShould
    {
        private readonly BoardGameDbContext _context;
        private readonly GameBoardSpaceController _gameBoardSpaceController;

        public GameBoardSpaceControllerShould()
        {
            _context = new BoardGameDbContext(CreateNewContextOptions());
            _gameBoardSpaceController = new GameBoardSpaceController(_context);
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
        public async Task PostAndGetAnAdjacentSpaceByDirection()
        {
            //Arrange
            //create parent and child spaces
            GameBoardSpace parentSpace = (GameBoardSpace)await _gameBoardSpaceController.Post(new GameBoardSpace());
            GameBoardSpace childSpace = (GameBoardSpace)await _gameBoardSpaceController.Post(new GameBoardSpace());
            string direction = "direction";

            //Act 
            await _gameBoardSpaceController.PostAdjacentSpace(parentSpace.Id, childSpace.Id, direction);

            //Assert
            Assert.Equal(childSpace.Id, (await _gameBoardSpaceController.GetAdjacentSpaceByDirection(parentSpace.Id, direction)).Id);
        }

        [Fact]
        public async Task UpdateAndGetAnAdjacentSpaceByDirection()
        {
            //Arrange
            //create parent and child spaces
            GameBoardSpace parentSpace = (GameBoardSpace)await _gameBoardSpaceController.Post(new GameBoardSpace());
            GameBoardSpace childSpace1 = (GameBoardSpace)await _gameBoardSpaceController.Post(new GameBoardSpace());
            GameBoardSpace childSpace2 = (GameBoardSpace)await _gameBoardSpaceController.Post(new GameBoardSpace());
            string direction = "direction";
            await _gameBoardSpaceController.PostAdjacentSpace(parentSpace.Id, childSpace1.Id, direction);

            //Act 
            await _gameBoardSpaceController.PostAdjacentSpace(parentSpace.Id, childSpace2.Id, direction);

            //Assert
            Assert.Equal(childSpace2.Id, (await _gameBoardSpaceController.GetAdjacentSpaceByDirection(parentSpace.Id, direction)).Id);
        }
    }
}
