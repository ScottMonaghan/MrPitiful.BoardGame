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
        private Guid _gameBoardId;

        public GamePiece() { }
        public GamePiece(Guid gameId, Guid gameBoardSpaceId) {
            base.GameId = gameId;
            _gameBoardSpaceId = gameBoardSpaceId;
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
