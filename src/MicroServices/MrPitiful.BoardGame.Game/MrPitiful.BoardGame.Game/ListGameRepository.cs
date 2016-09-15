using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Interfaces;

namespace MrPitiful.BoardGame.Game
{
    public class ListGameRepository : IGameRepository
    {
        private Dictionary<Guid, IGame> _games;
        public ListGameRepository()
        {
            _games = new Dictionary<Guid, IGame>();
        }

        public IGame Create(IGame game)
        {
            game.Id = Guid.NewGuid();
            _games.Add(game.Id, game);
            return game;
        }

        public IDictionary<Guid,IGame> Get()
        {
            return _games;
        }

        public IGame Get(Guid Id)
        {
            IGame gotGame;
            gotGame = _games[Id];
            return gotGame;
        }
    
        public void Save(IGame game)
        {
            //save game here
        }

        public void Delete(IGame game)
        {
            _games.Remove(game.Id);
        }

    }
}
