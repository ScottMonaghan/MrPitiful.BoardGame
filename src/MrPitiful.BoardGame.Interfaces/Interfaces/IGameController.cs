using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrPitiful.BoardGame.Interfaces
{
    public interface IGameController
    {
        IGame CreateGame();
        void StartGame();
        void EndGame();
        void AddPlayerToGame(IPlayer player, IGame game);
        void AddSpaceToGame(IGameBoardSpace gameBoardSpace, IGame game);
        void ConnectSpaces(IGameBoardSpace gameBoardSpace, IGameBoardSpace adjacentGameBoardSpace); 
        void AddPieceToSpace(IGamePiece piece, IGameBoardSpace space);
        void MovePieceToSpace(IGamePiece piece, IGameBoardSpace oldSpace, IGameBoardSpace newSpace);
        void RemovePieceFromBoard(IGamePiece piece, IGameBoardSpace space);
    }
}
