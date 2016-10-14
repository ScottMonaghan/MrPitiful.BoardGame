using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MrPitiful.BoardGame.Base
{
    public interface IGameObjectRepository
    {
        Task<Dictionary<Guid, GameObject>> Get();
        Task<GameObject> Get(Guid Id);
        Task<List<GameObject>> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties);
        Task<GameObject> Create(GameObject gameObject);
        Task Save(GameObject gameObject);
        Task Delete(GameObject gameObject);
    }
}
