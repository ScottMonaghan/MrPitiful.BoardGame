using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameObject:IGameObject
    {
        private Guid _id;
        private Dictionary<string, string> _state;
        
        public GameObject()
        {
            _state = new Dictionary<string, string>();
        }

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        [JsonIgnore]
        public Dictionary<string, string> State
        {
            get
            {
                return _state;
            }
        }
    }
}
