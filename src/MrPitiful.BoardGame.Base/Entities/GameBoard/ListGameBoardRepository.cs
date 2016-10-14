namespace MrPitiful.BoardGame.Base
{
    public abstract class ListGameBoardRepository : ListGameObjectRepository, IGameBoardRepository
    {
        public ListGameBoardRepository(GameBoard gameBoard) : base(gameBoard)
        {}
    }
}
