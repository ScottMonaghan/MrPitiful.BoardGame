using System;
using System.Net.Http;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGameClient : GameClient<ChessGame>
    {
        public ChessGameClient()
        {}
        public ChessGameClient(HttpClient httpClient, string apiRoute = "api/ChessGame") 
            : base(httpClient, apiRoute)
        { }
    }
}
