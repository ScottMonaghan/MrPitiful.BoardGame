using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public class GameBoardSpaceController : GameObjectController
    {
        private BoardGameDbContext _context;
 
        public GameBoardSpaceController(BoardGameDbContext context):base(context)
        {
            _context = context;
        }

        [HttpGet("GetAdjacentSpaceByDirection/{gameBoardSpaceId}/{direction}")]
        public async Task<GameBoardSpace> GetAdjacentSpaceByDirection(Guid gameBoardSpaceId, string direction)
        {
            var returnedAdjacentSpaces = await _context.AdjacentSpaces
                .Where(
                    aspace => aspace.Direction == direction 
                    && aspace.ParentGameBoardSpaceId == gameBoardSpaceId
                 )
                .Select(aspace => aspace.AdjacentGameBoardSpace).ToListAsync();
    
            if (returnedAdjacentSpaces.Count() > 0)
            {
                return returnedAdjacentSpaces[0];
            } else { 
                return null;
            }
        }
        [HttpPost("PostAdjacentSpace/{parentGameBoardSpaceId}/{adjacentGameBoardSpaceId}")]
        public async Task PostAdjacentSpace(Guid parentGameBoardSpaceId, Guid adjacentGameBoardSpaceId, string direction)
        {
            //check to see if adjaent space already exists in that direction
            var existingAdjacentSpaces = await _context.AdjacentSpaces
                .Where(
                    aspace => aspace.Direction == direction
                    && aspace.ParentGameBoardSpaceId == parentGameBoardSpaceId
                 )
                .ToListAsync();
            
            //if it doesn't create a new one
            if (existingAdjacentSpaces.Count() == 0)
            {
                _context.AdjacentSpaces.Add(
                    new AdjacentSpace()
                    {
                        ParentGameBoardSpaceId = parentGameBoardSpaceId, //await _context.GameBoardSpaces.SingleAsync(gbs => gbs.Id == parentGameBoardSpaceId),
                        AdjacentGameBoardSpaceId = adjacentGameBoardSpaceId, //await _context.GameBoardSpaces.SingleAsync(gbs => gbs.Id == adjacentGameBoardSpaceId),
                        Direction = direction                    
                    }
                );
            }
            //if it does exist, update the existing one
            else            
            {
                var adjacentSpaceToUpdate = existingAdjacentSpaces[0];
                adjacentSpaceToUpdate.AdjacentGameBoardSpaceId = adjacentGameBoardSpaceId; // await _context.GameBoardSpaces.SingleAsync(gbs => gbs.Id == adjacentGameBoardSpaceId);
            }
            await _context.SaveChangesAsync();
        }
    }
}
