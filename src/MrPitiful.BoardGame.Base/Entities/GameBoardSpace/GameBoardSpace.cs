using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameBoardSpace : GameObject, IGameBoardSpace
    {
        private List<Guid> _gamePieceIds;
        private Dictionary<string, Guid> _adjacentSpaceIds;
        private Guid _gameId;
        private Guid _gameBoardId;

        public GameBoardSpace()
        {
            _gamePieceIds = new List<Guid>();
            _adjacentSpaceIds = new Dictionary<string, Guid>();
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

        [JsonIgnore]
        public List<Guid> GamePieceIds
        {
            get
            {
                return _gamePieceIds;
            }
        }

        [JsonIgnore]
        public Dictionary<string,Guid> AdjacentSpaceIds
        {
            get
            {
                return _adjacentSpaceIds;
            }
        }
    }
}
