using System;
using System.Net.Http;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGameBoardClient : GameBoardClient<ChessGameBoard>, IChessGameBoardClient
    {
        public ChessGameBoardClient()
        {}
        public ChessGameBoardClient(HttpClient httpClient, string apiRoute = "api/ChessGameBoard") 
            : base(httpClient, apiRoute)
        { }
    }
}
