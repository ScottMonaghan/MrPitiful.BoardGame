using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Models.Interfaces
{
    /* 
        * A gameboard exists in a game.
        * A gameboard is a container for spaces
        * A game contains one gameboard
        * Connections between game and gameboard is redundant
    */
    public interface IGameBoard:IGameObject
    {
        Guid GameId { get; set; }
        List<Guid> GameBoardSpaceIds { get; }
    }
}
