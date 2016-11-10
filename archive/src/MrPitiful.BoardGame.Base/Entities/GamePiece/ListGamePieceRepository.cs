namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGamePieceRepository : ListGameObjectRepository, IGamePieceRepository
    {
        public ListGamePieceRepository(IGamePiece gamePiece) : base(gamePiece)
        {}
    }
}
