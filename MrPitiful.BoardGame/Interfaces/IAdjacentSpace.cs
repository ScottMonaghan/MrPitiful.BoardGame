using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IAdjacentSpace:IEntityWithGuidPrimaryKey
    {
        IGameBoardSpace GameBoardSpace { get; set; }
        Guid GameBoardSpaceId { get; set; }
        IGameBoardSpace RemoteSpace { get; set; }
        String Direction { get; set; }
    }
}
