using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public class GameBoardController : GameObjectController
    {
        private BoardGameDbContext _context;
 
        public GameBoardController(BoardGameDbContext context):base(context)
        {
            _context = context;
        }

        
        [HttpGet]
        public virtual async Task<List<GameBoard>> Get()
        {
            return await _context.GameBoards.ToListAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<GameBoard> Get(Guid id)
        {
            return await _context.GameBoards.SingleAsync(gameBoard => gameBoard.Id == id);
        }
        
        [HttpPost]
        public virtual async Task<GameBoard> Post()
        {
            return await Post(new GameBoard());
        }

        [HttpPost]
        public virtual async Task<GameBoard> Post([FromBody]GameBoard gameBoard)
        {
            _context.GameBoards.Add(gameBoard);
            await _context.SaveChangesAsync();
            return gameBoard;
        }

        [HttpPut]
        public virtual async Task<GameBoard> Put([FromBody]GameBoard gameBoard)
        {
            _context.Attach(gameBoard);
            _context.Entry(gameBoard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gameBoard;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            if (await _context.GameBoards.AnyAsync(gameBoard => gameBoard.Id == id))
            {
                var deletedGameBoard = await _context.GameBoards.SingleAsync(gameBoard => gameBoard.Id == id);
                _context.GameBoards.Remove(deletedGameBoard);
                await _context.SaveChangesAsync();
            }
        }

    }
}
