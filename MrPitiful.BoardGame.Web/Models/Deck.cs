using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class Deck 
    {
        public Deck()
        {
            StateProperties = new List<DeckStateProperty>();
            CardsInDeck = new List<CardInDeck>();
        }
        [JsonIgnore]
        public GameSet GameSet
        {
            get; set;
        }
        public Guid GameSetId
        {
            get; set;
        }
        public Guid Id
        {
            get; set;
        }
        public List<DeckStateProperty> StateProperties
        {
            get; set;
        }
        public List<CardInDeck> CardsInDeck
        {
            get;set;
        }
    }
}
