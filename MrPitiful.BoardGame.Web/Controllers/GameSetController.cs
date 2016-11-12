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
    public class GameSetController : Controller
    {
        private BoardGameContext _context; 
        public GameSetController(BoardGameContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public List<GameSet> Get()
        {
            return _context.GameSets.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<GameSet> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false, 
            bool includeGamePieces = false, 
            bool includeGameBoard = false,
            bool includeGameBoardSpaces = false
            )
        {
            var gameSet = _context.GameSets.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                gameSet = gameSet.Include(x => x.StateProperties);
            }
            if (includeGamePieces)
            {
                gameSet = gameSet.Include(x => x.GamePieces);
            }
            if (includeGameBoard || includeGameBoardSpaces) //if you want the spaces, you need the board:)
            {
                gameSet = gameSet.Include(x => x.GameBoard);
            }
            if (includeGameBoardSpaces)
            {
                gameSet = gameSet.Include(x => x.GameBoard.GameBoardSpaces);
            }


            return await gameSet.SingleAsync();
        }

        // POST api/values
        [HttpPost]
        public GameSet Post([FromBody]GameSet obj)
        {
            _context.GameSets.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        [HttpPost("GetByStateProperties")]
        public async Task<List<GameSet>> GetByStatePropertiesAsync([FromBody]List<GameSetStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.GameSetStateProperties.Where(
                //first filter down to state properties that are equal to the provided filter
                sp => statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameSet
            .GroupBy(sp => sp.GameSet)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<GameSet> Put([FromBody]GameSet obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.GameSetStateProperties
                    .Where(sp=>sp.GameSetId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.GameSetId = obj.Id;
                    _context.GameSetStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.GameSets.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var obj = new GameSet() { Id = id };
            _context.GameSets.Remove(obj);
            _context.SaveChanges();
        }
    }
}
