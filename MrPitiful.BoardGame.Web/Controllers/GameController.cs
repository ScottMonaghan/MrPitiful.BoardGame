using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Models;
using MrPitiful.BoardGame.Database;
namespace MrPitiful.BoardGame.Web.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private BoardGameContext _context; 
        public GameController(BoardGameContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public List<Game> Get()
        {
            return _context.Games.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Game> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false,
            bool includeGameSet = false,
            bool includePlayers = false
            )
        {
            var Game = _context.Games.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                Game = Game.Include(x => x.StateProperties);
            }
            if (includeGameSet)
            {
                Game = Game.Include(x => x.GameSet);
            }
            if (includePlayers) //if you want the spaces, you need the board:)
            {
                Game = Game.Include(x => x.Players);
            }
            return await Game.SingleAsync();
        }

        // POST api/values
        [HttpPost]
        public Game Post([FromBody]Game obj)
        {
            _context.Games.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        [HttpPost("GetByStateProperties")]
        public async Task<List<Game>> GetByStatePropertiesAsync([FromBody]List<GameStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.GameStateProperties.Where(
                //first filter down to state properties that are equal to the provided filter
                sp => statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by Game
            .GroupBy(sp => sp.Game)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<Game> Put([FromBody]Game obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.GameStateProperties
                    .Where(sp=>sp.GameId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.GameId = obj.Id;
                    _context.GameStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.Games.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var obj = new Game() { Id = id };
            _context.Games.Remove(obj);
            _context.SaveChanges();
        }
    }
}
