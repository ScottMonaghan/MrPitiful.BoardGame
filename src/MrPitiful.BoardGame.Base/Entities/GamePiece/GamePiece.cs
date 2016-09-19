using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{ 
    public abstract class GamePiece : GameObject, IGamePiece
    {
        private Guid _gameBoardSpaceId;
        private Guid _gameId;

        public GamePiece() { }
        public GamePiece(Guid gameId, Guid gameBoardSpaceId) {
            _gameId = gameId;
            _gameBoardSpaceId = gameBoardSpaceId;
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

        public Guid GameBoardSpaceId
        {
            get
            {
                return _gameBoardSpaceId;
            }

            set
            {
                _gameBoardSpaceId = value;
            }
        }
    }
}
