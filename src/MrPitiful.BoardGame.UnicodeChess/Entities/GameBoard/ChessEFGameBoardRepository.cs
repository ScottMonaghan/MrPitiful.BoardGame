using MrPitiful.BoardGame.Base;
namespace MrPitiful.UnicodeChess
{ 
    public class ChessEFGameBoardRepository : EFGameBoardRepository
    {
        public ChessEFGameBoardRepository(ChessGameBoardDbContext context, ChessGameBoard gameBoard) : base(context, gameBoard)
        {}
    }
}
