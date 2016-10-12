using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public interface ISlackChessGame
    {
        Guid Id { set; get;}
        Guid UnicodeChessGameId { set; get; }
        String SlackChannelId { set; get; }
    }
}
