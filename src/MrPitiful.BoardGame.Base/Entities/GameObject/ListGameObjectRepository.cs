using System;
using System.Linq;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGameObjectRepository : IGameObjectRepository
    {
        private Dictionary<Guid, IGameObject> _gameObjects;

        public ListGameObjectRepository(IGameObject gameObject)
        {
            _gameObjects = new Dictionary<Guid, IGameObject>();
        }

        public IGameObject Create(IGameObject gameObject)
        {
            gameObject.Id = Guid.NewGuid();
            _gameObjects.Add(gameObject.Id, gameObject);
            return gameObject;
        }

        public Dictionary<Guid,IGameObject> Get()
        {
            return _gameObjects;
        }

        public IGameObject Get(Guid Id)
        {
            return _gameObjects[Id];
        }
    
        public void Save(IGameObject gameObject)
        {
            //save game here
        }

        public void Delete(IGameObject gameObject)
        {
            _gameObjects.Remove(gameObject.Id);
        }

        public List<IGameObject> GetByList(List<Guid> Ids)
        {
            return _gameObjects.Values.Where(go => Ids.Contains(go.Id)).ToList();
        }
      
    }
}
