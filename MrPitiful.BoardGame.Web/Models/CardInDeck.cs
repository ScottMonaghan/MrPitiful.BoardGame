using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class CardInDeck 
    {
        public CardInDeck() { }
        [JsonIgnore]
        public Deck Deck
        {
            get; set;
        }
        public Guid DeckId
        {
            get; set;
        }
        public Card Card {
            get; set;
        }
        public Guid CardId
        {
            get;set;
        }
        public int Position
        {
            get; set;
        }
        public Guid Id
        {
            get; set;
        }
    }
}
