using System;
using System.Collections.Generic;
using Xunit;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Services;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GameObjectServiceTests
    {

        [Fact]
        public void GameObjectServiceTest()
        {
            //test gameservice constructor.  Only no exceptions expected.
            MockGameObjectRepository gameObjectRepository = new MockGameObjectRepository();
            GenericGameObjectService gameObjectService = new GenericGameObjectService(gameObjectRepository);
        }
        
        [Fact]
        public void CreateTest()
        {
            //test to see if gameObjectRepository.Create is run.  Injected game should be the same as returned game.
            MockGameObjectRepository gameObjectRepository = new MockGameObjectRepository();
            GenericGameObjectService gameObjectService = new GenericGameObjectService(gameObjectRepository);
            GenericGameObject injectedGameObject = new GenericGameObject();
            GenericGameObject createdGameObject = (GenericGameObject)(gameObjectService.Create(injectedGameObject));
            Assert.Same(injectedGameObject, createdGameObject);
        }
        
        [Fact]
        public void GetTest()
        {
            //should return a dictionary of IGameObject
            MockGameObjectRepository gameObjectRepository = new MockGameObjectRepository();
            GenericGameObjectService gameObjectService = new GenericGameObjectService(gameObjectRepository);
            Assert.IsType(typeof(Dictionary<Guid, IGameObject>), gameObjectService.Get());
        }

        [Fact]
        public void SetStatePropertyTest()
        {
            //the added PlayerId should exist in GenericGameObject.PlayerIds
            MockGameObjectRepository gameObjectRepository = new MockGameObjectRepository();
            GenericGameObject gameObject = new GenericGameObject();
            GenericGameObjectService gameObjectService = new GenericGameObjectService(gameObjectRepository);
            String name = "name";
            String value = "value";
            gameObjectService.SetStateProperty(gameObject, name, value);
            Assert.Equal(value, gameObject.State[name]);
            Assert.True(gameObjectRepository.Saved);
        }

        [Fact]
        public void GetStatePropertyTest()
        {
            MockGameObjectRepository gameObjectRepository = new MockGameObjectRepository();
            GenericGameObject gameObject = new GenericGameObject();
            GenericGameObjectService gameObjectService = new GenericGameObjectService(gameObjectRepository);
            String name = "name";
            String value = "value";
            gameObjectService.SetStateProperty(gameObject, name, value);
            Assert.Equal(value, gameObjectService.GetStateProperty(gameObject, name));
        }


    }

}
