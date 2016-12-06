﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class GameSetStateProperty : StateProperty
    {
        [JsonIgnore]
        public GameSet GameSet { get; set; }
        public Guid GameSetId {get;set;}
    }
}