using System;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameObjectRepository
    {
        Dictionary<Guid, IGameObject> Get();
        IGameObject Get(Guid Id);
        //List<IGameObject> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties);
        List<IGameObject> GetByList(List<Guid> Ids);
        IGameObject Create(IGameObject gameObject);
        void Save(IGameObject gameObject);
        void Delete(IGameObject gameObject);
    }
}
