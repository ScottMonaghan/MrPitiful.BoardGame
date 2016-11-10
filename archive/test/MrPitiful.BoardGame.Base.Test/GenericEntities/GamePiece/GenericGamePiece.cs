using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base.Test
{
    public class GenericGamePiece : GamePiece {
        public GenericGamePiece():base() { }
        public GenericGamePiece(Guid gameId, Guid gameBoardSpaceId) : base(gameId, gameBoardSpaceId) { }
    }
}
