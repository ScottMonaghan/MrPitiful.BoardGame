using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base;
using MrPitiful.UnicodeChess.Models.Interfaces;

namespace MrPitiful.UnicodeChess.Repositories
{
    public class ListUnicodeChessGameRepository : ListGameRepository
    {
        public ListUnicodeChessGameRepository(IUnicodeChessGame game):base(game)
        {
            //do something
        }
    }
}
