using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Interfaces
{
    public interface IPlayer
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        IDictionary<string,string> State { get; set; }      
    }
}
