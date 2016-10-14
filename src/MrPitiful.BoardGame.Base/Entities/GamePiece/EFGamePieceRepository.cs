namespace MrPitiful.BoardGame.Base
{ 
    public abstract class EFGamePieceRepository : EFGameObjectRepository, IGamePieceRepository
    {
        public EFGamePieceRepository(GameDbContext context, GamePiece gamePiece) : base(context, gamePiece)
        {}
    }
}
