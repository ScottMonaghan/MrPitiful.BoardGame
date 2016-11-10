using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGamePiece:IEntityWithGuidPrimaryKey,IGameSetItem,IGameItemWithStateProperties
    {
        IGameBoardSpace GameBoardSpace { get; set; }
        Guid GameBoardSpaceId { get; set; }
    }
}
