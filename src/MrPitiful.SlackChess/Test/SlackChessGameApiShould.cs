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

        [Fact]
        public async void ReturnSlackResponseWithHelpTextOnPost()
        {
            //arrange
            string helpText =
            "Welcome to Slack Chess!\n" +
            "To start a new game type the command: \\Chess StartGame\n" +
            "To move a piece use \\Chess Move [MoveTo] [MoveFrom]\n" +
            "Example: \\Chess Move d4 d2\n" +
            "--As an opening move would execute the [Queen's Gambit](https://en.wikipedia.org/wiki/Queen%27s_Gambit) moving the white pawn at d2 two spaces forward to d4";

            //Act
            var response = await _client.PostAsync("api/SlackChessGame", new StringContent(""));

            SlackResponse result = JsonConvert.DeserializeObject<SlackResponse>(
                    await response.Content.ReadAsStringAsync()
                );

            //Assert
            Assert.Equal(helpText, result.text);   
        }

        [Fact]
        public async void StartGame()
        {
            //Arrange
            var values = new Dictionary<string, string>();
            values.Add("channel_id", "12345");
            values.Add("command", "\\Chess");
            values.Add("text", "StartGame");

            var postContent = new FormUrlEncodedContent(values);

            //Act
            var response = await _client.PostAsync("api/SlackChessGame", postContent);

            SlackResponse result = JsonConvert.DeserializeObject<SlackResponse>(
                    await response.Content.ReadAsStringAsync()
                );

            //Assert
            //result should include chessboard with the piece: ♚
            Assert.True(result.text.Contains("♚"));
        }
        [Fact]
        public async void Move()
        {
            //Arrange
            var values = new Dictionary<string, string>();
            //Create Game
            values.Add("channel_id", "12345");
            values.Add("command", "\\Chess");
            values.Add("text", "StartGame");
            var postContent = new FormUrlEncodedContent(values);
            var response = await _client.PostAsync("api/SlackChessGame", postContent);

            //Act
            values["text"] = "Move d4 d2";
            postContent = new FormUrlEncodedContent(values);
            response = await _client.PostAsync("api/SlackChessGame", postContent);
            SlackResponse result = JsonConvert.DeserializeObject<SlackResponse>(
                    await response.Content.ReadAsStringAsync()
                );

            //Assert
            //result should include chessboard with the piece: ♚
            Assert.True(result.text.Contains("♚"));
        }
    }
}
