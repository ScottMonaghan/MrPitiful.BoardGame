using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public class ListSlackChessGameRepository : ISlackChessGameRepository
    {
        private Dictionary<string, ISlackChessGame> _slackChessGames = new Dictionary<string, ISlackChessGame>();
        private ISlackChessGame _slackChessGame;

        public ListSlackChessGameRepository(ISlackChessGame slackChessGame)
        {
            _slackChessGame = slackChessGame;
        }
        public ISlackChessGame Create(string slackChannelId, Guid unicodeChessGameId)
        {
            _slackChessGame.SlackChannelId = slackChannelId;
            _slackChessGame.UnicodeChessGameId = unicodeChessGameId;
            if (_slackChessGames.ContainsKey(slackChannelId))
            {
                _slackChessGames[slackChannelId] = _slackChessGame;
            }
            else
            {
                _slackChessGames.Add(slackChannelId, _slackChessGame);
            }
            return _slackChessGame;
        }
        public void Delete(string slackChannelId)
        {
            _slackChessGames.Remove(slackChannelId);
        }

        public ISlackChessGame Get(string slackChannelId)
        {
            return _slackChessGames[slackChannelId];
        }
    }
}
