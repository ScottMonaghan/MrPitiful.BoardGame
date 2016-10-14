using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class GameObject
    {
        private Guid _id;
        private Guid _gameId;
        private Dictionary<string, string> _state;
        
        public GameObject()
        {
            _state = new Dictionary<string, string>();
        }

        public Guid GameId
        {
            get
            {
                return _gameId;
            }

            set
            {
                _gameId = value;
            }
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
