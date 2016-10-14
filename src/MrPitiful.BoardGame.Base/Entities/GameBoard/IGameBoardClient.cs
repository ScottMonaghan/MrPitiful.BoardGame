using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameBoardClient<TGameBoard>:IGameObjectClient<TGameBoard>
        where TGameBoard:GameBoard
    {
        //gamePieceIds
        Task AddGameBoardSpaceIdToGameBoard(Guid gameBoardSpaceId, Guid gameBoardId);
        Task<bool> GameBoardContainsGameBoardSpaceId(Guid gameBoardId, Guid gameBoardSpaceId);
        Task RemoveGameBoardSpaceIdFromGameBoard(Guid gameBoardSpaceId, Guid gameBoardId);
    }
}
