using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace MrPitiful.BoardGame.Base
{

  
    [Route("api/[controller]")]
    public abstract class GamePieceController : GameObjectController
    {
        private IGamePieceRepository _gamePieceRepository;
        private IGamePiece _gamePiece;

        public GamePieceController(IGamePieceRepository gamePieceRepository, IGamePiece gamePiece) : base(gamePieceRepository, gamePiece) {
            _gamePieceRepository = gamePieceRepository;
            _gamePiece = gamePiece;
        }

        [HttpGet("SetGamePieceGameId/{gamePieceId}/{gameId}")]
        public void SetGamePieceGameId(Guid gamePieceId, Guid gameId)
        {
            IGamePiece gamePiece = (IGamePiece)_gamePieceRepository.Get(gamePieceId);
            gamePiece.GameId = gameId;
        }

        [HttpGet("GetGamePieceGameId/{gamePieceId}")]
        public Guid GetGamePieceGameId(Guid gamePieceId)
        {
            return ((IGamePiece)_gamePieceRepository.Get(gamePieceId)).GameId;
        }

        [HttpGet("SetGamePieceGameBoardSpaceId/{gamePieceId}/{gameBoardSpaceId}")]
        public void SetGamePieceGameBoardSpaceId(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            IGamePiece gamePiece = (IGamePiece)_gamePieceRepository.Get(gamePieceId);
            gamePiece.GameBoardSpaceId = gameBoardSpaceId;
        }

        [HttpGet("GetGamePieceGameBoardSpaceId/{gamePieceId}")]
        public Guid GetGamePieceGameBoardSpaceId(Guid gamePieceId)
        {
            return ((IGamePiece)_gamePieceRepository.Get(gamePieceId)).GameBoardSpaceId;
        }

    }

}
