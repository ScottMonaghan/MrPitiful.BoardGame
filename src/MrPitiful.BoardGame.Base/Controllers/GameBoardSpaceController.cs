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

        public async Task<List<GamePiece>> GetGamePieces(Guid gameBoardSpaceId)
        {
            return await _context.GamePieces.Where(gp => gp.GameBoardSpaceId == gameBoardSpaceId).ToListAsync();
        }

        [HttpGet]
        public virtual async Task<List<GameBoardSpace>> Get()
        {
            return await _context.GameBoardSpaces.ToListAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<GameBoardSpace> Get(Guid id)
        {
            return await _context.GameBoardSpaces.SingleAsync(gameBoardSpace => gameBoardSpace.Id == id);
        }
        
        [HttpPost]
        public virtual async Task<GameBoardSpace> Post()
        {
            return await Post(new GameBoardSpace());
        }

        [HttpPost]
        public virtual async Task<GameBoardSpace> Post([FromBody]GameBoardSpace gameBoardSpace)
        {
            _context.GameBoardSpaces.Add(gameBoardSpace);
            await _context.SaveChangesAsync();
            return gameBoardSpace;
        }

        [HttpPut]
        public virtual async Task<GameBoardSpace> Put([FromBody]GameBoardSpace gameBoardSpace)
        {
            _context.Attach(gameBoardSpace);
            _context.Entry(gameBoardSpace).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gameBoardSpace;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            if (await _context.GameBoardSpaces.AnyAsync(gameBoardSpace => gameBoardSpace.Id == id))
            {
                var deletedGameBoardSpace = await _context.GameBoardSpaces.SingleAsync(gameBoardSpace => gameBoardSpace.Id == id);
                _context.GameBoardSpaces.Remove(deletedGameBoardSpace);
                await _context.SaveChangesAsync();
            }
        }

    }
}
