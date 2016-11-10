using System;
using System.Net.Http;
namespace MrPitiful.BoardGame.Base.Test
{
    public class GenericGameObjectClient : GameObjectClient<GenericGameObject>
    {
        //public GenericGameObjectClient()
        //{}
        public GenericGameObjectClient(HttpClient httpClient, string apiRoute = "api/GenericGameObject") 
            : base(httpClient, apiRoute)
        { }
    }
}
