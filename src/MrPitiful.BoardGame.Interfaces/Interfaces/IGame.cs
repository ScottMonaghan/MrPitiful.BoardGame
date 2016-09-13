﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MrPitiful.BoardGame.Interfaces
{
    /* 
     * A game consists of players and pieces on spaces. 
     * A game's state is recorded in name/value pairs.
     * Connections between the game and players, spaces, and pieces are all through guids and redundant to prevent the need for joins.
     * Also this allows the game to KNOW what players, spaces, and pieces are included in the game. 
     */
  
    public interface IGame
    {
        Guid Id { get; set; }
        List<Guid> PlayerIds { get; set; }
        List<Guid> GameBoardSpaceIds { get; set; }
        List<Guid> GamePieceIds { get; set; }
        IDictionary<string, string> State { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
