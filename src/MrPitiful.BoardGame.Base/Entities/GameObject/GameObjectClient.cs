using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameObjectClient<TGameObject> : IGameObjectClient<TGameObject>
        where TGameObject:IGameObject
            {
        private string _apiRoute;
        private HttpClient _httpClient;

        public GameObjectClient()
        {
        }

        public GameObjectClient(HttpClient httpClient, string apiRoute = "api/GameObject")
        {
            _apiRoute = apiRoute;
            _httpClient = httpClient;
        }

        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

        //Dictionary<Guid, TGameObject> Get();
        public async Task<TGameObject> Create()
        {
            var response = await _httpClient.GetAsync("/"+ _apiRoute + "/Create");
            TGameObject result = JsonConvert.DeserializeObject<TGameObject>(
                    response.Content.ReadAsStringAsync().Result
                );
            return result;
        }

        public async Task<Dictionary<Guid, TGameObject>> Get()
        {
            var response = await _httpClient.GetAsync("/" + _apiRoute + "/");
            return JsonConvert.DeserializeObject<Dictionary<Guid, TGameObject>>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task<TGameObject> Get(Guid gameObjectId)
        {
            var response2 = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/{0}", gameObjectId));
            TGameObject gotGameObject = JsonConvert.DeserializeObject<TGameObject>(
                    response2.Content.ReadAsStringAsync().Result
                );
            return gotGameObject;
        }

        public async Task<string> GetStateProperty(Guid gameObjectId, string propertyName)
        {
            var response = await _httpClient.GetAsync(string.Format("/" + _apiRoute + "/getStateProperty/{0}/{1}", gameObjectId, propertyName));
            return response.Content.ReadAsStringAsync().Result;

        }

        public async Task SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue)
        {
            await _httpClient.GetAsync(string.Format("/" + _apiRoute + "/SetStateProperty/{0}/{1}/{2}", gameObjectId, propertyName, propertyValue));
        }
    }
}
