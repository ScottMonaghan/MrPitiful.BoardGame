using System;
using System.Collections.Generic;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;


namespace MrPitiful.BoardGame.Base.Repositories
{
    public abstract class ListGameObjectRepository : IGameObjectRepository
    {
        public ListGameObjectRepository(IGameObject gameObject)
        {
            _gameObjects = new Dictionary<Guid, IGameObject>();
        }

        private Dictionary<Guid, IGameObject> _gameObjects;

        public IGameObject Create(IGameObject gameObject)
        {
            gameObject.Id = Guid.NewGuid();
            _gameObjects.Add(gameObject.Id, gameObject);
            return gameObject;
        }

        public Dictionary<Guid,IGameObject> Get()
        {
            return _gameObjects;
        }

        public IGameObject Get(Guid Id)
        {
            return _gameObjects[Id];
        }
    
        public void Save(IGameObject gameObject)
        {
            //save game here
        }

        public void Delete(IGameObject gameObject)
        {
            _gameObjects.Remove(gameObject.Id);
        }

    }
}
