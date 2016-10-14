using MrPitiful.BoardGame.Base;
namespace MrPitiful.UnicodeChess
{ 
    public class ChessEFGameBoardSpaceRepository : EFGameBoardSpaceRepository
    {
        public ChessEFGameBoardSpaceRepository(ChessGameBoardSpaceDbContext context, ChessGameBoardSpace gameBoardSpace) : base(context, gameBoardSpace)
        {}
    }
}
