using System;

namespace MrPitiful.BoardGame.Base
{

    public class AdjacentGameBoardSpace:IAdjacentGameBoardSpace
    {
        private Guid _gameBoardSpaceId;
        private String _direction;

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
        public String Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        AdjacentGameBoardSpace()
        {}

        AdjacentGameBoardSpace(Guid gameBoardSpaceId, String direction)
        {
            _gameBoardSpaceId = gameBoardSpaceId;
            _direction = direction;
        }
    }
}
