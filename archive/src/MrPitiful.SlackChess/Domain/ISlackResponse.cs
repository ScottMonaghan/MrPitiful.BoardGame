using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public interface ISlackResponse
    {
        string response_type { get; set; }
        string text { get; set; }
    }
}
