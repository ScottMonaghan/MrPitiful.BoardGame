using System;
using System.Net.Http;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGameBoardSpaceClient : GameBoardSpaceClient<ChessGameBoardSpace>, IChessGameBoardSpaceClient
    {
        public ChessGameBoardSpaceClient()
        {}
        public ChessGameBoardSpaceClient(HttpClient httpClient, string apiRoute = "api/ChessGameBoardSpace") 
            : base(httpClient, apiRoute)
        { }
    }
}
