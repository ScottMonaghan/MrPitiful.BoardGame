using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class Player 
    {
        public Player()
        {
            StateProperties = new List<PlayerStateProperty>();
        }
        public Guid GameId { get; set; }

        [JsonIgnore]
        public Game Game
        {
            get;set;
        }

        public Guid Id
        {
            get; set;
        }

        public List<PlayerStateProperty> StateProperties
        {
            get; set;
        }
    }
}
