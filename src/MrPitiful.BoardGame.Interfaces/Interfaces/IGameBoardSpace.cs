using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Interfaces
{
    /* 
        * A space exists on a board in a game.  The board is not a required object, but is implied. 
        * A space is adjacent to other spaces, but this is not limited by shape or dimension, 
        * allowing boards from simple 2d grids to n-dimensions or even impossible.
        * A spaces's state is recorded in name/value pairs.
        * A spaces connection to a game and adjacent spaces are all through guids and redundant to prevent the need for joins.
        * Also this allows the space to KNOW what game it belongs to and what spaces are adjacent. 
    */
    public interface IGameBoardSpace
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        List<Guid> AdjacentSpaces { get; set; }
        IDictionary<string, string> State { get; set; }
    }
}
