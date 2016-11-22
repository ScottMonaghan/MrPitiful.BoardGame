using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class GamePieceStateProperty:StateProperty
    {
        [JsonIgnore]
        public GamePiece GamePiece { get; set; }
        public Guid GamePieceId { get; set; }
    }
}
