using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
namespace MrPitiful.BoardGame.Base
{
 
    [Route("api/[controller]")]
    public class GameController : GameObjectController
    {
        private BoardGameDbContext _context;
 
        public GameController(BoardGameDbContext context):base(context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Game>> Get()
        {
            return await _context.Games.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Game> Get(Guid id)
        {
            return await _context.Games.SingleAsync(game => game.Id == id);
        }

        [HttpPost]
        public async Task<Game> Post()
        {
            return await Post(new Game());
        }

        [HttpPost]
        public async Task<Game> Post([FromBody]Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        [HttpPut]
        public async Task<Game> Put([FromBody]Game game)
        {
            _context.Attach(game);
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return game;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            if (await _context.Games.AnyAsync(game => game.Id == id))
            {
                var deletedGame = await _context.Games.SingleAsync(game => game.Id == id);
                _context.Games.Remove(deletedGame);
                await _context.SaveChangesAsync();
            }
        }

    }
}
