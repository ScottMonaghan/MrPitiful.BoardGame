using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GamePieceStateProperty:StateProperty
    {

        public GamePiece GamePiece { get; set; }
        public Guid GamePieceId { get; set; }
    }
}
