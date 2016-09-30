using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GamePieceClient<TGamePiece> : GameObjectClient<TGamePiece>, IGamePieceClient<TGamePiece>
        where TGamePiece:IGamePiece
       {
        private string _apiRoute;
        private HttpClient _httpClient;

        //public GamePieceClient()
        //{
        //}

        public GamePieceClient(HttpClient httpClient, string apiRoute = "api/GamePiece"):base(httpClient,apiRoute)
        {
            _apiRoute = apiRoute;
            _httpClient = httpClient;
        }

        public async Task<Guid> GetGamePieceGameBoardId(Guid gamePieceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetGamePieceGameBoardId/{0}",
                 gamePieceId
                 )
             );
            return JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task<Guid> GetGamePieceGameBoardSpaceId(Guid gamePieceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetGamePieceGameBoardSpaceId/{0}",
                 gamePieceId
                 )
             );
            return JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task<Guid> GetGamePieceGameId(Guid gamePieceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetGamePieceGameId/{0}",
                 gamePieceId
                 )
             );
            return JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task SetGamePieceGameBoardId(Guid gamePieceId, Guid gameBoardId)
        {
            await _httpClient.GetAsync(
                   String.Format("/" + _apiRoute + "/SetGamePieceGameBoardId/{0}/{1}",
                   gamePieceId, gameBoardId
                   )
               );
        }

        public async Task SetGamePieceGameId(Guid gamePieceId, Guid gameId)
        {
            await _httpClient.GetAsync(
                   String.Format("/" + _apiRoute + "/SetGamePieceGameId/{0}/{1}",
                   gamePieceId, gameId
                   )
               );
        }

        public async Task SetGamePieceGameBoardSpaceId(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            await _httpClient.GetAsync(
                   String.Format("/" + _apiRoute + "/SetGamePieceGameBoardSpaceId/{0}/{1}",
                   gamePieceId, gameBoardSpaceId
                   )
               );
        }
    }
}
