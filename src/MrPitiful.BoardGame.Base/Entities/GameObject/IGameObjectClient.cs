using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameObjectClient<TGameObject>
        where TGameObject:GameObject
    {
        HttpClient HttpClient { get; set; }
        String ApiRoute { get; set; }
        Task<Dictionary<Guid, TGameObject>> Get();
        Task<TGameObject> Get(Guid id);
        Task<TGameObject> Create();
        Task<string> GetStateProperty(Guid gameObjectId, string propertyName);
        Task ClearStateProperty(Guid gameObjectId, string propertyName);
        Task SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue);
        Task SetGameId(Guid gameObjectId, Guid gameId);
        Task<List<TGameObject>> GetByStateProperties(Guid gameId, Dictionary<string, string> stateProperties);
    }
}
