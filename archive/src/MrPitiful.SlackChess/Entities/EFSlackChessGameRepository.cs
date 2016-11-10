using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.SlackChess
{
    public class EFSlackChessGameRepository : ISlackChessGameRepository
    {
        //private ISlackChessGame _slackChessGame;
        private SlackChessGameDbContext _context;

        public EFSlackChessGameRepository(SlackChessGameDbContext context)
        {
            _context = context;
        }
        public ISlackChessGame Create(string slackChannelId, Guid unicodeChessGameId)
        {

            SlackChessGame slackChessGame;
            if (_context.SlackChessGames.Any(o => o.SlackChannelId == slackChannelId))
            {
                slackChessGame = _context.SlackChessGames.Where(o => o.SlackChannelId == slackChannelId).ToList()[0];
                slackChessGame.UnicodeChessGameId = unicodeChessGameId;
                _context.SaveChanges();
            }else
            {
                slackChessGame = new SlackChessGame(slackChannelId, unicodeChessGameId);
                _context.SlackChessGames.Add(slackChessGame);
                _context.SaveChanges();
            }
            return slackChessGame;
        }
        public void Delete(string slackChannelId)
        {
            var slackChessGame = _context.SlackChessGames.Single(o => o.SlackChannelId == slackChannelId);
            _context.SlackChessGames.Remove(slackChessGame);
            _context.SaveChanges();
        }

        public ISlackChessGame Get(string slackChannelId)
        {
            return _context.SlackChessGames.Single(o => o.SlackChannelId == slackChannelId);
        }
    }
}
