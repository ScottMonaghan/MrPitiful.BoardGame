using System;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base
{
    public interface IStatePropertyRepository
    {
        string Get(Guid gameObjectId, string name);
        void Set(Guid gameId, Guid GameObjectId, string name, string value);
        void Delete(Guid GameObjectId, string name);
        List<Guid> GetGameGameObjectIdsByStateProperties(Guid gameId, List<StateProperty> stateProperties);
    }
}
