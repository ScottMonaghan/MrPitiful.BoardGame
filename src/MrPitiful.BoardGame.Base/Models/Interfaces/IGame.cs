using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base.Models.Interfaces
{
    /* 
     * A game consists of players and pieces on spaces. 
     * A game's state is recorded in name/value pairs.
     * Connections between the game and players, spaces, and pieces are all through guids and redundant to prevent the need for joins.
     * Also this allows the game to KNOW what players, spaces, and pieces are included in the game. 
     */
  
    public interface IGame:IGameObject
    {
        Guid GameBoardId { get; set; }
        [JsonIgnore]
        List<Guid> PlayerIds { get; set; }
        [JsonIgnore]
        List<Guid> GameBoardSpaceIds { get; set; }
        [JsonIgnore]
        List<Guid> GamePieceIds { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
    }
}
