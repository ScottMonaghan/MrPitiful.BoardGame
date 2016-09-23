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

        public List<IGameObject> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            List<IGameObject> filtereddGameObjects = _gameObjects.Values.ToList().Where(x => x.GameId == gameId).ToList();

            foreach (KeyValuePair<string,string> stateProperty in stateProperties)
            {
                filtereddGameObjects = (filtereddGameObjects.Where(x => x.State[stateProperty.Key] == stateProperty.Value)).ToList();
            }

            return filtereddGameObjects;
        }
    }
}
