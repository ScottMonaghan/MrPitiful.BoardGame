using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Base
{
    public class StateProperty:IStateProperty
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid GameObjectId { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }
    }
}
