using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Models
{
    public class GameBoard
    {
        public GameBoard() {
            GameBoardSpaces = new List<GameBoardSpace>();
            StateProperties = new List<GameBoardStateProperty>();
        }
        public List<GameBoardSpace> GameBoardSpaces
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

        public List<GameBoardStateProperty> StateProperties
        {
            get; set;
        }
    }
}
