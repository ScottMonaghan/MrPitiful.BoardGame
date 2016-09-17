using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Models.Interfaces
{
    public interface IGameObject
    {
        Guid Id { get; set; }
        Dictionary<string, string> State { get; }
    }
}
