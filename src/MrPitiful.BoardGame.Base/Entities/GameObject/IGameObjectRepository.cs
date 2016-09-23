using System;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameObjectRepository
    {
        Dictionary<Guid, IGameObject> Get();
        IGameObject Get(Guid Id);
        List<IGameObject> GetByStateProperties(Dictionary<string, string> stateProperties);
        IGameObject Create(IGameObject gameObject);
        void Save(IGameObject gameObject);
        void Delete(IGameObject gameObject);
    }
}
