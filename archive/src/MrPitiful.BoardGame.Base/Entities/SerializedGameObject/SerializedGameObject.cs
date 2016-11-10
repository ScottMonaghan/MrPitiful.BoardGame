using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base
{
    public class SerializedGameObject
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public String value { get; set; }
    }
}
