using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGameSet:IEntityWithGuidPrimaryKey, IGameItemWithStateProperties
    {
        IGameBoard GameBoard { get; set; }
        List<IGamePiece> GamePieces { get; set; }
    }
}
