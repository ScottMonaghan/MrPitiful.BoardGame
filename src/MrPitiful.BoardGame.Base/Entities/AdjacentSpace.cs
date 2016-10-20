using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class AdjacentSpace
    {
        public Guid Id { get; set; }
        public Guid ParentGameBoardSpaceId { get; set;} 
        public GameBoardSpace ParentGameBoardSpace { get; set; }
        public string Direction { get; set; }
        public GameBoardSpace AdjacentGameBoardSpace { get; set; }
        public Guid AdjacentGameBoardSpaceId { get; set; }
    }
}
