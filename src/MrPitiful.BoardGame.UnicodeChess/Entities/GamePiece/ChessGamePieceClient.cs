using System;
using System.Net.Http;
using MrPitiful.BoardGame.Base;

namespace MrPitiful.UnicodeChess
{
    public class ChessGamePieceClient : GamePieceClient<ChessGamePiece>, IChessGamePieceClient
    {
        public ChessGamePieceClient()
        {}
        public ChessGamePieceClient(HttpClient httpClient, string apiRoute = "api/ChessGamePiece") 
            : base(httpClient, apiRoute)
        { }
    }
}
