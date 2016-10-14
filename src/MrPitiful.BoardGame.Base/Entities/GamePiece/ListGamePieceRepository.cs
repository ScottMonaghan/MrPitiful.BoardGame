namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGamePieceRepository : ListGameObjectRepository, IGamePieceRepository
    {
        public ListGamePieceRepository(GamePiece gamePiece) : base(gamePiece)
        {}
    }
}
