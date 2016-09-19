using System;

namespace MrPitiful.BoardGame.Base
{
    public interface IAdjacentGameBoardSpace
    {
        Guid GameBoardSpaceId { get; set; }
        String Direction { get; set; }
    }
}
