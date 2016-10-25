using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MrPitiful.BoardGame.Base
{

    [Route("api/[controller]")]
    public abstract class GameObjectController : Controller
    {

        private BoardGameDbContext _context;
        //private IGameObject _gameObject;
        // GET api/values

        public GameObjectController(BoardGameDbContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]
        public virtual async Task<List<GameObject>> Get()
        {
            return await _context.GameObjects.ToListAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<GameObject> Get(Guid id)
        {
            return await _context.GameObjects.SingleAsync(gameObject => gameObject.Id == id);
        }
        
        [HttpPost]
        public virtual async Task<GameObject> Post()
        {
            return await Post(new GameObject());
        }

        [HttpPost]
        public virtual async Task<GameObject> Post([FromBody]GameObject gameObject)
        {
            _context.GameObjects.Add(gameObject);
            await _context.SaveChangesAsync();
            return gameObject;
        }

        [HttpPut]
        public virtual async Task<GameObject> Put([FromBody]GameObject gameObject)
        {
            _context.Attach(gameObject);
            _context.Entry(gameObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gameObject;
        }
        */
        [HttpPost("GetByStateProperties/{gameBoxId}")]
        public virtual async Task<List<GameObject>> GetByStateProperties(Guid gameBoxId, [FromBody]List<StateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.StateProperties.Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.GameObject.GameBoxId == gameBoxId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameobject
            .GroupBy(sp => sp.GameObject)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }

        // GET api/gameObject/GetGameStateProperty/12345/Name
        [HttpGet("GetStateProperty/{gameObjectId}/{name}")]
        public async Task<StateProperty> GetStateProperty(Guid gameObjectId, string name)
        {
            return await
                _context.StateProperties
                .SingleAsync(stateProperty =>
                    stateProperty.GameObjectId == gameObjectId &&
                    stateProperty.Name == name
                    );
        }

        [HttpPost("SetStateProperty")]
        public async Task SetStateProperty(Guid gameObjectId, string name, string value)
        {
            if (await _context.StateProperties.AnyAsync(stateProperty => stateProperty.GameObjectId == gameObjectId && stateProperty.Name == name))
            {
                (await GetStateProperty(gameObjectId, name)).Value = value;
            }
            else
            {
                _context.StateProperties.Add(new StateProperty() { GameObjectId = gameObjectId, Name = name, Value = value });
            }
            await _context.SaveChangesAsync();
        }

        [HttpPost("ClearStateProperty")]
        public async Task ClearStateProperty(Guid gameObjectId, string name)
        {
            await SetStateProperty(gameObjectId, name, "");
        }
    }

}
