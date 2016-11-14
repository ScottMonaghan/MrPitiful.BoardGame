using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class SpaceConnectionStateProperty : StateProperty
    {
        [JsonIgnore]
        public SpaceConnection ConnectedSpace { get; set; }
        public Guid SpaceConnectionId {get;set;}
    }
}
