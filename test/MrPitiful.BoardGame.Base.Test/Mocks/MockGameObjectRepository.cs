﻿using System;
using System.Collections.Generic;

namespace MrPitiful.BoardGame.Base.Test
{
    public class MockGameObjectRepository : IGameObjectRepository
    {
        public bool Saved = false;

        public IGameObject Create(IGameObject gameObject)
        {
            return gameObject;
        }

        public void Delete(IGameObject gameObject)
        {
            //do nothing
        }

        public Dictionary<Guid, IGameObject> Get()
        {
            return new Dictionary<Guid, IGameObject>();
        }

        public IGameObject Get(Guid Id)
        {
            GenericGameObject gameObject = new GenericGameObject();
            gameObject.Id = Id;
            return gameObject;
        }

        public List<IGameObject> GetByList(List<Guid> Ids)
        {
            throw new NotImplementedException();
        }

        public List<IGameObject> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            return new List<IGameObject>();
        }

        public void Save(IGameObject gameObject)
        {
            Saved = true;
        }
    }
}
