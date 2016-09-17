using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Services;
using MrPitiful.BoardGame.Base.Repositories.Interfaces;

namespace MrPitiful.UnicodeChess.Services
{
    public class UnicodeChessGameService:GameService
    {
        public UnicodeChessGameService(IGameRepository gameRepository) : base(gameRepository)
        {
            //do something
        }

        public override void AfterGameStep(string gameStep, object Parameters)
        {
            throw new NotImplementedException();
        }

        public override void BeforeGameStep(string gameStep, object Parameters)
        {
            throw new NotImplementedException();
        }

        public override void DuringGameStep(string gameStep, object Parameters)
        {
            throw new NotImplementedException();
        }
    }
}
