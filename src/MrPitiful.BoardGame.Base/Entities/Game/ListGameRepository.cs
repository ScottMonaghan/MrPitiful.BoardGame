namespace MrPitiful.BoardGame.Base
{ 
    public abstract class ListGameRepository : ListGameObjectRepository, IGameRepository
    {
        public ListGameRepository(IGame game) : base(game)
        {}
    }
}
