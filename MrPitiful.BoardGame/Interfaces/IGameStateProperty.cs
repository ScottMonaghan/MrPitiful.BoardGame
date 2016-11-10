using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGameStateProperty:IEntityWithGuidPrimaryKey
    {
        IGameItemWithStateProperties GameItem { get; set; }
        Guid GameItemId { get; set; }
    }
}
