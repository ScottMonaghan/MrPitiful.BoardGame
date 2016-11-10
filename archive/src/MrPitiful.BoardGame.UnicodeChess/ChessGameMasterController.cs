using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrPitiful.UnicodeChess
{
    [Route("api/[controller]")]
    public class ChessGameMasterController : Controller
    {
        //TO BE ABLE TO TEST: 
        //REPLACE WITH MOCKABLE INTERFACES
        //ALL CLIENT REQUESTS NEED FAILSAFES AND NEED TO RETURN RESPONSE (OTHERWISE HOW THE HECK WOULD YOU DEBUG?)
        private IChessGameClient _chessGameClient;
        private IChessGameBoardClient _chessGameBoardClient;
        private IChessGameBoardSpaceClient _chessGameBoardSpaceClient;
        private IChessGamePieceClient _chessGamePieceClient;
        //private string message = "";

        public ChessGameMasterController(
            IChessGameClient chessGameClient,
            IChessGameBoardClient chessGameBoardClient,
            IChessGameBoardSpaceClient chessGameBoardSpaceClient,
            IChessGamePieceClient chessGamePieceClient
        )
        {
            _chessGameClient = chessGameClient;
            _chessGameBoardClient = chessGameBoardClient;
            _chessGameBoardSpaceClient = chessGameBoardSpaceClient;
            _chessGamePieceClient = chessGamePieceClient;
        }

        #region Chessboard Creation Methods

        public async Task AddChessGameBoardToChessGame(Guid chessGameId, Guid chessGameBoardId)
        {
            await _chessGameClient.SetGameBoardId(chessGameId, chessGameBoardId);
            await _chessGameBoardClient.SetGameId(chessGameBoardId, chessGameId);
        }

        public async Task AddChessGameBoardSpaceToChessGameBoard(Guid chessGameId, Guid chessGameBoardSpaceId, Guid chessGameBoardId)
        {
            //add the chessGameBoardSpaceId to the chessGameBoard
            await _chessGameBoardClient.AddGameBoardSpaceIdToGameBoard(chessGameBoardSpaceId, chessGameBoardId);
            //add the chessGameBoardId to the chessGameBoardSpace
            await _chessGameBoardSpaceClient.SetGameBoardSpaceGameBoardId(chessGameBoardSpaceId, chessGameBoardId);
            //add the chessGameBoardSpaceId to the chessGame
            await _chessGameClient.AddGameBoardSpaceIdToGame(chessGameBoardSpaceId, chessGameId);
            //add the chessGameId to the chessGameBoardSpace
            await _chessGameBoardSpaceClient.SetGameBoardSpaceGameId(chessGameBoardSpaceId, chessGameId);
        }

        public async Task<Guid> CreateChessGameBoardSpace(Guid chessGameId, Guid chessGameBoardId, int rank, char file, string color)
        {
            //every chessboard space will have the following properies:
            //Rank: A number 1 - 8
            //File: A charactar a - h
            //Color: White OR Black

            //create the space
            ChessGameBoardSpace chessGameBoardSpace = await _chessGameBoardSpaceClient.Create();
            await _chessGameBoardSpaceClient.SetGameId(chessGameBoardSpace.Id, chessGameId);
            //create a task list to run all our independent client calls in parallel
            List<Task> Tasks = new List<Task>();

            //set the state properties
            //set rank
            await _chessGameBoardSpaceClient.SetStateProperty(chessGameBoardSpace.Id, "rank", rank.ToString());
            //set file
            await _chessGameBoardSpaceClient.SetStateProperty(chessGameBoardSpace.Id, "file", file.ToString());
            //set color
            await _chessGameBoardSpaceClient.SetStateProperty(chessGameBoardSpace.Id, "color", color);

            //add ChessBoardSpace to gameboard
            await AddChessGameBoardSpaceToChessGameBoard(chessGameId, chessGameBoardSpace.Id, chessGameBoardId);

            //rull all the independent client calls!
            //Task.WaitAll(Tasks.ToArray());
            return chessGameBoardSpace.Id;
        }

        public async Task CreateRecipricalAdjacentSpaces(Guid gameBoardSpaceId1, Guid gameBoardSpaceId2, string directionFrom1to2, string directionFrom2to1)
        {
            //await Task.Run(() =>
            //{
            //List<Task> Tasks = new List<Task>();
            await _chessGameBoardSpaceClient.AddAdjacentSpaceToGameBoardSpace(directionFrom1to2, gameBoardSpaceId2, gameBoardSpaceId1);
            await _chessGameBoardSpaceClient.AddAdjacentSpaceToGameBoardSpace(directionFrom2to1, gameBoardSpaceId1, gameBoardSpaceId2);
            //Task.WaitAll(Tasks.ToArray());
            //});
        }

        public async Task<ChessGameBoardSpace> GetSpaceByRankAndFile(Guid chessGameId, int rank, char file)
        {
            var response = await _chessGameBoardSpaceClient.GetByStateProperties(chessGameId,
                                new Dictionary<string, string>() {
                                {"rank", rank.ToString()},
                                {"file", file.ToString()}
                                }
                            );
            return response[0];
        }

        public async Task<Guid> CreateChessBoard(Guid chessGameId)
        {
            //create empty ChessGameBoard and add to game
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();
            await AddChessGameBoardToChessGame(chessGameId, chessGameBoard.Id);

            //List<Task> gameBoardSpaceAddTasks = new List<Task>();

            //add spaces to the board
            string lastRankStartingColor = "";
            string lastFileColor = "";
            string colorWhite = "white";
            string colorBlack = "black";


            //note: A1 is Black  
            for (int rank = 1; rank <= 8; rank++)
            {
                for (char file = 'a'; file <= 'h'; file++)
                {
                    //figure out the color
                    string color = "";
                    if (file == 'a')
                    {
                        //brand new rank: we start this rank with the opposite color of the last rank 
                        //unless it's rank 1, then we start with Black
                        if (rank == 1 || lastRankStartingColor == colorWhite) { color = colorBlack; }
                        else { color = colorWhite; }
                        lastRankStartingColor = color;
                    }
                    else if (lastFileColor == colorWhite) { color = colorBlack; }
                    else { color = colorWhite; }
                    lastFileColor = color;

                    //create the space
                    await CreateChessGameBoardSpace(chessGameId, chessGameBoard.Id, rank, file, color);
                }
            }
            //Task.WaitAll(gameBoardSpaceAddTasks.ToArray());

            //now connect adjacent spaces - we use cardinal directions because that simpler than diagonal-left-down, etc.

            //List<Task> AdjacentSpaceConnections = new List<Task>();
            for (int rank = 1; rank <= 8; rank++)
            {
                for (char file = 'a'; file <= 'h'; file++)
                {
                    //get the current Space
                    ChessGameBoardSpace currentSpace = await GetSpaceByRankAndFile(chessGameId, rank, file);
                    //unless it's the first rank connect the adjacent space south
                    if (rank > 1)
                    {
                        ChessGameBoardSpace spaceToSouth = await GetSpaceByRankAndFile(chessGameId, rank - 1, file);
                        await CreateRecipricalAdjacentSpaces(
                            currentSpace.Id,
                            spaceToSouth.Id,
                            "south",
                            "north"
                        );
                    }
                    //unless it's the first file connect the adjacent space west
                    if (file > 'a')
                    {
                        {
                            ChessGameBoardSpace spaceToWest = await GetSpaceByRankAndFile(chessGameId, rank, (char)(file - 1));
                            await CreateRecipricalAdjacentSpaces(
                                currentSpace.Id,
                                spaceToWest.Id,
                                "west",
                                "east"
                            );
                        }
                    }
                    //unless it's the first file or the first rank connect the adjacent space southwest
                    if (rank > 1 && file > 'a')
                    {
                        {
                            ChessGameBoardSpace spaceToSouthWest = await GetSpaceByRankAndFile(chessGameId, rank - 1, (char)(file - 1));
                            await CreateRecipricalAdjacentSpaces(
                                currentSpace.Id,
                                spaceToSouthWest.Id,
                                "southwest",
                                "northeast"
                            );
                        }
                    }
                    //unless it's the last file or the first rank connect the adjacent space southeast
                    if (file < 'h' && rank > 1)
                    {
                        {
                            ChessGameBoardSpace spaceToSouthEast = await GetSpaceByRankAndFile(chessGameId, rank - 1, (char)(file + 1));
                            await CreateRecipricalAdjacentSpaces(
                                currentSpace.Id,
                                spaceToSouthEast.Id,
                                "southeast",
                                "northwest"
                            );
                        }
                    }
                }
            }
            //Task.WaitAll(AdjacentSpaceConnections.ToArray());
            return chessGameBoard.Id;
        }

        #endregion

        #region Chess Piece Creation Methods
        public async Task AddChessGamePieceToChessGameBoardSpace(Guid chessGamePieceId, Guid chessGameBoardSpaceId, Guid chessGameBoardId, Guid chessGameId)
        {
            //add gameboardspace to piece
            await _chessGamePieceClient.SetGamePieceGameBoardSpaceId(chessGamePieceId, chessGameBoardSpaceId);
            //add piece to gameboardspace
            await _chessGameBoardSpaceClient.AddGamePieceIdToGameBoardSpace(chessGamePieceId, chessGameBoardSpaceId);
            //add gameboard to piece
            await _chessGamePieceClient.SetGamePieceGameBoardId(chessGamePieceId, chessGameBoardId);
            //add piece to gameboard
            //--not implemented
            //add game to piece
            await _chessGamePieceClient.SetGameId(chessGamePieceId, chessGameId);
            //add piece to game
            await _chessGameClient.AddGamePieceIdToGame(chessGamePieceId, chessGameId);
        }

        public async Task<Guid> CreateAndPlacePiece(Guid chessGameId, string pieceName, string pieceSymbol, string pieceColor, int spaceRank, char spaceFile)
        {
            ChessGamePiece newPiece = await _chessGamePieceClient.Create();
            //set name, symbol, & color
            await _chessGamePieceClient.SetStateProperty(newPiece.Id, "name", pieceName);
            await _chessGamePieceClient.SetStateProperty(newPiece.Id, "symbol", pieceSymbol);
            await _chessGamePieceClient.SetStateProperty(newPiece.Id, "color", pieceColor);

            //get the space by rank and file
            ChessGameBoardSpace chessBoardSpace = await GetSpaceByRankAndFile(chessGameId, spaceRank, spaceFile);
            await AddChessGamePieceToChessGameBoardSpace(
                newPiece.Id,
                chessBoardSpace.Id,
                chessBoardSpace.GameBoardId,
                chessGameId);

            return newPiece.Id;
        }

        public async Task CreateAndPlacePieces(Guid chessGameId)
        {
            //Each player controls sixteen pieces:

            //Piece: King
            //Number: 1
            //Symbols: ♔♚

            //Piece: Queen
            //Number:2 
            //Symbols: ♕♛

            //Piece: Bishop
            //Number: 2
            //Symbols: ♗♝

            //Piece: Knight
            //Number: 2
            //Symbols: ♘♞

            //Piece: Rook
            //Number: 2
            //Symbols: ♖♜

            //Piece: Pawn
            //Number: 8
            //Symbols: ♙♟

            //At the beginning of the game, the pieces are arranged as shown in the diagram: https://i.imgur.com/VmWQcXn.png
            //  _a＿b＿c＿d＿e＿f＿g＿h_  
            // 8|♖|♘|♗|♕|♔|♗|♘|♖|
            // 7|♙|♙|♙|♙|♙|♙|♙|♙|
            // 6|＿|＿|＿|＿|＿|＿|＿|＿|
            // 5|＿|＿|＿|＿|＿|＿|＿|＿|
            // 4|＿|＿|＿|＿|＿|＿|＿|＿|
            // 3|＿|＿|＿|＿|＿|＿|＿|＿|
            // 2|♟|♟|♟|♟|♟|♟|♟|♟|
            // 1|♜|♞|♝|♛|♚|♝|♞|♜|

            //for each side one king, one queen, two rooks, two bishops, two knights, and eight pawns.

            //The pieces are placed, one on a square, as follows:
            //The rooks are placed on the outside corners, right and left edge.
            await CreateAndPlacePiece(chessGameId, "rook", "♜", "black", 1, 'a');
            await CreateAndPlacePiece(chessGameId, "rook", "♜", "black", 1, 'h');
            await CreateAndPlacePiece(chessGameId, "rook", "♖", "white", 8, 'a');
            await CreateAndPlacePiece(chessGameId, "rook", "♖", "white", 8, 'h');
            //The knights are placed immediately inside of the rooks.
            await CreateAndPlacePiece(chessGameId, "knight", "♞", "black", 1, 'b');
            await CreateAndPlacePiece(chessGameId, "knight", "♞", "black", 1, 'g');
            await CreateAndPlacePiece(chessGameId, "knight", "♘", "white", 8, 'b');
            await CreateAndPlacePiece(chessGameId, "knight", "♘", "white", 8, 'g');
            //The bishops are placed immediately inside of the knights.
            await CreateAndPlacePiece(chessGameId, "bishop", "♝", "black", 1, 'c');
            await CreateAndPlacePiece(chessGameId, "bishop", "♝", "black", 1, 'f');
            await CreateAndPlacePiece(chessGameId, "bishop", "♗", "white", 8, 'c');
            await CreateAndPlacePiece(chessGameId, "bishop", "♗", "white", 8, 'f');
            //The queen is placed on the central square of the same color of that of the player: white queen on the white square and black queen on the black square.
            await CreateAndPlacePiece(chessGameId, "queen", "♛", "black", 1, 'd');
            await CreateAndPlacePiece(chessGameId, "queen", "♕", "white", 8, 'd');
            //The king takes the vacant spot next to the queen.
            await CreateAndPlacePiece(chessGameId, "king", "♚", "black", 1, 'e');
            await CreateAndPlacePiece(chessGameId, "king", "♔", "white", 8, 'e');
            //The pawns are placed one square in front of all of the other pieces.
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'a');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'b');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'c');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'd');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'e');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'f');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'g');
            await CreateAndPlacePiece(chessGameId, "pawn", "♟", "black", 2, 'h');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'a');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'b');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'c');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'd');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'e');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'f');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'g');
            await CreateAndPlacePiece(chessGameId, "pawn", "♙", "white", 7, 'h');

            //Popular mnemonics used to remember the setup are "queen on her own color" and "white on right".The latter refers to setting up the board so that the square closest to each player's right is white (Schiller 2003:16–17).
            //CreateAndPlacePieces
        }

        #endregion

        [HttpGet("SetGameMessage/{gameId}/{message}")]
        public async Task<IActionResult> SetGameMessage(Guid gameId, string message)
        {
            await _chessGameClient.SetStateProperty(gameId, "message", message);
            return new NoContentResult();
        }

        [HttpGet("GetGameMessage/{gameId}")]
        public async Task<IActionResult> GetGameMessage(Guid gameId)
        {
            return Content(await _chessGameClient.GetStateProperty(gameId, "message"));
        }

        [HttpGet("ClearGameMessage/{gameId}")]
        public async Task<IActionResult> ClearGameMessage(Guid gameId)
        {
            await _chessGameClient.ClearStateProperty(gameId, "message");
            return new NoContentResult();
        }

        [HttpGet("InitialSetup/{chessGameId}")]
        public async Task<IActionResult> InitialSetup(Guid chessGameId)
        {
            //Initial setup - from https://en.wikipedia.org/wiki/Rules_of_chess#Initial_setup (9/21/2016)

            //Chess is played on a chessboard, 
            //a square board divided into 64 squares(eight - by - eight) of alternating color, 
            //which is similar to that used in draughts(checkers)(FIDE 2008).

            //No matter what the actual colors of the board, the lighter - colored squares are called "light" or "white", 
            //and the darker - colored squares are called "dark" or "black".

            //Sixteen "white" and sixteen "black" pieces are placed on the board at the beginning of the game. 
            //The board is placed so that a white square is in each player's near-right corner. 

            //Horizontal rows are called ranks and vertical rows are called files.

            //Each player controls sixteen pieces:

            //Piece: King
            //Number: 1
            //Symbols: ♔♚

            //Piece: Queen
            //Number:2 
            //Symbols: ♕♛

            //Piece: Bishop
            //Number: 2
            //Symbols: ♗♝

            //Piece: Knight
            //Number: 2
            //Symbols: ♘♞

            //Piece: Pawn
            //Number: 8
            //Symbols: ♙♟

            //At the beginning of the game, the pieces are arranged as shown in the diagram: https://i.imgur.com/VmWQcXn.png
            //  _a＿b＿c＿d＿e＿f＿g＿h_  
            // 8|♖|♘|♗|♕|♔|♗|♘|♖|
            // 7|♙|♙|♙|♙|♙|♙|♙|♙|
            // 6|＿|＿|＿|＿|＿|＿|＿|＿|
            // 5|＿|＿|＿|＿|＿|＿|＿|＿|
            // 4|＿|＿|＿|＿|＿|＿|＿|＿|
            // 3|＿|＿|＿|＿|＿|＿|＿|＿|
            // 2|♟|♟|♟|♟|♟|♟|♟|♟|
            // 1|♜|♞|♝|♛|♚|♝|♞|♜|

            //for each side one king, one queen, two rooks, two bishops, two knights, and eight pawns.

            //The pieces are placed, one on a square, as follows:
            //The rooks are placed on the outside corners, right and left edge.
            //The knights are placed immediately inside of the rooks.
            //The bishops are placed immediately inside of the knights.
            //The queen is placed on the central square of the same color of that of the player: white queen on the white square and black queen on the black square.
            //The king takes the vacant spot next to the queen.
            //The pawns are placed one square in front of all of the other pieces.
            //Popular mnemonics used to remember the setup are "queen on her own color" and "white on right".The latter refers to setting up the board so that the square closest to each player's right is white (Schiller 2003:16–17).

            await CreateChessBoard(chessGameId);
            await CreateAndPlacePieces(chessGameId);

            //GamePlay
            //The player controlling the white pieces is named "white";
            //The player controlling the black pieces is named "black".
            //White moves first, then players alternate moves.
            await _chessGameClient.SetStateProperty(chessGameId, "nextplayer", "white");
            await SetGameMessage(chessGameId, "New game set up!\n");


            return new NoContentResult();
        }

        public async Task<Boolean> MoveIsValid(Guid chessGamePieceId, Guid chessGameBoardSpaceId)
        {
            //will be adding rules.  For now, all moves are valid!
            return true;
        }

        public async Task MoveGamePieceToGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            //get old space
            var oldGameBoardSpaceId = await _chessGamePieceClient.GetGamePieceGameBoardSpaceId(gamePieceId);
            //remove piece from old space
            await _chessGameBoardSpaceClient.RemoveGamePieceIdFromGameBoardSpace(gamePieceId, oldGameBoardSpaceId);
            //add piece to new space
            await _chessGameBoardSpaceClient.AddGamePieceIdToGameBoardSpace(gamePieceId, gameBoardSpaceId);
            //update piece's spaceId
            await _chessGamePieceClient.SetGamePieceGameBoardSpaceId(gamePieceId, gameBoardSpaceId);
        }

        public async Task Capture(Guid chessGameId, Guid capturingPieceId, Guid capturedPieceId)
        {
            //eventually we want to report something here, but for now just remove capturedPiece from game.
            //!!NEED TO ADD ABILITY TO DELETE GAME OBJECTS

            string capturingPieceColor = await _chessGamePieceClient.GetStateProperty(capturingPieceId, "color");
            string capturedPieceColor = await _chessGamePieceClient.GetStateProperty(capturedPieceId, "color");
            string capturingPieceName = await _chessGamePieceClient.GetStateProperty(capturingPieceId, "name");
            string capturedPieceName = await _chessGamePieceClient.GetStateProperty(capturedPieceId, "name");
            await SetGameMessage(chessGameId,
                ((ContentResult)(await GetGameMessage(chessGameId))).Content +
                string.Format("{0} {1} captures {2} {3}!\n", capturingPieceColor, capturingPieceName, capturedPieceColor, capturedPieceName)
                );

            //get captured piece
            var capturedPiece = await _chessGamePieceClient.Get(capturedPieceId);

            //remove captured piece from gameBoardSpace
            await _chessGameBoardSpaceClient.RemoveGamePieceIdFromGameBoardSpace(capturedPiece.Id, capturedPiece.GameBoardSpaceId);
            //remove gameBoardSpaceId from capturedPiece
            await _chessGamePieceClient.SetGamePieceGameBoardSpaceId(capturedPiece.Id, Guid.Empty);

            //remove captured peice from gameBoard
            //NOT IMPLEMENTED
            //remove gameBoardId from capturedPiece
            await _chessGamePieceClient.SetGamePieceGameBoardId(capturedPiece.Id, Guid.Empty);

            //remove captured piece from game
            await _chessGameClient.RemoveGamePieceIdFromGame(capturedPiece.Id, capturedPiece.GameId);
            //remove gameId from capturedPiece
            await _chessGamePieceClient.SetGamePieceGameId(capturedPiece.Id, Guid.Empty);

            //DELETE CAPTURED PIECE
        }

        [HttpGet("Move/{chessGameId}/{moveToFile}/{moveToRank}/{moveFromFile}/{moveFromRank}")]
        public async Task<IActionResult> Move(Guid chessGameId, char moveToFile, int moveToRank, char moveFromFile, int moveFromRank)
        {
            //The player controlling the white pieces is named "White"; 
            //The player controlling the black pieces is named "Black".
            //White moves first, then players alternate moves.
            //Making a move is required; it is not legal to skip a move, even when having to move is detrimental.
            //Play continues until a king is checkmated, a player resigns, or a draw is declared, as explained below.
            //In addition, if the game is being played under a time control players who exceed their time limit lose the game.

            //Movement
            //Basic moves
            //Except for any move of the knight and castling, pieces cannot jump over other pieces.
            //A piece is captured (or taken) when an attacking enemy piece replaces it on its square (en passant is the only exception).
            //The captured piece is thereby permanently removed from the game.[1] The king can be put in check but cannot be captured(see below).

            //The king moves exactly one square horizontally, vertically, or diagonally.
            //A special move with the king known as castling is allowed only once per player, per game(see below).

            //A rook moves any number of vacant squares in a horizontal or vertical direction.It also is moved when castling.

            //A bishop moves any number of vacant squares in any diagonal direction.

            //The queen moves any number of vacant squares in a horizontal, vertical, or diagonal direction.
            //A knight moves to the nearest square not on the same rank, file, or diagonal. 
            //(This can be thought of as moving two squares horizontally then one square vertically, or moving one square horizontally then two squares vertically—i.e. in an "L" pattern.) The knight is not blocked by other pieces: it jumps to the new location.

            //Pawns have the most complex rules of movement:
            //  A pawn moves straight forward one square, if that square is vacant.
            //  If it has not yet moved, a pawn also has the option of moving two squares straight forward, provided both squares are vacant. 
            //  Pawns cannot move backwards.
            //  Pawns are the only pieces that capture differently from how they move.
            //  A pawn can capture an enemy piece on either of the two squares diagonally in front of the pawn (but cannot move to those squares if they are vacant).
            //  The pawn is also involved in the two special moves en passant and promotion (Schiller 2003:17–19).

            // get two spaces
            var spaceMoveTo = await GetSpaceByRankAndFile(chessGameId, moveToRank, moveToFile);
            var spaceMoveFrom = await GetSpaceByRankAndFile(chessGameId, moveFromRank, moveFromFile);
            var chessGamePieceId = (await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(spaceMoveFrom.Id))[0];
            //If move is valid
            if (await MoveIsValid(chessGamePieceId, spaceMoveTo.Id))
            {
                string pieceColor = await _chessGamePieceClient.GetStateProperty(chessGamePieceId, "color");
                string pieceName = await _chessGamePieceClient.GetStateProperty(chessGamePieceId, "name");
                await SetGameMessage(chessGameId,
                    ((ContentResult)(await GetGameMessage(chessGameId))).Content +
                    String.Format("{0} {1} moves from {2}{3} to {4}{5}\n", pieceColor, pieceName, moveFromFile, moveFromRank, moveToFile, moveToRank)
                    );
                //Capture if space is occupied
                var piecesOnSpaceMoveTo = await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(spaceMoveTo.Id);
                if (piecesOnSpaceMoveTo.Count > 0)
                {
                    await Capture(chessGameId,chessGamePieceId, piecesOnSpaceMoveTo[0]);
                }
                //Move to Space
                await MoveGamePieceToGameBoardSpace(chessGamePieceId, spaceMoveTo.Id);
            }

            return new NoContentResult();
        }

        [HttpGet("RenderChessBoardAsText/{chessGameId}")]
        public async Task<string> RenderChessBoardAsText(Guid chessGameId)
        {
            //Example after setup
            //  _a＿b＿c＿d＿e＿f＿g＿h_  
            // 8|♖|♘|♗|♕|♔|♗|♘|♖|
            // 7|♙|♙|♙|♙|♙|♙|♙|♙|
            // 6|＿|＿|＿|＿|＿|＿|＿|＿|
            // 5|＿|＿|＿|＿|＿|＿|＿|＿|
            // 4|＿|＿|＿|＿|＿|＿|＿|＿|
            // 3|＿|＿|＿|＿|＿|＿|＿|＿|
            // 2|♟|♟|♟|♟|♟|♟|♟|♟|
            // 1|♜|♞|♝|♛|♚|♝|♞|♜|

            string chessBoardString = "  _a＿b＿c＿d＿e＿f＿g＿h_";
            for (int rank = 8; rank >= 1; rank--)
            {
                chessBoardString += String.Format("\n{0}|", rank);
                for (char file = 'a'; file <='h'; file++)
                {
                    string symbolToDisplay = "＿";
                    var currentSpace = await GetSpaceByRankAndFile(chessGameId, rank, file);
                    var occupyingPieces = await _chessGameBoardSpaceClient.GetGameBoardSpaceGamePieceIds(currentSpace.Id);
                    if (occupyingPieces.Count > 0)
                    {
                        symbolToDisplay = await _chessGamePieceClient.GetStateProperty(occupyingPieces[0], "symbol");
                    }
                    chessBoardString += String.Format("{0}|", symbolToDisplay);    
                }
            }
            return chessBoardString;
        }

        [HttpGet("StartGame")]
        public async Task<IActionResult> StartGame()
        {
            var createdGame = await _chessGameClient.Create();
            //await ClearGameMessage(createdGame.Id);
            await InitialSetup(createdGame.Id);
            return new ObjectResult(createdGame.Id);
        }

    }

}