using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoard
    {
        public List<GameBoardSpace> GameBoardSpaces
        {
            get;set;
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

        public List<GameBoardStateProperty> StateProperties
        {
            get; set;
        }
    }
}
