using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameClient<TGame> : GameObjectClient<TGame>, IGameClient<TGame>
        where TGame:IGame
       {
        private string _apiRoute;
        private HttpClient _httpClient;

        public GameClient()
        {
        }

        public GameClient(HttpClient httpClient, string apiRoute = "api/Game"):base(httpClient,apiRoute)
        {
            _apiRoute = apiRoute;
            _httpClient = httpClient;
        }

        public async Task AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/AddGameBoardSpaceIdToGame/{0}/{1}", gameBoardSpaceId, gameId));
        }

        public async Task AddGamePieceIdToGame(Guid gamePieceId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/AddGamePieceIdToGame/{0}/{1}", gamePieceId, gameId));
        }

        public async Task AddPlayerIdToGame(Guid playerId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/AddPlayerIdToGame/{0}/{1}", playerId, gameId));
        }

        public async Task<bool> GameContainsGameBoardSpaceId(Guid gameId, Guid gameBoardSpaceId)
        {
            var response = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/GameContainsGameBoardSpaceId/{0}/{1}", gameId, gameBoardSpaceId));
            return JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task<bool> GameContainsGamePieceId(Guid gameId, Guid gamePieceId)
        {
            var response = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/GameContainsGamePieceId/{0}/{1}", gameId, gamePieceId));
            return JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task<bool> GameContainsPlayerId(Guid gameId, Guid playerId)
        {
            var response = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/GameContainsPlayerId/{0}/{1}", gameId, playerId));
            return JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task<Guid> GetGameBoardId(Guid gameId)
        {
            var response = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/GetGameBoardId/{0}", gameId));
            return JsonConvert.DeserializeObject<Guid>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/RemoveGameBoardSpaceIdFromGame/{0}/{1}", gameBoardSpaceId, gameId));
        }

        public async Task RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/RemoveGamePieceIdFromGame/{0}/{1}", gamePieceId, gameId));
        }

        public async Task RemovePlayerIdFromGame(Guid playerId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/RemovePlayerIdFromGame/{0}/{1}", playerId, gameId));
        }

        public async Task SetGameBoardId(Guid gameId, Guid gameBoardId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/SetGameBoardId/{0}/{1}", gameId, gameBoardId));
        }
    }
}
