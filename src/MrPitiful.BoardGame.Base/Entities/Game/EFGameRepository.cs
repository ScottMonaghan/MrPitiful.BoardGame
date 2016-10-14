namespace MrPitiful.BoardGame.Base
{ 
    public abstract class EFGameRepository : EFGameObjectRepository, IGameRepository
    {
        public EFGameRepository(GameDbContext context, Game game) : base(context, game)
        {}
    }
}
