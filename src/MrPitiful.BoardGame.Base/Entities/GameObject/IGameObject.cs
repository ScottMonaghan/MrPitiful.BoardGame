using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public interface IGameObject
    {
        Guid Id { get; set; }
        [JsonIgnore]
        Dictionary<string, string> State { get; }
    }
}
