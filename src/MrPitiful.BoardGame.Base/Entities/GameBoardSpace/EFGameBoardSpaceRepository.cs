namespace MrPitiful.BoardGame.Base
{ 
    public class EFGameBoardSpaceRepository : EFGameObjectRepository, IGameBoardSpaceRepository
    {
        public EFGameBoardSpaceRepository(GameDbContext context, GameBoardSpace gameBoardSpace) : base(context, gameBoardSpace)
        {}
    }
}
