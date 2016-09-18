using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base.Models.Interfaces
{
    public interface IGameObject
    {
        Guid Id { get; set; }
        [JsonIgnore]
        Dictionary<string, string> State { get; }
    }
}
