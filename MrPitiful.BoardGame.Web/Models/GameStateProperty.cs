using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class GameStateProperty : StateProperty
    {
        [JsonIgnore]
        public Game Game { get; set; }
        public Guid GameId {get;set;}
    }
}
