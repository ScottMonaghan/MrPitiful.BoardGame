using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc;
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

        [Fact]
        public async void AddChessGamePieceToChessGameBoardSpace()
        {
            //Arrange
            //create a new game
            ChessGame chessGame = await _chessGameClient.Create();
            //Create a new gameboard
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();
            //Create gameBoardSpace
            ChessGameBoardSpace chessGameBoardSpace = await _chessGameBoardSpaceClient.Create();
            //Create gamePiece
            ChessGamePiece chessGamePiece = await _chessGamePieceClient.Create();

            //Act
            //AddChessGamePieceToChessGameBoardSpace
            await _ChessGameMasterController
                .AddChessGamePieceToChessGameBoardSpace(
                    chessGamePiece.Id,
                    chessGameBoardSpace.Id,
                    chessGameBoard.Id,
                    chessGame.Id
                );

            //chessGamePiece.GameBoardSpaceId should be chessGameBoardSpace.Id
            Assert.Equal(chessGameBoardSpace.Id,
                await _chessGamePieceClient.GetGamePieceGameBoardSpaceId(chessGamePiece.Id)
                );
            //chessGameBoardSpace should contain chessGamePieceId
            Assert.True(
                await _chessGameBoardSpaceClient.GameBoardSpaceContainsGamePieceId(
                        chessGameBoardSpace.Id,
                        chessGamePiece.Id
                    )
                );
            //chessGamePiece.GameBoardId should be chessGameBoard.Id
            Assert.Equal(chessGameBoard.Id,
                 await _chessGamePieceClient.GetGamePieceGameBoardId(chessGamePiece.Id)
                );
            //chessGamePiece.GameId should be chessGame.Id
            Assert.Equal(chessGame.Id,
                 await _chessGamePieceClient.GetGamePieceGameId(chessGamePiece.Id)
                );
            //chessGame should contain GamePiece.Id
            Assert.True(
                await _chessGameClient.GameContainsGamePieceId(
                        chessGame.Id,
                        chessGamePiece.Id
                    )
                );
        }

        [Fact]
        public async void CreateAndPlacePiece()
        {
            //Arrange
            //create game
            ChessGame chessGame = await _chessGameClient.Create();
            //create chessboard
            Guid chessGameBoardId = await _ChessGameMasterController.CreateChessBoard(chessGame.Id);
            //get space 1a
            ChessGameBoardSpace space1a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'a');
            
            //Act
            Guid newPieceId = await _ChessGameMasterController.CreateAndPlacePiece(chessGame.Id, "rook", "♜", "black", 1, 'a');

            //Assert
            //piece's name is "rook"
            Assert.Equal("rook",
                await _chessGamePieceClient.GetStateProperty(newPieceId, "name")
                );
            //piece's color is "black"
            Assert.Equal("black",
                await _chessGamePieceClient.GetStateProperty(newPieceId, "color")
                );
            //piece's symbol is "♜"
            Assert.Equal("♜",
                await _chessGamePieceClient.GetStateProperty(newPieceId, "symbol")
                );
            //Space 1a contains piece
            Assert.True(await _chessGameBoardSpaceClient.GameBoardSpaceContainsGamePieceId(space1a.Id, newPieceId));

        }

        [Fact]
        public async void CreateAndPlacePieces()
        {
            //Arrange
            //create game
            ChessGame chessGame = await _chessGameClient.Create();
            //create chessboard
            Guid chessGameBoardId = await _ChessGameMasterController.CreateChessBoard(chessGame.Id);

            //Act 
            await _ChessGameMasterController.CreateAndPlacePieces(chessGame.Id);

            //Assert
            //1a is a black rook with the symbol ♜
            var space1a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'a');
            var piece1aId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1a.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1aId, "color"));
            Assert.Equal("rook", await _chessGamePieceClient.GetStateProperty(piece1aId, "name"));
            Assert.Equal("♜", await _chessGamePieceClient.GetStateProperty(piece1aId, "symbol"));
            //1b is a black knight with the symbol ♞
            var space1b = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'b');
            var piece1bId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1b.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1bId, "color"));
            Assert.Equal("knight", await _chessGamePieceClient.GetStateProperty(piece1bId, "name"));
            Assert.Equal("♞", await _chessGamePieceClient.GetStateProperty(piece1bId, "symbol"));
            //1c is a black bishop with the symbol ♝
            var space1c = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'c');
            var piece1cId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1c.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1cId, "color"));
            Assert.Equal("bishop", await _chessGamePieceClient.GetStateProperty(piece1cId, "name"));
            Assert.Equal("♝", await _chessGamePieceClient.GetStateProperty(piece1cId, "symbol"));
            //1d is the black queen with the symbol ♛
            var space1d = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'd');
            var piece1dId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1d.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1dId, "color"));
            Assert.Equal("queen", await _chessGamePieceClient.GetStateProperty(piece1dId, "name"));
            Assert.Equal("♛", await _chessGamePieceClient.GetStateProperty(piece1dId, "symbol"));
            //1e is the black king with the symbol ♚
            var space1e = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'e');
            var piece1eId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1e.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1eId, "color"));
            Assert.Equal("king", await _chessGamePieceClient.GetStateProperty(piece1eId, "name"));
            Assert.Equal("♚", await _chessGamePieceClient.GetStateProperty(piece1eId, "symbol"));
            //1f is a black bishop with the symbol ♝
            var space1f = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'f');
            var piece1fId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1f.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1fId, "color"));
            Assert.Equal("bishop", await _chessGamePieceClient.GetStateProperty(piece1fId, "name"));
            Assert.Equal("♝", await _chessGamePieceClient.GetStateProperty(piece1fId, "symbol"));
            //1g is a black knight with the symbol ♞
            var space1g = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'g');
            var piece1gId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1g.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1gId, "color"));
            Assert.Equal("knight", await _chessGamePieceClient.GetStateProperty(piece1gId, "name"));
            Assert.Equal("♞", await _chessGamePieceClient.GetStateProperty(piece1gId, "symbol"));
            //1h is a black rook with the symbol ♜
            var space1h = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 1, 'h');
            var piece1hId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space1h.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece1hId, "color"));
            Assert.Equal("rook", await _chessGamePieceClient.GetStateProperty(piece1hId, "name"));
            Assert.Equal("♜", await _chessGamePieceClient.GetStateProperty(piece1hId, "symbol"));

            //8a is a white rook with the symbol ♖
            var space8a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'a');
            var piece8aId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8a.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8aId, "color"));
            Assert.Equal("rook", await _chessGamePieceClient.GetStateProperty(piece8aId, "name"));
            Assert.Equal("♖", await _chessGamePieceClient.GetStateProperty(piece8aId, "symbol"));
            //8b is a white knight with the symbol ♘
            var space8b = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'b');
            var piece8bId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8b.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8bId, "color"));
            Assert.Equal("knight", await _chessGamePieceClient.GetStateProperty(piece8bId, "name"));
            Assert.Equal("♘", await _chessGamePieceClient.GetStateProperty(piece8bId, "symbol"));
            //8c is a white bishop with the symbol ♗
            var space8c = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'c');
            var piece8cId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8c.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8cId, "color"));
            Assert.Equal("bishop", await _chessGamePieceClient.GetStateProperty(piece8cId, "name"));
            Assert.Equal("♗", await _chessGamePieceClient.GetStateProperty(piece8cId, "symbol"));
            //8d is is the white queen with the symbol ♕
            var space8d = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'd');
            var piece8dId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8d.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8dId, "color"));
            Assert.Equal("queen", await _chessGamePieceClient.GetStateProperty(piece8dId, "name"));
            Assert.Equal("♕", await _chessGamePieceClient.GetStateProperty(piece8dId, "symbol"));
            //8e is the white king with the symbol ♔
            var space8e = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'e');
            var piece8eId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8e.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8eId, "color"));
            Assert.Equal("king", await _chessGamePieceClient.GetStateProperty(piece8eId, "name"));
            Assert.Equal("♔", await _chessGamePieceClient.GetStateProperty(piece8eId, "symbol"));
            //8f is a white bishop with the symbol ♗
            var space8f = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'f');
            var piece8fId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8f.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8fId, "color"));
            Assert.Equal("bishop", await _chessGamePieceClient.GetStateProperty(piece8fId, "name"));
            Assert.Equal("♗", await _chessGamePieceClient.GetStateProperty(piece8fId, "symbol"));
            //8g is a white knight with the symbol ♘
            var space8g = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'g');
            var piece8gId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8g.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8gId, "color"));
            Assert.Equal("knight", await _chessGamePieceClient.GetStateProperty(piece8gId, "name"));
            Assert.Equal("♘", await _chessGamePieceClient.GetStateProperty(piece8gId, "symbol"));
            //8h is  a white rook with the symbol ♖
            var space8h = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 8, 'h');
            var piece8hId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space8h.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece8hId, "color"));
            Assert.Equal("rook", await _chessGamePieceClient.GetStateProperty(piece8hId, "name"));
            Assert.Equal("♖", await _chessGamePieceClient.GetStateProperty(piece8hId, "symbol"));

            //2a is a black pawn with the symbol ♟
            var space2a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'a');
            var piece2aId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2a.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2aId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2aId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2aId, "symbol"));
            //2b is a black pawn with the symbol ♟
            var space2b = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'b');
            var piece2bId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2b.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2bId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2bId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2bId, "symbol"));
            //2c is a black pawn with the symbol ♟
            var space2c = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'c');
            var piece2cId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2c.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2cId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2cId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2cId, "symbol"));
            //2d is a black pawn with the symbol ♟
            var space2d = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'd');
            var piece2dId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2d.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2dId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2dId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2dId, "symbol"));
            //2e is a black pawn with the symbol ♟
            var space2e = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'e');
            var piece2eId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2e.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2eId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2eId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2eId, "symbol"));
            //2f is a black pawn with the symbol ♟
            var space2f = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'f');
            var piece2fId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2f.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2fId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2fId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2fId, "symbol"));
            //2g is a black pawn with the symbol ♟
            var space2g = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'g');
            var piece2gId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2g.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2gId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2gId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2gId, "symbol"));
            //2h is a black pawn with the symbol ♟
            var space2h = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 2, 'h');
            var piece2hId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space2h.Id))[0];
            Assert.Equal("black", await _chessGamePieceClient.GetStateProperty(piece2hId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece2hId, "name"));
            Assert.Equal("♟", await _chessGamePieceClient.GetStateProperty(piece2hId, "symbol"));

            //7a is a white pawn with the symbol ♙
            var space7a = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'a');
            var piece7aId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7a.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7aId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7aId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7aId, "symbol"));
            //7b is a white pawn with the symbol ♙
            var space7b = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'b');
            var piece7bId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7b.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7bId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7bId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7bId, "symbol"));
            //7c is a white pawn with the symbol ♙
            var space7c = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'c');
            var piece7cId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7c.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7cId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7cId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7cId, "symbol"));
            //7d is a white pawn with the symbol ♙
            var space7d = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'd');
            var piece7dId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7d.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7dId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7dId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7dId, "symbol"));
            //7e is a white pawn with the symbol ♙
            var space7e = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'e');
            var piece7eId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7e.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7eId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7eId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7eId, "symbol"));
            //7f is a white pawn with the symbol ♙
            var space7f = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'f');
            var piece7fId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7f.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7fId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7fId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7fId, "symbol"));
            //7g is a white pawn with the symbol ♙
            var space7g = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'g');
            var piece7gId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7g.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7gId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7gId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7gId, "symbol"));
            //7h is a white pawn with the symbol ♙
            var space7h = await _ChessGameMasterController.GetSpaceByRankAndFile(chessGame.Id, 7, 'h');
            var piece7hId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(space7h.Id))[0];
            Assert.Equal("white", await _chessGamePieceClient.GetStateProperty(piece7hId, "color"));
            Assert.Equal("pawn", await _chessGamePieceClient.GetStateProperty(piece7hId, "name"));
            Assert.Equal("♙", await _chessGamePieceClient.GetStateProperty(piece7hId, "symbol"));

        }

        [Fact]
        public async void RenderChessBoardAsText()
        {
            // Arrange
            //create game
            ChessGame chessGame = await _chessGameClient.Create();
            //create chessboard
            Guid chessGameBoardId = await _ChessGameMasterController.CreateChessBoard(chessGame.Id);
            await _ChessGameMasterController.CreateAndPlacePieces(chessGame.Id);
            string expectedString =
               "  _a＿b＿c＿d＿e＿f＿g＿h_"
            + "\n8|♖|♘|♗|♕|♔|♗|♘|♖|"
            + "\n7|♙|♙|♙|♙|♙|♙|♙|♙|"
            + "\n6|＿|＿|＿|＿|＿|＿|＿|＿|"
            + "\n5|＿|＿|＿|＿|＿|＿|＿|＿|"
            + "\n4|＿|＿|＿|＿|＿|＿|＿|＿|"
            + "\n3|＿|＿|＿|＿|＿|＿|＿|＿|"
            + "\n2|♟|♟|♟|♟|♟|♟|♟|♟|"
            + "\n1|♜|♞|♝|♛|♚|♝|♞|♜|"
            ;

            //Act 
            String chessBoardAsText = await _ChessGameMasterController.RenderChessBoardAsText(chessGame.Id);

            //Assert
            Assert.Equal(expectedString, chessBoardAsText);
        }

        [Fact]
        public async void SetGetAndClearGameMessage()
        {
            //arrange
            //create game
            ChessGame chessGame = await _chessGameClient.Create();
            string testMessage = "test message line 1\ntest message line 2";

            //act
            await _ChessGameMasterController.SetGameMessage(chessGame.Id, testMessage);

            //assert
            Assert.Equal(testMessage, ((ContentResult)(await _ChessGameMasterController.GetGameMessage(chessGame.Id))).Content);

            //act
            await _ChessGameMasterController.ClearGameMessage(chessGame.Id);

            //assert
            Assert.Equal("", ((ContentResult)(await _ChessGameMasterController.GetGameMessage(chessGame.Id))).Content);

        }

        [Fact]
        public async void ReturnMessageOnInitialSetup()
        {
            //arrange
            var createdGame = await _chessGameClient.Create();

            //act
            await _ChessGameMasterController.InitialSetup(createdGame.Id);

            //assert
            Assert.True(
                (
                    (ContentResult)
                    (await _ChessGameMasterController.GetGameMessage(createdGame.Id))
                ).Content.Contains("New game")
            );
        }

        [Fact]
        public async void ReturnMessageOnMove()
        {
            //arrange
            var createdGame = await _chessGameClient.Create();
            await _ChessGameMasterController.InitialSetup(createdGame.Id);

            //act
            await _ChessGameMasterController.Move(createdGame.Id, 'd', 4, 'd', 2);

            //assert
            Assert.True(
                (
                    (ContentResult)
                    (await _ChessGameMasterController.GetGameMessage(createdGame.Id))
                ).Content.Contains("moves from d2 to d4")
            );
        }

    }
}
