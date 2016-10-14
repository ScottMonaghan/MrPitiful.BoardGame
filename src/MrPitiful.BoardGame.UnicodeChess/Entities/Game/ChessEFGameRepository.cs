using MrPitiful.BoardGame.Base;
namespace MrPitiful.UnicodeChess
{ 
    public class ChessEFGameRepository : EFGameRepository
    {
        public ChessEFGameRepository(ChessGameDbContext context, ChessGame game) : base(context, game)
        {}
    }
}
