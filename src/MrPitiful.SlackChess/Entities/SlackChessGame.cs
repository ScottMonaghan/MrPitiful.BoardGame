using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public class SlackChessGame : ISlackChessGame
    {
        private Guid _id; 
        private string _slackChannelId;
        private Guid _unicodeChessGameId;
        public SlackChessGame() { }
        public SlackChessGame(string slackChannelId, Guid unicodeChessGameId)
        {
            _slackChannelId = slackChannelId;
            _unicodeChessGameId = unicodeChessGameId;
        }
        public Guid Id
        {
            get { return _id; }
            set { _id = value;}
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
