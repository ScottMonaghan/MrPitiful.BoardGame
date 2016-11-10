using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public interface IStateProperty
    {
        Guid Id { get; set; }
        Guid GameId { get; set; }
        Guid GameObjectId { get; set; }
        String Name { get; set; }
        String Value { get; set; }
    }
}

