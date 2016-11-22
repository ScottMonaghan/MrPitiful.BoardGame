using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class PlayerStateProperty : StateProperty
    {
        [JsonIgnore]
        public Player Player { get; set; }
        public Guid PlayerId {get;set;}
    }
}
