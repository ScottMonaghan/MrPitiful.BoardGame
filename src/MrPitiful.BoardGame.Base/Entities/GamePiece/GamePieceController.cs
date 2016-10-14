using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace MrPitiful.BoardGame.Base
{

  
    [Route("api/[controller]")]
    public abstract class GamePieceController : GameObjectController
    {
        private IGamePieceRepository _gamePieceRepository;
        private GamePiece _gamePiece;

        public GamePieceController(IGamePieceRepository gamePieceRepository, GamePiece gamePiece) : base(gamePieceRepository, gamePiece) {
            _gamePieceRepository = gamePieceRepository;
            _gamePiece = gamePiece;
        }

        [HttpGet("SetGamePieceGameId/{gamePieceId}/{gameId}")]
        public async Task SetGamePieceGameId(Guid gamePieceId, Guid gameId)
        {
            GamePiece gamePiece = (GamePiece) await _gamePieceRepository.Get(gamePieceId);
            gamePiece.GameId = gameId;
        }

        [HttpGet("GetGamePieceGameId/{gamePieceId}")]
        public async Task<Guid> GetGamePieceGameId(Guid gamePieceId)
        {
            return ((GamePiece) await _gamePieceRepository.Get(gamePieceId)).GameId;
        }

        [HttpGet("SetGamePieceGameBoardId/{gamePieceId}/{gameBoardId}")]
        public async Task SetGamePieceGameBoardId(Guid gamePieceId, Guid gameBoardId)
        {
            GamePiece gamePiece = (GamePiece) await _gamePieceRepository.Get(gamePieceId);
            gamePiece.GameBoardId = gameBoardId;
        }

        [HttpGet("GetGamePieceGameBoardId/{gamePieceId}")]
        public async Task<Guid> GetGamePieceGameBoardId(Guid gamePieceId)
        {
            return ((GamePiece) await _gamePieceRepository.Get(gamePieceId)).GameBoardId;
        }


        [HttpGet("SetGamePieceGameBoardSpaceId/{gamePieceId}/{gameBoardSpaceId}")]
        public async Task SetGamePieceGameBoardSpaceId(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            GamePiece gamePiece = (GamePiece) await _gamePieceRepository.Get(gamePieceId);
            gamePiece.GameBoardSpaceId = gameBoardSpaceId;
        }

        [HttpGet("GetGamePieceGameBoardSpaceId/{gamePieceId}")]
        public async Task<Guid> GetGamePieceGameBoardSpaceId(Guid gamePieceId)
        {
            return ((GamePiece) await _gamePieceRepository.Get(gamePieceId)).GameBoardSpaceId;
        }

    }

}
