using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Interfaces
{
    /* 
        * A piece exists on in a gameboard space in a game.   
        * A piece's state is recorded in name/value pairs.
        * A piece's connections to a game and a space are all through guids and redundant to prevent the need for joins.
        * Also this allows the piece to KNOW what game it belongs to and what space it is on. 
    */
    public interface IGamePiece
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        Guid GameSpaceId { get; set; }
        IDictionary<string, string> State { get; set; }
    }
}
