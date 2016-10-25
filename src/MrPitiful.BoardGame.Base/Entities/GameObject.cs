using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameObject
    {
        public Guid Id { get; set; }

        //spublic Guid GameId{ get; set; }
        
        public List<StateProperty> StateProperties{ get; set; }

        public GameBox GameBox { get; set; }
        public Guid GameBoxId { get; set; }
    }
}
