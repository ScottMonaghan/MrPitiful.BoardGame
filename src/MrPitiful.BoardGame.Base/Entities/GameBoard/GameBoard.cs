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

        public GameBoard()
        {
            _gameBoardSpaceIds = new List<Guid>();
        }

        public GameBoard(Guid gameId):this()
        {
            this.GameId = gameId;
        }

        public List<Guid> GameBoardSpaceIds
        {
            get
            {
                return _gameBoardSpaceIds;
            }
        }
    }
}
