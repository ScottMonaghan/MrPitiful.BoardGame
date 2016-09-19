using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base
{
    public interface IPlayer
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        IDictionary<string,string> State { get; set; }      
    }
}
