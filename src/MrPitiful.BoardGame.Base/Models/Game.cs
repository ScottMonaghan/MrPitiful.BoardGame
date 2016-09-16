using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models.Interfaces;

namespace MrPitiful.BoardGame.Base.Models
{
    public abstract class Game:IGame
    {
        private Guid _id;
        private List<Guid> _gameBoardSpaceIds;
        private List<Guid> _gamePieceIds;
        private List<Guid> _playerIds;
        private Dictionary<string, string> _state;
        private DateTime _startTime;
        private DateTime _endTime;
       

        public Game()
        {
            _gameBoardSpaceIds = new List<Guid>();
            _gamePieceIds = new List<Guid>();
            _playerIds = new List<Guid>();
            _state = new Dictionary<string, string>();
        }

        public List<Guid> GameBoardSpaceIds
        {
            get
            {
                return _gameBoardSpaceIds;
            }

            set
            {
                _gameBoardSpaceIds = value;
            }

        }

        public List<Guid> GamePieceIds
        {
            get
            {
                return _gamePieceIds;
            }

            set
            {
                _gamePieceIds = value;
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

        public List<Guid> PlayerIds
        {
            get
            {
                return _playerIds;
            }

            set
            {
                _playerIds = value;
            }
        }

        public Dictionary<string, string> State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
            }
        }

        public abstract void BeforeStep(string stepName, object parameters);
        public abstract void DuringStep(string stepName, object parameters);
        public abstract void AfterStep(string stepName, object parameters);
    }
}
