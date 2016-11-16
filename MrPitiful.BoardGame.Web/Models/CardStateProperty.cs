using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class CardStateProperty : StateProperty
    {
        [JsonIgnore]
        public Card Card { get; set; }
        public Guid CardId {get;set;}
    }
}
