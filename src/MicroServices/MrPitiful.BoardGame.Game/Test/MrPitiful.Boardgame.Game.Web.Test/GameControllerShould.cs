using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.BoardGame.Game.Web.Test
{
    public class GameAPIShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public GameAPIShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void ReturnAListOfEmptyGames()
        {
            //Act
            var response = await _client.GetAsync("/api/game/");
            var result = JsonConvert.DeserializeObject<Dictionary<Guid,Game>>(
                    response.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async void ReturnAGameWithAGuidAfterCreate()
        {
            var response = await _client.GetAsync("/api/game/create");
            Game result = JsonConvert.DeserializeObject<Game>(
                    response.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.True(result.Id != Guid.Empty);
        }

        [Fact]
        public async void GetAGameByIdAfterCreatingIt()
        {
            var response1 = await _client.GetAsync("/api/game/create");
            Game createdGame = JsonConvert.DeserializeObject<Game>(
                    response1.Content.ReadAsStringAsync().Result
                );
            var response2 = await _client.GetAsync(String.Format("/api/game/{0}", createdGame.Id));
            Game gotGame = JsonConvert.DeserializeObject<Game>(
                    response1.Content.ReadAsStringAsync().Result
                );
            //Assert
            Assert.Equal<Guid>(createdGame.Id, gotGame.Id);
        }

    }
}
