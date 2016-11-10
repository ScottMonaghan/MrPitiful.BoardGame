using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGameItemWithStateProperties: IEntityWithGuidPrimaryKey
    {
        List<IGameStateProperty> StateProperties {get; set;}
    }
}
