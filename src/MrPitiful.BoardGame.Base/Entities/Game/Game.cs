using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class Game:GameObject
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
        /*
        //keep Id & GameId in-sync at game level.  They should always be the same.
        public new Guid Id
        {
            get {
                return base.Id;
            }

            set {
                base.Id = value;
                base.GameId = value;
            }
        }
        //keep Id & GameId in-sync at game level.  They should always be the same.
        public new Guid GameId
        {
            get
            {
                return base.GameId;
            }

            set
            {
                base.Id = value;
                base.GameId = value;
            }
        }
        */
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
