using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGameObjectRepository : IGameObjectRepository
    {
        private Dictionary<Guid, GameObject> _gameObjects;

        public ListGameObjectRepository(GameObject gameObject)
        {
            _gameObjects = new Dictionary<Guid, GameObject>();
        }

        public async Task<GameObject> Create(GameObject gameObject)
        {
            gameObject.Id = Guid.NewGuid();
            _gameObjects.Add(gameObject.Id, gameObject);
            return gameObject;
        }

        public async Task<Dictionary<Guid,GameObject>> Get()
        {
            return _gameObjects;
        }

        public async Task<GameObject> Get(Guid Id)
        {
            return _gameObjects[Id];
        }
    
        public async Task Save(GameObject gameObject)
        {
            //save game here
        }

        public async Task Delete(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject.Id);
        }

        public async Task<List<GameObject>> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            List<GameObject> filtereddGameObjects = _gameObjects.Values.ToList().Where(x => x.GameId == gameId).ToList();

            foreach (KeyValuePair<string,string> stateProperty in stateProperties)
            {
                filtereddGameObjects = (filtereddGameObjects.Where(x => x.State[stateProperty.Key] == stateProperty.Value)).ToList();
            }

            return filtereddGameObjects;
        }
    }
}
