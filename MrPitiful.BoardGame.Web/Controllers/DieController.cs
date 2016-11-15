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
    public class DieController : Controller
    {
        private BoardGameContext _context;
        private Random rnd;
        public DieController(BoardGameContext context)
        {
            _context = context;
            rnd = new Random();
        }
       
        // GET api/values
        [HttpGet]
        public async Task<List<Die>> Get()
        {
            return await _context.Dice.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Die> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false
            )
        {
            var gameBoardSpace = _context.Dice.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                gameBoardSpace = gameBoardSpace.Include(x => x.StateProperties);
            }
            return await gameBoardSpace.SingleAsync();
        }
 
        [HttpGet("Roll/{id}")]
        public async Task<Die> Roll(
            Guid id,
            bool includeStateProperties = false
            )
        {
            var die = await GetByIdAsync(id, includeStateProperties);
            die.Value = rnd.Next(1, die.Sides);
            await _context.SaveChangesAsync();
            return die;
        }

        // POST api/values
        [HttpPost]
        public async Task<Die> Post([FromBody]Die obj)
        {
            _context.Dice.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
         
        [HttpPost("GetByStateProperties/{GameSetId}")]
        public async Task<List<Die>> GetByStatePropertiesAsync(Guid GameSetId, [FromBody]List<DieStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.DieStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.Die.GameSetId == GameSetId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoardSpace
            .GroupBy(sp => sp.Die)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
  
        // PUT api/values/5
        [HttpPut]
        public async Task<Die> Put([FromBody]Die obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.DieStateProperties
                    .Where(sp=>sp.DieId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.DieId = obj.Id;
                    _context.DieStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.Dice.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var obj = new Die() { Id = id };
            _context.Dice.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
