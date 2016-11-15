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
    public class PlayerController : Controller
    {
        private BoardGameContext _context; 
        public PlayerController(BoardGameContext context)
        {
            _context = context;
        }
       
        // GET api/values
        [HttpGet]
        public List<Player> Get()
        {
            return _context.Players.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Player> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false
            )
        {
            var player = _context.Players.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                player = player.Include(x => x.StateProperties);
            }
            return await player.SingleAsync();
        }

        // POST api/values
        [HttpPost]
        public Player Post([FromBody]Player obj)
        {
            _context.Players.Add(obj);
            _context.SaveChanges();
            return obj;
        }
         
        [HttpPost("GetByStateProperties/{GameId}")]
        public async Task<List<Player>> GetByStatePropertiesAsync(Guid GameId, [FromBody]List<PlayerStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.PlayerStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.Player.GameId == GameId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoardSpace
            .GroupBy(sp => sp.Player)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
  
        // PUT api/values/5
        [HttpPut]
        public async Task<Player> Put([FromBody]Player obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.PlayerStateProperties
                    .Where(sp=>sp.PlayerId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.PlayerId = obj.Id;
                    _context.PlayerStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.Players.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var obj = new Player() { Id = id };
            _context.Players.Remove(obj);
            _context.SaveChanges();
        }
    }
}
