using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class Game
    {
        public Game()
        {
            Players = new List<Player>();
            StateProperties = new List<GameStateProperty>();
        }
        public Guid Id { get; set; }
        public GameSet GameSet { get; set; }
        public List<Player> Players {get; set;}
        public List<GameStateProperty> StateProperties { get; set; }
    }
}
