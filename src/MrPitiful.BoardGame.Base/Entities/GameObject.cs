using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class GameObject
    {
        public Guid Id { get; set; }

        public Guid GameId{ get; set; }
        
        public List<StateProperty> StateProperties{ get; set; }
    }
}
