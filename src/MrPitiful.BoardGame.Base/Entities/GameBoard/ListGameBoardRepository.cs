namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGameBoardRepository : ListGameObjectRepository, IGameBoardRepository
    {
        public ListGameBoardRepository(IGameBoard gameBoard) : base(gameBoard)
        {}
    }
}
