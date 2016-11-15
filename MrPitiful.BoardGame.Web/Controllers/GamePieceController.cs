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
    public class GamePieceController : Controller
    {
        private BoardGameContext _context; 
        public GamePieceController(BoardGameContext context)
        {
            _context = context;
        }
       
        // GET api/values
        [HttpGet]
        public List<GamePiece> Get()
        {
            return _context.GamePieces.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<GamePiece> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false
            )
        {
            var gameBoardSpace = _context.GamePieces.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                gameBoardSpace = gameBoardSpace.Include(x => x.StateProperties);
            }
            return await gameBoardSpace.SingleAsync();
        }

        // POST api/values
        [HttpPost]
        public GamePiece Post([FromBody]GamePiece obj)
        {
            _context.GamePieces.Add(obj);
            _context.SaveChanges();
            return obj;
        }
         
        [HttpPost("GetByStateProperties/{GameSetId}")]
        public async Task<List<GamePiece>> GetByStatePropertiesAsync(Guid GameSetId, [FromBody]List<GamePieceStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.GamePieceStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.GamePiece.GameSetId == GameSetId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoardSpace
            .GroupBy(sp => sp.GamePiece)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
  
        // PUT api/values/5
        [HttpPut]
        public async Task<GamePiece> Put([FromBody]GamePiece obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.GamePieceStateProperties
                    .Where(sp=>sp.GamePieceId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.GamePieceId = obj.Id;
                    _context.GamePieceStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.GamePieces.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var obj = new GamePiece() { Id = id };
            _context.GamePieces.Remove(obj);
            _context.SaveChanges();
        }
    }
}
