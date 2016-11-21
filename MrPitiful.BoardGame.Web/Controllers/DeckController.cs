using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Models;
using MrPitiful.BoardGame.Database;
namespace MrPitiful.BoardGame.Web.Controllers
{
    [Route("api/[controller]")]
    public class DeckController : Controller
    {
        private BoardGameContext _context;
        private Random _rnd;
        public DeckController(BoardGameContext context)
        {
            _context = context;
            _rnd = new Random();
        }
       
        private List<CardInDeck> GetShuffledCards(List<CardInDeck> unshuffledCards)
        {
            var shuffledCards = unshuffledCards;
            for (int i = 0; i < unshuffledCards.Count; i++)
            {
                var swapIndex = _rnd.Next(i, shuffledCards.Count() - 1);
                var tmp = shuffledCards[i];
                shuffledCards[i] = shuffledCards[swapIndex];
                shuffledCards[swapIndex] = tmp;
            }
            shuffledCards = SetCardInDeckPositionsBasedOnOrder(shuffledCards);
            return shuffledCards;
        }
        private List<CardInDeck> SetCardInDeckPositionsBasedOnOrder(List<CardInDeck> orderedCardsInDeck)
        {
            for(int position = 0; position < orderedCardsInDeck.Count(); position++)
            {
                orderedCardsInDeck[position].Position = position;
            }
            return orderedCardsInDeck;
        }
         
        // GET api/values
        [HttpGet]
        public async Task<List<Deck>> Get()
        {
            return await _context.Decks.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Deck> GetByIdAsync(
            Guid id,
            bool includeStateProperties = false,
            bool includeCards = false,
            bool shuffle = false
            )
        {
            var deckQuery = _context.Decks.Where(x => x.Id == id);

            if (includeStateProperties)
            {
                deckQuery = deckQuery.Include(x => x.StateProperties);
            }
            var deck = await deckQuery.SingleAsync();

            if (includeCards || shuffle)
            {
                /*
                 * According to http://stackoverflow.com/questions/15378136/entity-framework-ordering-includes EF doesn't support ordering includes,
                 * so since the order of the cardsInDeck is important, we get those with a separate call
                 */
                
                deck.CardsInDeck = await _context.CardsInDecks
                    .Where(cardInDeck => cardInDeck.DeckId == id)
                    .OrderBy(cardInDeck => cardInDeck.Position)
                    .ToListAsync();

                if (shuffle)
                {
                    deck.CardsInDeck = GetShuffledCards(deck.CardsInDeck);
                    await _context.SaveChangesAsync();
                }
            }
            return deck; 
        }
 
        // POST api/values
        [HttpPost]
        public async Task<Deck> Post([FromBody]Deck obj)
        {
            //set the correct position of CardsInDeck
            if (obj.CardsInDeck.Count > 0)
            {
                obj.CardsInDeck = SetCardInDeckPositionsBasedOnOrder(obj.CardsInDeck);
            }

            _context.Decks.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
         
        [HttpPost("GetByStateProperties/{GameSetId}")]
        public async Task<List<Deck>> GetByStatePropertiesAsync(Guid GameSetId, [FromBody]List<DeckStateProperty> statePropertiesToFilter)
        {
            //this some crazyass linq               
            return await _context.DeckStateProperties
            //filter to gameset
            .Where(
                //first filter down to state properties that are equal to the provided filter
                sp => sp.Deck.GameSetId == GameSetId && statePropertiesToFilter.Exists(f => f.Name == sp.Name && f.Value == sp.Value)
            )
            //next group by gameBoardSpace
            .GroupBy(sp => sp.Deck)
            //now filter down to groups that have the same number of stateproperties as the filter
            .Where(grp => grp.Count() == statePropertiesToFilter.Count())
            //now return the remaining gameobjects
            .Select(grp => grp.Key)
            .ToListAsync();
        }
  
        // PUT api/values/5
        [HttpPut]
        public async Task<Deck> Put([FromBody]Deck obj)
        {
            //Because state properties usa a composite key of parentId & Name,
            //we need to do some extra work here to make sure existing properties
            //update, and new properties are added.
            var statePropertiesToUpdate = obj.StateProperties;
            obj.StateProperties = null;
            foreach (var statePropertyToUpdate in statePropertiesToUpdate)
            {
                var statePropertyToCheck = await _context.DeckStateProperties
                    .Where(sp=>sp.DeckId == obj.Id && sp.Name == statePropertyToUpdate.Name)
                    .SingleOrDefaultAsync();
                if (statePropertyToCheck != null)
                {
                    statePropertyToCheck.Value = statePropertyToUpdate.Value;
                } else
                {
                    statePropertyToUpdate.DeckId = obj.Id;
                    _context.DeckStateProperties.Add(statePropertyToUpdate);
                }
            }

            //set the correct position of CardsInDeck
            if (obj.CardsInDeck.Count > 0)
            {
                obj.CardsInDeck = SetCardInDeckPositionsBasedOnOrder(obj.CardsInDeck);
            }
            _context.Decks.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var obj = new Deck() { Id = id };
            _context.Decks.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
