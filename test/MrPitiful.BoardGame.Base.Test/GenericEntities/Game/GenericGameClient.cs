using System;
using System.Net.Http;
namespace MrPitiful.BoardGame.Base.Test
{
    public class GenericGameClient : GameClient<GenericGame>
    {
        public GenericGameClient()
        {}
        public GenericGameClient(HttpClient httpClient, string apiRoute = "api/GenericGame") 
            : base(httpClient, apiRoute)
        { }
    }
}
