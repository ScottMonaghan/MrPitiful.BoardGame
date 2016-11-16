using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class Card 
    {
        public Card()
        {
            StateProperties = new List<CardStateProperty>();
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
        public CardInDeck CardInDeck
        { get; set; }
        public Guid Id
        {
            get; set;
        }
        public List<CardStateProperty> StateProperties
        {
            get; set;
        }
    }
}
