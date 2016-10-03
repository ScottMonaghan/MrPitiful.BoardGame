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

        //public GameObjectClient()
        //{
        //}

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

            set
            {
                _httpClient = value;
            }
        }
      
        public string ApiRoute
        {
            get
            {
                return _apiRoute;
            }

            set
            {
                _apiRoute = value;
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

        public async Task SetGameId(Guid gameObjectId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/SetGameId/{0}/{1}", gameObjectId, gameId));
        }

        public async Task<Guid> GetGameId(Guid gameObjectdId)
        {
            var response = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/GetGameId/{0}", gameObjectdId));
            Guid gotGameId = JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );
            return gotGameId;
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

        public async Task<List<TGameObject>> GetByStateProperties(Guid gameId, Dictionary<string,string> stateProperties)
        {
            string propertyString = "";

            foreach (KeyValuePair<string,string> stateProperty in stateProperties)
            {
                propertyString += String.Format("/{0}:{1}", WebUtility.UrlEncode(stateProperty.Key), WebUtility.UrlEncode(stateProperty.Value));
            }
            var response = await _httpClient.GetAsync(string.Format("/" + _apiRoute + "/GetByStateProperties/{0}{1}", gameId, propertyString));
            List<TGameObject> gotGameObjects = JsonConvert.DeserializeObject<List<TGameObject>>(
                    response.Content.ReadAsStringAsync().Result
            );
            return gotGameObjects;
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

        public async Task ClearStateProperty(Guid gameObjectId, string propertyName)
        {
            await _httpClient.GetAsync(string.Format("/" + _apiRoute + "/ClearStateProperty/{0}/{1}", gameObjectId, propertyName));
        }
    }
}
