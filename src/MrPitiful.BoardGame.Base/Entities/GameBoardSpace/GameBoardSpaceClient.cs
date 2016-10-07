using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace MrPitiful.BoardGame.Base
{
    public abstract class GameBoardSpaceClient<TGameBoardSpace> : GameObjectClient<TGameBoardSpace>, IGameBoardSpaceClient<TGameBoardSpace>
        where TGameBoardSpace:IGameBoardSpace
       {
        private string _apiRoute;
        private HttpClient _httpClient;

        //public GameBoardSpaceClient()
        //{
        //}

        public GameBoardSpaceClient(HttpClient httpClient, string apiRoute = "api/GameBoardSpace"):base(httpClient,apiRoute)
        {
            _apiRoute = apiRoute;
            _httpClient = httpClient;
        }

        public async Task AddAdjacentSpaceToGameBoardSpace(string direction, Guid adjacentSpaceId, Guid gameBoardSpaceId)
        {
            await _httpClient.GetAsync(
                String.Format("/" + _apiRoute + "/AddAdjacentSpaceToGameBoardSpace/{0}/{1}/{2}",
                direction, adjacentSpaceId, gameBoardSpaceId)
                );
        }

        public async Task AddGamePieceIdToGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            await _httpClient.GetAsync(
                String.Format("/" + _apiRoute + "/AddGamePieceIdToGameBoardSpace/{0}/{1}",
                gamePieceId, gameBoardSpaceId
                )
            );
        }

        public async Task<bool> GameBoardSpaceContainsGamePieceId(Guid gameBoardSpaceId, Guid gamePieceId)
        {
            var response = await _httpClient.GetAsync(
                String.Format("/" + _apiRoute + "/GameBoardSpaceContainsGamePieceId/{0}/{1}",
                gameBoardSpaceId, gamePieceId
                )
            );
            return JsonConvert.DeserializeObject<bool>(
                    await response.Content.ReadAsStringAsync()
                );
        }

        public async Task<Guid> GetAdjacentSpaceIdByDirection(Guid gameBoardSpaceId, string direction)
        {
            var response = await _httpClient.GetAsync(
                String.Format("/" + _apiRoute + "/GetAdjacentSpaceIdByDirection/{0}/{1}",
                gameBoardSpaceId, direction
                )
            );
            return JsonConvert.DeserializeObject<Guid>(
                    await response.Content.ReadAsStringAsync()
                );
        }

        public async Task<List<string>> GetDirectionsByAdjacentSpaceId(Guid gameBoardSpaceId, Guid adjacentSpaceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetDirectionsByAdjacentSpaceId/{0}/{1}",
                 gameBoardSpaceId, adjacentSpaceId
                 )
             );
            return JsonConvert.DeserializeObject<List<string>>(
                    await response.Content.ReadAsStringAsync()
                );
        }

        public async Task<Guid> GetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetGameBoardSpaceGameBoardId/{0}",
                 gameBoardSpaceId
                 )
             );
            return JsonConvert.DeserializeObject<Guid>(
                    await response.Content.ReadAsStringAsync()
                );
        }

        public async Task<Guid> GetGameBoardSpaceGameId(Guid gameBoardSpaceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetGameBoardSpaceGameId/{0}",
                 gameBoardSpaceId
                 )
             );
            return JsonConvert.DeserializeObject<Guid>(
                    await response.Content.ReadAsStringAsync()
                );
        }

        public async Task<List<Guid>> GetGameBoardSpaceGamePieceIds(Guid gameBoardSpaceId)
        {
            var response = await _httpClient.GetAsync(
                 String.Format("/" + _apiRoute + "/GetGameBoardSpaceGamePieceIds/{0}",
                 gameBoardSpaceId
                 )
             );
            return JsonConvert.DeserializeObject<List<Guid>>(
                    await response.Content.ReadAsStringAsync()
                );
        }

        public async Task RemoveAdjacentSpaceFromGameBoardSpace(string direction, Guid gameBoardSpaceId)
        {
            await _httpClient.GetAsync(
                    String.Format("/" + _apiRoute + "/RemoveAdjacentSpaceFromGameBoardSpace/{0}/{1}",
                    direction, gameBoardSpaceId
                    )
                );       
        }

        public async Task RemoveGamePieceIdFromGameBoardSpace(Guid gamePieceId, Guid gameBoardSpaceId)
        {
            await _httpClient.GetAsync(
                   String.Format("/" + _apiRoute + "/RemoveGamePieceIdFromGameBoardSpace/{0}/{1}",
                   gamePieceId, gameBoardSpaceId
                   )
               );
        }

        public async Task SetGameBoardSpaceGameBoardId(Guid gameBoardSpaceId, Guid gameBoardId)
        {
            await _httpClient.GetAsync(
                   String.Format("/" + _apiRoute + "/SetGameBoardSpaceGameBoardId/{0}/{1}",
                   gameBoardSpaceId, gameBoardId
                   )
               );
        }

        public async Task SetGameBoardSpaceGameId(Guid gameBoardSpaceId, Guid gameId)
        {
            await _httpClient.GetAsync(
                   String.Format("/" + _apiRoute + "/SetGameBoardSpaceGameId/{0}/{1}",
                   gameBoardSpaceId, gameId
                   )
               );
        }
    }
}
