using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Test
{
    public class MockGameObjectRepository : IGameObjectRepository
    {
        public bool Saved = false;

        public async Task<GameObject> Create(GameObject gameObject)
        {
            return gameObject;
        }

        public async Task Delete(GameObject gameObject)
        {
            //do nothing
        }

        public async Task<Dictionary<Guid, GameObject>> Get()
        {
            return new Dictionary<Guid, GameObject>();
        }

        public async Task<GameObject> Get(Guid Id)
        {
            GenericGameObject gameObject = new GenericGameObject();
            gameObject.Id = Id;
            return gameObject;
        }

        public async Task<List<GameObject>> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            return new List<GameObject>();
        }

        public async Task Save(GameObject gameObject)
        {
            Saved = true;
        }
    }
}
