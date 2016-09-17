using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.BoardGame.Base.Services.Interfaces
{
    public interface IGameObjectService
    {
        IGameObject Create(IGameObject gameObject);
        Dictionary<Guid, IGameObject> Get();
        IGameObject Get(Guid Id);
        void SetStateProperty(IGameObject gameObject, string propertyName, string propertyValue);
        string GetStateProperty(IGameObject gameObject, string propertyName);
        void BeforeGameStep(string gameStep, object Parameters);
        void DuringGameStep(string gameStep, object Parameters);
        void AfterGameStep(string gameStep, object Parameters);
    }
}
