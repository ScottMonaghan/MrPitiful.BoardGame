using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MrPitiful.BoardGame.Models
{
    public class Die 
    {
        public Die()
        {
            StateProperties = new List<DieStateProperty>();
        }
        public int Sides
        {
            get;set;
        }
        public int Value
        {
            get;set;
        }
        [JsonIgnore]
        public GameSet GameSet
        {
            get; set;
        }
        public Guid GameSetId
        {
            get; set;
        }
        public Guid Id
        {
            get; set;
        }
        public List<DieStateProperty> StateProperties
        {
            get; set;
        }
    }
}
