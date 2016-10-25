using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MrPitiful.BoardGame.Base
{
    public abstract class EFGameObjectRepository : IGameObjectRepository
    {
        private GameObjectDbContext _context;

        public EFGameObjectRepository(GameObjectDbContext context, IGameObject gameObject)
        {
            _context = context;
        }

        public IGameObject Create(IGameObject gameObject)
        {
            _context.GameObjects.Add(gameObject);
            _context.SaveChanges();
            return gameObject;
        }

        public Dictionary<Guid,IGameObject> Get()
        {
            return  _context.GameObjects.ToDictionary(x => x.Id);
        }

        public IGameObject Get(Guid Id)
        {
            return _context.GameObjects.Single(o => o.Id == Id);
        }
    
        public void Save(IGameObject gameObject)
        {
            //save game here
            //this can be removed
        }

        public void Delete(IGameObject gameObject)
        {
            _context.GameObjects.Remove(gameObject);
            _context.SaveChanges();
        }

        public List<IGameObject> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            /*this an ugly call to sql and I'd rather filter on SQL side rather than pass all this data over*/
            List < IGameObject > filtereddGameObjects = _context.GameObjects.Where(x => x.GameId == gameId).ToList();    
            foreach (KeyValuePair<string,string> stateProperty in stateProperties)
            {
                filtereddGameObjects = (filtereddGameObjects.Where(x => x.State[stateProperty.Key] == stateProperty.Value)).ToList();
            }
            return filtereddGameObjects;
        }
    }
}
