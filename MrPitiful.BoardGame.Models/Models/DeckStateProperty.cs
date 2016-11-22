using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class DeckStateProperty : StateProperty
    {
        [JsonIgnore]
        public Deck Deck { get; set; }
        public Guid DeckId {get;set;}
    }
}
