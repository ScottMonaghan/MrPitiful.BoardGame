using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGameBoard : IEntityWithGuidPrimaryKey, IGameItemWithStateProperties, IGameSetItem
    {
        List<IGameBoardSpace> GameBoardSpaces { get; set; }
    }
}
