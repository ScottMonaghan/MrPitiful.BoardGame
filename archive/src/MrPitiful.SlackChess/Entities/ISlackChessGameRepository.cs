using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public interface ISlackChessGameRepository
    {
        ISlackChessGame Create(string slackChannelId, Guid unicodeChessGameId);
        ISlackChessGame Get(string slackChannelId);
        void Delete(string slackChannelId);
    }
}
