using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    /* 
        * A gameboard exists in a game.
        * A gameboard is a container for spaces
        * A game contains one gameboard
        * Connections between game and gameboard is redundant
    */
    public interface IGameBoard:IGameObject
    {
        [JsonIgnore]
        List<Guid> GameBoardSpaceIds { get; }
    }
}
