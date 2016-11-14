using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class SpaceConnection
    {
        [JsonIgnore]
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

        public Guid? RemoteSpaceId
        {
            get;set;
        }

        public List<SpaceConnectionStateProperty> StateProperties
        {
            get; set;
        }
    }
}
