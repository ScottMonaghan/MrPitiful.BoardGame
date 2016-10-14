using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    //first we need to make a generic listgamerepository to inherit from the base class of game
    public class ChessListGameRepository : ListGameRepository
    {
        public ChessListGameRepository(Game game) : base(game){}
    }
}
