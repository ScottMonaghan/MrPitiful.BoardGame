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
            var gameSet = await _context.GameSets.Where(x => x.Id == id).SingleAsync();
            if (includeStateProperties)
            {
                gameSet.StateProperties = await _context.GameSetStateProperties.Where(x => x.GameSetId == gameSet.Id).ToListAsync();
            }
            if (includeGamePieces)
            {
                gameSet.GamePieces = await _context.GamePieces.Where(x => x.GameSetId == gameSet.Id).ToListAsync();
            }
            if (includeGameBoard || includeGameBoardSpaces) //if you want the spaces, you need the board:)
            {
                gameSet.GameBoard = await _context.GameBoards.Where(x => x.GameSetId == gameSet.Id).SingleOrDefaultAsync();
            }
            if (includeGameBoardSpaces)
            {
                gameSet.GameBoard.GameBoardSpaces = await _context.GameBoardSpaces.Where(x => x.GameBoardId == gameSet.GameBoard.Id).ToListAsync();
            }


            return gameSet;
        }

        // POST api/values
        [HttpPost]
        public GameSet Post([FromBody]GameSet obj)
        {
            _context.GameSets.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]GameSet obj)
        {
            _context.GameSets.Attach(obj);
            _context.SaveChanges();
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
