using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Test
{
    public class MockGameObjectRepository : IGameObjectRepository
    {
        public bool Saved = false;

        public async Task<IGameObject> Create(IGameObject gameObject)
        {
            return gameObject;
        }

        public async Task Delete(IGameObject gameObject)
        {
            //do nothing
        }

        public async Task<Dictionary<Guid, IGameObject>> Get()
        {
            return new Dictionary<Guid, IGameObject>();
        }

        public async Task<IGameObject> Get(Guid Id)
        {
            GenericGameObject gameObject = new GenericGameObject();
            gameObject.Id = Id;
            return gameObject;
        }

        public async Task<List<IGameObject>> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            return new List<IGameObject>();
        }

        public async Task Save(IGameObject gameObject)
        {
            Saved = true;
        }
    }
}
