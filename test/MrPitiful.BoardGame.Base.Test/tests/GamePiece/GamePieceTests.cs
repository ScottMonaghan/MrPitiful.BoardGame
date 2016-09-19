using System;
using System.Collections.Generic;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    //now we can run our unit tests against Generic Game!
    public class GamePieceTests
    {
        [Fact]
        public void GameIdTest()
        {
            //arange
            GenericGamePiece gamePiece = new GenericGamePiece();
            Guid newGameId = Guid.NewGuid();

            //act
            gamePiece.GameId = newGameId;

            //assert
            Assert.Equal<Guid>(newGameId, gamePiece.GameId);
        }

        [Fact]
        public void GameBoardSpaceIdTest()
        {
            //arange
            GenericGamePiece gamePiece = new GenericGamePiece();
            Guid newGameBoardSpaceId = Guid.NewGuid();

            //act
            gamePiece.GameBoardSpaceId = newGameBoardSpaceId;

            //assert
            Assert.Equal<Guid>(newGameBoardSpaceId, gamePiece.GameBoardSpaceId);
        }
    }
}
