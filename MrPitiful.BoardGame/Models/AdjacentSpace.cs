using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Models
{
    public class AdjacentSpace
    {
        public string Direction
        {
            get;set;
        }

        public GameBoardSpace GameBoardSpace
        {
            get; set;
        }

        public Guid GameBoardSpaceId
        {
            get; set;
        }

        public Guid Id
        {
            get; set;
        }

        public GameBoardSpace RemoteSpace
        {
            get; set;
        }
    }
}
