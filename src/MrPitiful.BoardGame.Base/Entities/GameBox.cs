using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public class GameBox
    {
        public Guid Id { get; set; }

        public List<GameObject> GameObjects{ get; set; }
    }
}
