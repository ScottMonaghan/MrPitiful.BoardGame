using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;


namespace MrPitiful.BoardGame.Game.Web.Client
{
    public class GameAPIClient
    {
        private HttpClient _httpClient;
        public GameAPIClient(Uri gameAPIBaseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = gameAPIBaseAddress;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("appplication/json"));
        }

        public async Task<Game> Get(Guid Id)
        {
            HttpResponseMessage response =
                await _httpClient.GetAsync(
                    string.Format("api/game/{0}", Id)
                    );
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Game>(
                    response.Content.ReadAsStringAsync().Result
                );
            }
            else
            {
                return null;
            }
        }
        public async Task<Game> Create()
        {
            HttpResponseMessage response =
                await _httpClient.GetAsync(
                    string.Format("api/game/create")
                    );
            if (response.IsSuccessStatusCode)
            {  
                return JsonConvert.DeserializeObject<Game>(
                    response.Content.ReadAsStringAsync().Result
                );
            } else {
                return null;
            }
        }
        public async Task AddPlayerIdToGame(Guid playerId, Guid gameId)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/AddPlayerIdToGame/{0}/{1}", playerId, gameId)
                );
        }
        public async Task RemovePlayerIdFromGame(Guid playerId, Guid gameId)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/RemovePlayerIdFromGame/{0}/{1}", playerId, gameId)
            );
        }
        public async Task AddGamePieceIdToGame(Guid gamePieceId, Guid gameId)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/AddGamePieceIdToGame/{0}/{1}", gamePieceId, gameId)
            );
        }
        public async Task RemoveGamePieceIdFromGame(Guid gamePieceId, Guid gameId)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/RemoveGamePieceIdFromGame/{0}/{1}", gamePieceId, gameId)
            );
        }
        public async Task AddGameBoardSpaceIdToGame(Guid gameBoardSpaceId, Guid gameId)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/AddGameBoardSpaceIdToGame/{0}/{1}", gameBoardSpaceId, gameId)
            );
        }
        public async Task RemoveGameBoardSpaceIdFromGame(Guid gameBoardSpaceId, Guid gameId)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/RemoveGameBoardSpaceIdFromGame/{0}/{1}", gameBoardSpaceId, gameId)
            );
        }
        public async Task UpdateGameStateProperty(Guid gameId, string gameStatePropertyName, string gameStatePropertyValue)
        {
            HttpResponseMessage response =
            await _httpClient.GetAsync(
                string.Format("api/game/UpdateGameStateProperty/{0}/{1}/{2}", gameId, WebUtility.UrlEncode(gameStatePropertyName), WebUtility.UrlEncode(gameStatePropertyValue))
            );
        }
        public async Task<String> GetGameStateProperty(Guid gameId, string gameStatePropertyName)
        {
            HttpResponseMessage response =
                await _httpClient.GetAsync(
                    string.Format("GetGameStateProperty/{gameId}/{gameStatePropertyName}", gameId, gameStatePropertyName)
                    );
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<String>(
                    response.Content.ReadAsStringAsync().Result
                );
            }
            else
            {
                return null;
            }
        }

    }
}
