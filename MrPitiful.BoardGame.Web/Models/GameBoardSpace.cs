using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class GameBoardSpace 
    {
        public List<SpaceConnection> SpaceConnections
        {
            get;set;
        }

        [JsonIgnore]
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
