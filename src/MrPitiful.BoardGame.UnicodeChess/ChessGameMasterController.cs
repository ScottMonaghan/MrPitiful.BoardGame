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
        private ChessGameClient _chessGameClient;
        private ChessGameBoardClient _chessGameBoardClient;
        private ChessGameBoardSpaceClient _chessGameBoardSpaceClient;
        private ChessGamePiece _chessGamePieceClient;


        private async Task AddChessGameBoardToChessGame(Guid chessGameId, Guid chessGameBoardId)
        {
            await Task.Run(() =>
            { 
                //create a task list to run all our independent client calls in parallel
                List<Task> Tasks = new List<Task>();

                //add the chessGameBoardSpaceId to the chessGameBoard
                Tasks.Add(_chessGameClient.SetGameBoardId(chessGameId, chessGameBoardId));
                //add the chessGameBoardId to the chessGameBoardSpace
                Tasks.Add(_chessGameBoardClient.SetGameBoardGameId(chessGameBoardId, chessGameId));

                //rull all the independent client calls!
                Task.WaitAll(Tasks.ToArray());
            });
        }

        private async Task AddChessGameBoardSpaceToChessGameBoard(Guid chessGameId, Guid chessGameBoardSpaceId, Guid chessGameBoardId)
        {
            await Task.Run(() =>
            {
                //create a task list to run all our independent client calls in parallel
                List<Task> Tasks = new List<Task>();

                //add the chessGameBoardSpaceId to the chessGameBoard
                Tasks.Add(_chessGameBoardClient.AddGameBoardSpaceIdToGameBoard(chessGameBoardSpaceId, chessGameBoardId));
                //add the chessGameBoardId to the chessGameBoardSpace
                Tasks.Add(_chessGameBoardSpaceClient.SetGameBoardSpaceGameBoardId(chessGameBoardSpaceId, chessGameBoardId));
                //add the chessGameBoardSpaceId to the chessGame
                Tasks.Add(_chessGameClient.AddGameBoardSpaceIdToGame(chessGameBoardSpaceId, chessGameId));
                //add the chessGameId to the chessGameBoardSpace
                Tasks.Add(_chessGameBoardSpaceClient.SetGameBoardSpaceGameId(chessGameBoardSpaceId, chessGameId));

                //rull all the independent client calls!
                Task.WaitAll(Tasks.ToArray());
            });
        }

        private async Task<Guid> CreateChessGameBoardSpace(Guid chessGameId, Guid chessGameBoardId, int rank, char file, string color)
        {
            //every chessboard space will have the following properies:
            //Rank: A number 1 - 8
            //File: A charactar a - h
            //Color: White OR Black

            //create the space
            ChessGameBoardSpace chessGameBoardSpace = await _chessGameBoardSpaceClient.Create();

            //create a task list to run all our independent client calls in parallel
            List<Task> Tasks = new List<Task>();
            
            //set the state properties
            //set rank
            Tasks.Add(_chessGameBoardClient.SetStateProperty(chessGameBoardSpace.Id, "rank", rank.ToString()));
            //set file
            Tasks.Add(_chessGameBoardClient.SetStateProperty(chessGameBoardSpace.Id, "file", file.ToString()));
            //set color
            Tasks.Add(_chessGameBoardClient.SetStateProperty(chessGameBoardSpace.Id, "color", color));

            //add ChessBoardSpace to gameboard
            Tasks.Add(AddChessGameBoardSpaceToChessGameBoard(chessGameId, chessGameBoardSpace.Id, chessGameBoardId));

            //rull all the independent client calls!
            Task.WaitAll(Tasks.ToArray());
            return chessGameBoardSpace.Id;
        }

        private async Task CreateChessBoard(Guid chessGameId)
        {
            //create empty ChessGameBoard and add to game
            ChessGameBoard chessGameBoard = await _chessGameBoardClient.Create();
            await AddChessGameBoardToChessGame(chessGameId, chessGameBoard.Id);

            List<Task> gameBoardSpaceAddTasks = new List<Task>();

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
                    gameBoardSpaceAddTasks.Add(CreateChessGameBoardSpace(chessGameId, chessGameBoard.Id, rank, file, color));
                }
            }
            Task.WaitAll(gameBoardSpaceAddTasks.ToArray());

            //now connect adjacent spaces - we use cardinal directions because that simpler than diagonal-left-down, etc.

            //unless it's the first rank connect the adjacent space south
            //unless it's the first file connect the adjacent space west
            //unless it's the first file or the first rank connect the adjacent space southwest
            //unless it's the last file or the first rank connect the adjacent space southeast
        }
        private async void InitialSetup(Guid chessGameId)
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

            await CreateChessBoard(chessGameId);

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
        }
    }
}
