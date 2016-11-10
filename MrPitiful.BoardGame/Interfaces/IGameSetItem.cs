using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public interface IGameSetItem
    {
        IGameSet GameSet { get; set; }
        Guid GameSetId { get; set; }
    }
}
