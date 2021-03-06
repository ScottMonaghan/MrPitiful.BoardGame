﻿using System;
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
            bool includeGameBoardSpaces = false,
            bool includeGamePieces = false
            )
        {
            var gameBoard = _context.GameBoards.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                gameBoard = gameBoard.Include(x => x.StateProperties);
            }
            if (includeGameBoardSpaces || includeGamePieces) //if you want the pieces, you need the spaces
            {
                if (includeGamePieces)
                {
                    gameBoard = gameBoard.Include(x => x.GameBoardSpaces)
                        .ThenInclude(y => y.GamePieces);
                } else
                {
                    gameBoard = gameBoard.Include(x => x.GameBoardSpaces);
                }
            }
            return await gameBoard.SingleAsync();
        }

        // POST api/values
        [HttpPost]
        public GameBoard Post([FromBody]GameBoard obj)
        {
            _context.GameBoards.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        //This method is pretty useless
        /* 
        [HttpPost("GetByStateProperties/{GameSetId}")]
        public async Task<List<GameBoard>> GetByStatePropertiesAsync(Guid GameSetId, [FromBody]List<GameBoardStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.GameBoardStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.GameBoard.GameSetId == GameSetId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoard
            .GroupBy(sp => sp.GameBoard)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
        */
        // PUT api/values/5
        [HttpPut]
        public async Task<GameBoard> Put([FromBody]GameBoard obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.GameBoardStateProperties
                    .Where(sp=>sp.GameBoardId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.GameBoardId = obj.Id;
                    _context.GameBoardStateProperties.Add(statePropertyToUpdate);
                }
            }
            _context.GameBoards.Update(obj);
            _context.SaveChanges();
            return obj;
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
