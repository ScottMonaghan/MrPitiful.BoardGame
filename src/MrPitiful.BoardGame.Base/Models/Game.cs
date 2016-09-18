using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models.Interfaces;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base.Models
{
    public abstract class Game:GameObject, IGame
    {
        private Guid _gameBoardId;
        private List<Guid> _gameBoardSpaceIds;
        private List<Guid> _gamePieceIds;
        private List<Guid> _playerIds;
        private DateTime _startTime;
        private DateTime _endTime;
       
        public Game()
        {
            _gameBoardSpaceIds = new List<Guid>();
            _gamePieceIds = new List<Guid>();
            _playerIds = new List<Guid>();
        }

        [JsonIgnore]
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

        [JsonIgnore]
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

        [JsonIgnore]
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

        public Guid GameBoardId
        {
            get
            {
                return _gameBoardId;
            }
            set
            {
                _gameBoardId = value;
            }
        }
    }
}
