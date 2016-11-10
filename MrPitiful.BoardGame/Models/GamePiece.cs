using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GamePiece 
    {
        public GameBoardSpace GameBoardSpace
        {
            get;set;
        }

        public Guid? GameBoardSpaceId
        {
            get; set;
        }

        public GameSet GameSet
        {
            get; set;
        }

        public Guid GameSetId
        {
            get; set;
        }

        public Guid Id
        {
            get; set;
        }

        public List<GamePieceStateProperty> StateProperties
        {
            get; set;
        }
    }
}
