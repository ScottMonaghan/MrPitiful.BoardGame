using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    //now we can run our unit tests against Generic Game!
    public class GameObjectTests
    {
        [Fact]
        public void GameObjectTest()
        {
            //check to make sure state is initialized
            GenericGameObject gameObject = new GenericGameObject();
            Assert.NotNull(gameObject.State);
        }

        [Fact]
        public void IdTest()
        {
            //test get / set of GenericGameObject.Id;
            GenericGameObject gameObject = new GenericGameObject();
            Guid id = Guid.NewGuid();
            gameObject.Id = id;
            Assert.Equal<Guid>(id, gameObject.Id);
        }
    }
}
