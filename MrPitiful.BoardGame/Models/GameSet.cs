using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GameSet 
    {
        public GameBoard GameBoard
        {
            get;set;
        }

        public List<GamePiece> GamePieces
        {
            get;set;
        }

        public Guid Id
        {
            get;set;
        }

        public List<GameSetStateProperty> StateProperties
        {
            get;set;
        }
    }
}
