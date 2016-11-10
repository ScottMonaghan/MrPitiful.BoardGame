using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoardSpace 
    {
        public List<AdjacentSpace> AdjacentSpaces
        {
            get;set;
        }

        public GameBoard GameBoard
        {
            get; set;
        }

        public Guid GameBoardId
        {
            get; set;
        }

        public List<GamePiece> GamePieces
        {
            get; set;
        }

        public Guid Id
        {
            get; set;
        }

        public List<GameBoardSpaceStateProperty> StateProperties
        {
            get; set;
        }
    }
}
