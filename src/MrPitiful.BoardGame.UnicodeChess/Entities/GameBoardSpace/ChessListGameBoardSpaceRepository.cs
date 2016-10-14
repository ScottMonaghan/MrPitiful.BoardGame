using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    //first we need to make a generic listgamerepository to inherit from the base class of game
    public class ChessListGameBoardSpaceRepository : ListGameBoardSpaceRepository
    {
        public ChessListGameBoardSpaceRepository(GameBoardSpace gameBoardSpace) : base(gameBoardSpace){}
    }
}
