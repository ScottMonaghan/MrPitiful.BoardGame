using MrPitiful.BoardGame.Base;
namespace MrPitiful.UnicodeChess
{ 
    public class ChessEFGamePieceRepository : EFGamePieceRepository
    {
        public ChessEFGamePieceRepository(ChessGamePieceDbContext context, ChessGamePiece gamePiece) : base(context, gamePiece)
        {}
    }
}
