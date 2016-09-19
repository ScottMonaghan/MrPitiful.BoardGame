using System;
using System.Collections.Generic;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    //now we can run our unit tests against Generic Game!
    public class GameBoardSpaceTests
    {

        [Fact]
        public void GameBoardSpaceTest()
        {
            //check to make sure game collections were initialized
            GenericGameBoardSpace gameBoardSpace = new GenericGameBoardSpace();
            Assert.NotNull(gameBoardSpace.GamePieceIds);
            Assert.NotNull(gameBoardSpace.AdjacentSpaceIds);
        }
    }
}
