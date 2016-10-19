using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class StateProperty { 
        public Guid Id { get; set; }
        public Guid GameObjectId{ get; set; }
        public GameObject GameObject { get; set;}
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
