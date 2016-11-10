using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    /* 
        * A space exists on a board in a game.  The board is not a required object, but is implied. 
        * A space is adjacent to other spaces, but this is not limited by shape or dimension, 
        * allowing boards from simple 2d grids to n-dimensions or even impossible.
        * A spaces's state is recorded in name/value pairs.
        * A spaces connection to a game and adjacent spaces are all through guids and redundant to prevent the need for joins.
        * Also this allows the space to KNOW what game it belongs to and what spaces are adjacent. 
    */
    public interface IGameBoardSpace:IGameObject
    {

        //The gameboard the piece exists in
        Guid GameBoardId { get; set; }

        //All of the adjacent spaces to the current space.  The key is a string value representing direction.  The value is the Id of the adjacent space
        [JsonIgnore]
        Dictionary<string, Guid> AdjacentSpaceIds { get; }

        //All the gamepieces presently in the space
        [JsonIgnore]
        List<Guid> GamePieceIds { get; }
    }
}
