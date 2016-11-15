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
    public class GameBoardSpaceController : Controller
    {
        private BoardGameContext _context; 
        public GameBoardSpaceController(BoardGameContext context)
        {
            _context = context;
        }
       
        // GET api/values
        [HttpGet]
        public List<GameBoardSpace> Get()
        {
            return _context.GameBoardSpaces.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<GameBoardSpace> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false, 
            bool includeGamePieces = false,
            bool includeSpaceConnections = false
            )
        {
            var gameBoardSpace = _context.GameBoardSpaces.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                gameBoardSpace = gameBoardSpace.Include(x => x.StateProperties);
            }
            if (includeGamePieces) //if you want the pieces, you need the spaces
            {
                gameBoardSpace = gameBoardSpace.Include(x => x.GamePieces);
            }
            if (includeSpaceConnections)
            {
                gameBoardSpace = gameBoardSpace.Include(x => x.SpaceConnections);
            }
            return await gameBoardSpace.SingleAsync();
        }

        // POST api/values
        [HttpPost]
        public GameBoardSpace Post([FromBody]GameBoardSpace obj)
        {
            _context.GameBoardSpaces.Add(obj);
            _context.SaveChanges();
            return obj;
        }

         
        [HttpPost("GetByStateProperties/{GameBoardId}")]
        public async Task<List<GameBoardSpace>> GetByStatePropertiesAsync(Guid GameBoardId, [FromBody]List<GameBoardSpaceStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.GameBoardSpaceStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.GameBoardSpace.GameBoardId == GameBoardId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoardSpace
            .GroupBy(sp => sp.GameBoardSpace)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
  
        // PUT api/values/5
        [HttpPut]
        public async Task<GameBoardSpace> Put([FromBody]GameBoardSpace obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.GameBoardSpaceStateProperties
                    .Where(sp=>sp.GameBoardSpaceId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.GameBoardSpaceId = obj.Id;
                    _context.GameBoardSpaceStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.GameBoardSpaces.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var obj = new GameBoardSpace() { Id = id };
            _context.GameBoardSpaces.Remove(obj);
            _context.SaveChanges();
        }
    }
}
