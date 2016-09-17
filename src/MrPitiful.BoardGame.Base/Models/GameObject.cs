using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.BoardGame.Base.Models
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

        public Dictionary<string, string> State
        {
            get
            {
                return _state;
            }
        }
    }
}
