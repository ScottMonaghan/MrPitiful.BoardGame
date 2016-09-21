using System;
using System.Net.Http;
namespace MrPitiful.BoardGame.Base.Test
{
    public class GenericGamePieceClient : GamePieceClient<GenericGamePiece>
    {
        public GenericGamePieceClient()
        {}
        public GenericGamePieceClient(HttpClient httpClient, string apiRoute = "api/GenericGamePiece") 
            : base(httpClient, apiRoute)
        { }
    }
}
