using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;

namespace MrPitiful.SlackChess.Test
{
    public class SlackChessGameApiShould
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public SlackChessGameApiShould()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void ReturnATestString()
        {
            var response = await _client.GetAsync("api/SlackChessGame/TestString");
            Assert.Equal("I'm working!", await response.Content.ReadAsStringAsync());
        }
    }
}
