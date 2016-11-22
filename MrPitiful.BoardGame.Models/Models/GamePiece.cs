using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class GamePiece 
    {
        public GamePiece()
        {
            StateProperties = new List<GamePieceStateProperty>();
        }
        [JsonIgnore]
        public GameBoardSpace GameBoardSpace
        {
            get;set;
        }

        public Guid? GameBoardSpaceId
        {
            get; set;
        }

        [JsonIgnore]
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
