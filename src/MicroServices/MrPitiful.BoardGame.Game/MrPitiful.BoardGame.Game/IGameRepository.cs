using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Interfaces;

namespace MrPitiful.BoardGame.Game
{
    public interface IGameRepository
    {
        IDictionary<Guid, IGame> Get();
        IGame Get(Guid Id);
        IGame Create(IGame game);
        void Save(IGame game);
        void Delete(IGame game);
    }
}
