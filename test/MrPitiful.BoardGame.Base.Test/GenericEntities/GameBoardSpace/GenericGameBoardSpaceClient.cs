using System;
using System.Net.Http;
namespace MrPitiful.BoardGame.Base.Test
{
    public class GenericGameBoardSpaceClient : GameBoardSpaceClient<GenericGameBoardSpace>
    {
        public GenericGameBoardSpaceClient()
        {}
        public GenericGameBoardSpaceClient(HttpClient httpClient, string apiRoute = "api/GenericGameBoardSpace") 
            : base(httpClient, apiRoute)
        { }
    }
}
