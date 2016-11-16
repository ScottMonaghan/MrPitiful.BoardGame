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
    public class CardController : Controller
    {
        private BoardGameContext _context;
        public CardController(BoardGameContext context)
        {
            _context = context;
        }
       
        // GET api/values
        [HttpGet]
        public async Task<List<Card>> Get()
        {
            return await _context.Cards.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Card> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false
            )
        {
            var gameBoardSpace = _context.Cards.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                gameBoardSpace = gameBoardSpace.Include(x => x.StateProperties);
            }
            return await gameBoardSpace.SingleAsync();
        }
 
        // POST api/values
        [HttpPost]
        public async Task<Card> Post([FromBody]Card obj)
        {
            _context.Cards.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
         
        [HttpPost("GetByStateProperties/{GameSetId}")]
        public async Task<List<Card>> GetByStatePropertiesAsync(Guid GameSetId, [FromBody]List<CardStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.CardStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.Card.GameSetId == GameSetId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoardSpace
            .GroupBy(sp => sp.Card)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
  
        // PUT api/values/5
        [HttpPut]
        public async Task<Card> Put([FromBody]Card obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.CardStateProperties
                    .Where(sp=>sp.CardId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.CardId = obj.Id;
                    _context.CardStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.Cards.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var obj = new Card() { Id = id };
            _context.Cards.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
