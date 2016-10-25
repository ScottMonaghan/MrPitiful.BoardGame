using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public class GamePieceController : GameObjectController
    {
        private BoardGameDbContext _context;
 
        public GamePieceController(BoardGameDbContext context):base(context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual async Task<List<GamePiece>> Get()
        {
            return await _context.GamePieces.ToListAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<GamePiece> Get(Guid id)
        {
            return await _context.GamePieces.SingleAsync(gamePiece => gamePiece.Id == id);
        }
        
        [HttpPost]
        public virtual async Task<GamePiece> Post()
        {
            return await Post(new GamePiece());
        }

        [HttpPost]
        public virtual async Task<GamePiece> Post([FromBody]GamePiece gamePiece)
        {
            _context.GamePieces.Add(gamePiece);
            await _context.SaveChangesAsync();
            return gamePiece;
        }

        [HttpPut]
        public virtual async Task<GamePiece> Put([FromBody]GamePiece gamePiece)
        {
            _context.Attach(gamePiece);
            _context.Entry(gamePiece).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gamePiece;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            if (await _context.GamePieces.AnyAsync(gamePiece => gamePiece.Id == id))
            {
                var deletedGamePiece = await _context.GamePieces.SingleAsync(gamePiece => gamePiece.Id == id);
                _context.GamePieces.Remove(deletedGamePiece);
                await _context.SaveChangesAsync();
            }
        }

    }
}
