using System;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameObjectRepository
    {
        Dictionary<Guid, IGameObject> Get();
        IGameObject Get(Guid Id);
        IGameObject Create(IGameObject gameObject);
        void Save(IGameObject gameObject);
        void Delete(IGameObject gameObject);
    }
}
