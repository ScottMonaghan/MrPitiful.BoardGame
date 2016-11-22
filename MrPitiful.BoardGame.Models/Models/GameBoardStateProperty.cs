using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoardStateProperty : StateProperty
    {
        [JsonIgnore]
        public GameBoard GameBoard { get; set; }
        public Guid GameBoardId {get;set;}
    }
}
