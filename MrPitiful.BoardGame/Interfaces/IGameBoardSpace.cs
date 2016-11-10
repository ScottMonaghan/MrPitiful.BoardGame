using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGameBoardSpace:IEntityWithGuidPrimaryKey,IGameSetItem,IGameItemWithStateProperties
    {
        IGameBoard GameBoard { get; set; }
        Guid GameBoardId { get; set; }
        List<IAdjacentSpace> AdjacentSpaces { get; set; }
        List<IGamePiece> GamePieces { get; set; }
    }
}
