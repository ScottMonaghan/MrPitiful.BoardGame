using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Services.Interfaces;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;

namespace MrPitiful.BoardGame.Base.Services
{
    public class GameObjectNotFoundException : Exception {}
    
    public abstract class GameObjectService : IGameObjectService
    {
        private IGameObjectRepository _gameObjectRepository;
        

        public GameObjectService(IGameObjectRepository gameObjectRepository)
        {
            _gameObjectRepository = gameObjectRepository;   
        }

        public IGameObject Create(IGameObject gameObject)
        {
            return _gameObjectRepository.Create(gameObject);
        }

        public Dictionary<Guid,IGameObject> Get(){
            return _gameObjectRepository.Get();
        }

        public IGameObject Get(Guid id)
        {
            return _gameObjectRepository.Get(id);
        }

        public string GetStateProperty(IGameObject gameObject, string propertyName)
        {
            return gameObject.State[propertyName];
        }

        public void SetStateProperty(IGameObject gameObject, string propertyName, string propertyValue)
        {
            gameObject.State[propertyName] = propertyValue;
            _gameObjectRepository.Save(gameObject);
        }

        public abstract void BeforeGameStep(string gameStep, object Parameters);

        public abstract void DuringGameStep(string gameStep, object Parameters);

        public abstract void AfterGameStep(string gameStep, object Parameters);
    }
}
