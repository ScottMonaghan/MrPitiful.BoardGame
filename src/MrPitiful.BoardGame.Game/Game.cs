using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Interfaces;

namespace MrPitiful.BoardGame.Game
{
    public class Game:IGame
    {
        private Guid _id;
        private List<Guid> _gameBoardSpaceIds;
        private List<Guid> _gamePieceIds;
        private List<Guid> _playerIds;
        private IDictionary<string, string> _state;
        private DateTime _startTime;
        private DateTime _endTime;
       

        public Game(IDictionary<string,string> state)
        {
            _gameBoardSpaceIds = new List<Guid>();
            _gamePieceIds = new List<Guid>();
            _playerIds = new List<Guid>();
            _state = state;
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

        public IDictionary<string, string> State
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
    }
}
