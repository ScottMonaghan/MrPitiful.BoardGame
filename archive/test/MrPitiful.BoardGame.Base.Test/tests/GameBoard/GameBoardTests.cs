using System;
using System.Collections.Generic;
using Xunit;

namespace MrPitiful.BoardGame.Base.Test
{
    //now we can run our unit tests against Generic Game!
    public class GameBoardTests
    {

        [Fact]
        public void GameBoardTest()
        {
            //check to make sure game collections were initialized
            GenericGameBoard gameBoard = new GenericGameBoard();
            Assert.NotNull(gameBoard.GameBoardSpaceIds);
        }

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
    }
}
