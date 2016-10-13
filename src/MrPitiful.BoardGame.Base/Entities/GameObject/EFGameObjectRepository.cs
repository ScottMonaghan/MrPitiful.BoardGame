using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base
{
    public abstract class EFGameObjectRepository : IGameObjectRepository
    {
        private GameObjectDbContext _context;

        public EFGameObjectRepository(GameObjectDbContext context, GameObject gameObject)
        {
            _context = context;
        }

        public async Task<GameObject> Create(GameObject gameObject)
        {
            _context.GameObjects.Add(gameObject);
            await _context.SaveChangesAsync();
            return gameObject;
        }

        public async Task<Dictionary<Guid,GameObject>> Get()
        {
            return await _context.GameObjects.ToDictionaryAsync(x => x.Id);
        }

        public async Task<GameObject> Get(Guid Id)
        {
            return await _context.GameObjects.SingleAsync(o => o.Id == Id);
        }
    
        public async Task Save(GameObject gameObject)
        {
           await _context.SaveChangesAsync();
        }

        public async Task Delete(GameObject gameObject)
        {
            _context.GameObjects.Remove(gameObject);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GameObject>> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties)
        {
            /*this an ugly call to sql and I'd rather filter on SQL side rather than pass all this data over*/
            List < GameObject > filtereddGameObjects = await _context.GameObjects.Where(x => x.GameId == gameId).ToListAsync();    
            foreach (KeyValuePair<string,string> stateProperty in stateProperties)
            {
                filtereddGameObjects = (filtereddGameObjects.Where(x => x.State[stateProperty.Key] == stateProperty.Value)).ToList();
            }
            return filtereddGameObjects;
        }
    }
}
