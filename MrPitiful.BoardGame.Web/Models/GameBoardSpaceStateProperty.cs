using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoardSpaceStateProperty : StateProperty
    {
        [JsonIgnore]
        public GameBoardSpace GameBoardSpace { get; set; }
        public Guid GameBoardSpaceId {get;set;}
    }
}
