using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGamePiece : GamePiece, IChessGamePiece {
        public ChessGamePiece():base() { }
        public ChessGamePiece(Guid gameId, Guid gameBoardSpaceId) : base(gameId, gameBoardSpaceId) { }
    }
}
