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
    public class GameBoardController : Controller
    {
        private BoardGameContext _context; 
        public GameBoardController(BoardGameContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public List<GameBoard> Get()
        {
            return _context.GameBoards.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<GameBoard> GetByIdAsync(
            Guid id, 
            bool includeStateProperties = false, 
            bool includeGameBoardSpaces = false
            )
        {
            var obj = await _context.GameBoards.Where(x => x.Id == id).SingleAsync();
            if (includeStateProperties)
            {
                obj.StateProperties = await _context.GameBoardStateProperties.Where(x => x.GameBoardId == obj.Id).ToListAsync();
            }
            if (includeGameBoardSpaces)
            {
                obj.GameBoardSpaces = await _context.GameBoardSpaces.Where(x => x.GameBoardId == obj.Id).ToListAsync();
            }


            return obj;
        }

        // POST api/values
        [HttpPost]
        public GameBoard Post([FromBody]GameBoard obj)
        {
            _context.GameBoards.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]GameBoard obj)
        {
            _context.GameBoards.Attach(obj);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var obj = new GameBoard() { Id = id };
            _context.GameBoards.Remove(obj);
            _context.SaveChanges();
        }
    }
}
