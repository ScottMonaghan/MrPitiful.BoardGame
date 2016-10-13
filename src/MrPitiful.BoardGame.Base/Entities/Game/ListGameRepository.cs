namespace MrPitiful.BoardGame.Base
{ 
    public abstract class ListGameRepository : ListGameObjectRepository, IGameRepository
    {
        public ListGameRepository(Game game) : base(game)
        {}
    }
}
