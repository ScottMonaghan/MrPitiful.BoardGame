using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base.Models;

namespace MrPitiful.UnicodeChess.Models
{
    public class UnicodeChessGame : Game
    {
        public UnicodeChessGame():base(){
                //do something
        }
        public override void AfterStep(string stepName, object parameters)
        {
            throw new NotImplementedException();
        }

        public override void BeforeStep(string stepName, object parameters)
        {
            throw new NotImplementedException();
        }

        public override void DuringStep(string stepName, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
