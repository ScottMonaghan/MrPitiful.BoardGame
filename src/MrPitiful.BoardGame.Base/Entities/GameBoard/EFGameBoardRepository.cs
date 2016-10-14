namespace MrPitiful.BoardGame.Base
{ 
    public class EFGameBoardRepository : EFGameObjectRepository, IGameBoardRepository
    {
        public EFGameBoardRepository(GameBoardDbContext context, GameBoard gameBoard) : base(context, gameBoard)
        {}
    }
}
