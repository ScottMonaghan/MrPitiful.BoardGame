using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Base;
using MrPitiful.UnicodeChess.Models.Interfaces;
namespace MrPitiful.UnicodeChess.Models
{
    public class UnicodeChessGame : Game, IUnicodeChessGame
    {
        public UnicodeChessGame():base(){
                //do something
        }
    }
}
