using System;
using System.Net.Http;
namespace MrPitiful.BoardGame.Base.Test
{
    public class GenericGameBoardClient : GameBoardClient<GenericGameBoard>
    {
        //public GenericGameBoardClient()
        //{}
        public GenericGameBoardClient(HttpClient httpClient, string apiRoute = "api/GenericGameBoard") 
            : base(httpClient, apiRoute)
        { }
    }
}
