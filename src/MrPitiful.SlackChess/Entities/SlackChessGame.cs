using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public class SlackChessGame : ISlackChessGame
    {
        private string _slackChannelId;
        private Guid _unicodeChessGameId;
        public SlackChessGame() { }
        public SlackChessGame(string slackChannelId, Guid unicodeChessGameId)
        {
            _slackChannelId = slackChannelId;
            _unicodeChessGameId = unicodeChessGameId;
        }
        public string SlackChannelId
        {
            get
            {
                return _slackChannelId;
            }

            set
            {
                _slackChannelId = value;
            }
        }

        public Guid UnicodeChessGameId
        {
            get
            {
                return _unicodeChessGameId;
            }

            set
            {
                _unicodeChessGameId = value;
            }
        }
    }
}
