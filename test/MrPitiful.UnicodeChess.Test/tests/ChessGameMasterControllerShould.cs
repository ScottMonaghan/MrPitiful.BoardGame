using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace MrPitiful.UnicodeChess.Test
{
    //now we can run our unit tests against Generic Game!
    public class ChessGameMasterControllerShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private ChessGameClient _chessGameClient;
        private ChessGameBoardClient _chessGameBoardClient;
        private ChessGameBoardSpaceClient _chessGameBoardSpaceClient;
        private ChessGamePieceClient _chessGamePieceClient;
        private ChessGameMasterController _ChessGameMasterController;

        public ChessGameMasterControllerShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            _chessGameClient = new ChessGameClient(_client);
            _chessGameBoardClient = new ChessGameBoardClient(_client);
            _chessGameBoardSpaceClient = new ChessGameBoardSpaceClient(_client);
            _chessGamePieceClient = new ChessGamePieceClient(_client);
            _ChessGameMasterController = new ChessGameMasterController(
                _chessGameClient,
                _chessGameBoardClient,
                _chessGameBoardSpaceClient,
                _chessGamePieceClient
                );
        }

        [Fact]
        public async void AddChessGameBoardToChessGame()
        {

            //Arrange
            //create a new game
            ChessGame chessGame = await _chessGameClient.Create();
            //Create a new gameboard
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();

            //Act
            await _ChessGameMasterController.AddChessGameBoardToChessGame(chessGame.Id, chessGameBoard.Id);

            //Assert
            //Gameboard's gameId should equal chessgame's Id
            Assert.Equal(chessGame.Id, await _chessGameBoardClient.GetGameId(chessGameBoard.Id));
            //chessGame's gameBoardId should equal chessGameBoard's Id
            Assert.Equal(chessGameBoard.Id, await _chessGameClient.GetGameBoardId(chessGame.Id));
        }

        [Fact]
        public async void AddChessGameBoardSpaceToChessGameBoard()
        {
            //Arrange
            //create a new game
            ChessGame chessGame = await _chessGameClient.Create();
            //Create a new gameboard
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();
            //Create gameBoardSpace
            ChessGameBoardSpace chessGameBoardSpace = await _chessGameBoardSpaceClient.Create();

            //Act
            //Add gameBoardSpace to ChessGameboard
            await _ChessGameMasterController.AddChessGameBoardSpaceToChessGameBoard(chessGame.Id, chessGameBoardSpace.Id, chessGameBoard.Id);

            //Assert
            //gameBoardSpace.GameId should equal game.Id
            Assert.Equal(chessGame.Id, await _chessGameBoardSpaceClient.GetGameId(chessGameBoardSpace.Id));
            //gameBoardSpace.GameBoardId should equal gameBoard.Id
            Assert.Equal(chessGameBoard.Id,
                await _chessGameBoardSpaceClient.GetGameBoardSpaceGameBoardId(chessGameBoardSpace.Id));
            //gameBoard should contain GameBoardSpace
            Assert.True(
                await _chessGameBoardClient
                .GameBoardContainsGameBoardSpaceId(chessGameBoard.Id, chessGameBoardSpace.Id));

            //game should containGameBoardSpace
            Assert.True(
                await _chessGameClient
                .GameContainsGameBoardSpaceId(chessGame.Id, chessGameBoardSpace.Id));
        }

        [Fact]
        public async void CreateChessGameBoardSpace()
        {
            //Arrange
            //create a new game
            ChessGame chessGame = await _chessGameClient.Create();
            //Create a new gameboard
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();
            //Create gameBoardSpace
            //ChessGameBoardSpace chessGameBoardSpace = await _chessGameBoardSpaceClient.Create();
            int rank = 1;
            char file = 'a';
            string color = "black";

            //Act
            //CreateChessGameBoardSpace
            Guid chessGameBoardSpaceId = await _ChessGameMasterController.CreateChessGameBoardSpace(
                chessGame.Id,
                chessGameBoard.Id,
                rank,
                file,
                color);

            //get created gameboardspace
            ChessGameBoardSpace chessGameBoardSpace =
                await _chessGameBoardSpaceClient.Get(chessGameBoardSpaceId);

            //Assert
            //gameBoardSpace.GameId should equal game.Id
            Assert.Equal(chessGame.Id, await _chessGameBoardSpaceClient.GetGameId(chessGameBoardSpace.Id));
            //gameBoardSpace.GameBoardId should equal gameBoard.Id
            Assert.Equal(chessGameBoard.Id,
                await _chessGameBoardSpaceClient.GetGameBoardSpaceGameBoardId(chessGameBoardSpace.Id));
            //gameBoard should contain GameBoardSpace
            Assert.True(
                await _chessGameBoardClient
                .GameBoardContainsGameBoardSpaceId(chessGameBoard.Id, chessGameBoardSpace.Id));
            //game should containGameBoardSpace
            Assert.True(
                await _chessGameClient
                .GameContainsGameBoardSpaceId(chessGame.Id, chessGameBoardSpace.Id));
            //rank should be rank
            Assert.Equal(rank.ToString(),
                await _chessGameBoardSpaceClient.GetStateProperty(chessGameBoardSpaceId, "rank"));
            //file should be file
            Assert.Equal(file.ToString(),
                await _chessGameBoardSpaceClient.GetStateProperty(chessGameBoardSpaceId, "file"));
            //color should be color
            Assert.Equal(color,
                await _chessGameBoardSpaceClient.GetStateProperty(chessGameBoardSpaceId, "color"));

        }

        [Fact]
        public async void CreateRecipricalAdjacentSpaces()
        {
            //Arrange
            //create space 1
            ChessGameBoardSpace space1 = await _chessGameBoardSpaceClient.Create();
            //create space 2
            ChessGameBoardSpace space2 = await _chessGameBoardSpaceClient.Create();
            //directionFrom1to2
            string directionFrom1to2 = "directionFrom1to2";
            //direction from 2 to 1
            string directionFrom2to1 = "directionFrom2to1";

            //Act
            //CreateRecipricalAdjacentSpaces
            await _ChessGameMasterController.CreateRecipricalAdjacentSpaces(
                space1.Id,
                space2.Id,
                directionFrom1to2,
                directionFrom2to1
                );

            //Assert
            //space1 should have an adjacenct space space2 in directionFrom1to2
            Assert.Equal(space2.Id,
                await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection
                (space1.Id, directionFrom1to2));
            //space2 should have an adjacenct space space1 in directionFrom2to1
            Assert.Equal(space1.Id,
                await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection
                (space2.Id, directionFrom2to1));
        }

        [Fact]
        public async void GetSpaceByRankAndFile()
        {
            //Arrange
            //create a new game
            ChessGame chessGame = await _chessGameClient.Create();
            //Create a new gameboard
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();
            //Create gameBoardSpace
            //ChessGameBoardSpace chessGameBoardSpace = await _chessGameBoardSpaceClient.Create();
            int rank = 1;
            char file = 'a';
            string color = "black";
            //CreateChessGameBoardSpace
            Guid chessGameBoardSpaceId = await _ChessGameMasterController.CreateChessGameBoardSpace(
                chessGame.Id,
                chessGameBoard.Id,
                rank,
                file,
                color);

            //Act
            ChessGameBoardSpace gotSpace = await _ChessGameMasterController
                .GetSpaceByRankAndFile(chessGame.Id, 1, 'a');

            //Assert
            //gotSpace.Id should be the same as chessGameBoardId
            Assert.Equal(chessGameBoardSpaceId, gotSpace.Id);
        }

        [Fact]
        public async void CreateChessBoard() {
            //Arrange
            //create game
            ChessGame chessGame = await _chessGameClient.Create();

            //Act
            //create chessboard
            Guid chessGameBoardId = await _ChessGameMasterController.CreateChessBoard(chessGame.Id);

            //Assert
            //chessboard should have 32 white spaces
            var whiteSpaces = await _chessGameBoardSpaceClient.GetByStateProperties(
                    chessGame.Id,
                    new Dictionary<string, string>() { { "color", "white" } }
                    );
            Assert.Equal(32, whiteSpaces.Count());

            //chessboard should have 32 black spaces
            var blackSpaces = await _chessGameBoardSpaceClient.GetByStateProperties(
                    chessGame.Id,
                    new Dictionary<string, string>() { { "color", "black" } }
                    );
            Assert.Equal(32, blackSpaces.Count());

            //chessboard should have 8 spaces in rank 1
            var rank1Spaces = await _chessGameBoardSpaceClient.GetByStateProperties(
                    chessGame.Id,
                    new Dictionary<string, string>() { { "rank", "1" } }
                    );
            Assert.Equal(8, rank1Spaces.Count());

            //chessboard should have 8 spaces in rank 8
            var rank8Spaces = await _chessGameBoardSpaceClient.GetByStateProperties(
                    chessGame.Id,
                    new Dictionary<string, string>() { { "rank", "8" } }
                    );
            Assert.Equal(8, rank1Spaces.Count());

            //chessboard should have 8 spaces in file a
            var fileASpaces = await _chessGameBoardSpaceClient.GetByStateProperties(
                    chessGame.Id,
                    new Dictionary<string, string>() { { "file", "a" } }
                    );
            Assert.Equal(8, fileASpaces.Count());

            //chessboard should have 8 spaces in file h
            var fileHSpaces = await _chessGameBoardSpaceClient.GetByStateProperties(
                    chessGame.Id,
                    new Dictionary<string, string>() { { "file", "h" } }
                    );
            Assert.Equal(8, fileHSpaces.Count());

            //8h's southwest adjacent space should be 7g
            var space8h = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'h');
            var space7g = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'g');
            Assert.Equal(space7g.Id, await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection(space8h.Id, "southwest"));

            //8h's south adjacent space should be 7h
            var space7h = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'h');
            Assert.Equal(space7h.Id, await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection(space8h.Id, "south"));
            //8h's west adjacent space should be 8g
            var space8g = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'g');
            Assert.Equal(space8g.Id, await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection(space8h.Id, "west"));

            //1a's northeast adjacent space should be 2b
            var space1a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'a');
            var space2b = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'b');
            Assert.Equal(space2b.Id, await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection(space1a.Id, "northeast"));

            //1a's north adjacent space should be 2a
            var space2a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'a');
            Assert.Equal(space2a.Id, await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection(space1a.Id, "north"));

            //1a's east adjacent space should be 1b
            var space1b = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'b');
            Assert.Equal(space1b.Id, await _chessGameBoardSpaceClient.GetAdjacentSpaceIdByDirection(space1a.Id, "east"));

        }
    }
}
