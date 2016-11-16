using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class GameSet 
    {
         
        public GameSet()
        {
            GamePieces = new List<GamePiece>();
            StateProperties = new List<GameSetStateProperty>();
        }
        [JsonIgnore]
        public Game Game { get; set; }
        public Guid? GameId { get; set; }

        public GameBoard GameBoard
        {
            get;set;
        }

        public List<GamePiece> GamePieces
        {
            get;set;
        }

        public Guid Id
        {
            get;set;
        }

        public List<GameSetStateProperty> StateProperties
        {
            get;set;
        }
        public List<Deck> Decks
        { get; set;}
        public List<Card> Cards
        { get; set; }
    }
}
