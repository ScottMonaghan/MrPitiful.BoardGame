using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.BoardGame.Base.Repositories.Interfaces
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
