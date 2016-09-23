using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameObjectClient<TGameObject>
        where TGameObject:IGameObject
    {
        HttpClient HttpClient { get; }
        Task<Dictionary<Guid, TGameObject>> Get();
        Task<TGameObject> Get(Guid id);
        Task<TGameObject> Create();
        Task<string> GetStateProperty(Guid gameObjectId, string propertyName);
        Task SetStateProperty(Guid gameObjectId, string propertyName, string propertyValue);
        Task SetGameId(Guid gameObjectId, Guid gameId);
    }
}
