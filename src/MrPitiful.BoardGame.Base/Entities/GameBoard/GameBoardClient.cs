using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameBoardClient<TGameBoard> : GameObjectClient<TGameBoard>, IGameBoardClient<TGameBoard>
        where TGameBoard:IGameBoard
       {
        private string _apiRoute;
        private HttpClient _httpClient;

        //public GameBoardClient()
        //{
        //}

        public GameBoardClient(HttpClient httpClient, string apiRoute = "api/GameBoard"):base(httpClient,apiRoute)
        {
            _apiRoute = apiRoute;
            _httpClient = httpClient;
        }

        public async Task SetGameBoardGameId(Guid gameBoardId, Guid gameId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/SetGameBoardGameId/{0}/{1}", gameBoardId, gameId));
        }

        public async Task AddGameBoardSpaceIdToGameBoard(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/AddGameBoardSpaceIdToGameBoard/{0}/{1}", gameBoardSpaceId, gameBoardId));
        }

        public async Task<bool> GameBoardContainsGameBoardSpaceId(Guid gameBoardId, Guid gameBoardSpaceId)
        {
            var response = await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/GameBoardContainsGameBoardSpaceId/{0}/{1}", gameBoardId, gameBoardSpaceId));
            return JsonConvert.DeserializeObject<bool>(
                    response.Content.ReadAsStringAsync().Result
                );
        }

        public async Task RemoveGameBoardSpaceIdFromGameBoard(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            await _httpClient.GetAsync(String.Format("/" + _apiRoute + "/RemoveGameBoardSpaceIdFromGameBoard/{0}/{1}", gameBoardSpaceId, gameBoardId));
        }
    }
}
