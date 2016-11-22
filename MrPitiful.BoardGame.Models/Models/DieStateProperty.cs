using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class DieStateProperty : StateProperty
    {
        [JsonIgnore]
        public Die Die { get; set; }
        public Guid DieId {get;set;}
    }
}
