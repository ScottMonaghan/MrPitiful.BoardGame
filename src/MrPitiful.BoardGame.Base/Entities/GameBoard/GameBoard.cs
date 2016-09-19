using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{ 
    public abstract class GameBoard : GameObject, IGameBoard
    {
        private List<Guid> _gameBoardSpaceIds;

        private Guid _gameId;

        public GameBoard()
        {
            _gameBoardSpaceIds = new List<Guid>();
        }

        public GameBoard(Guid gameId):this()
        {
            _gameId = gameId;
        }

        public List<Guid> GameBoardSpaceIds
        {
            get
            {
                return _gameBoardSpaceIds;
            }
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
    }
}
