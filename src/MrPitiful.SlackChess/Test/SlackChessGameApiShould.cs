using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;


namespace MrPitiful.SlackChess.Test
{
    /*
     * IMPORTANT: These integration tests require that the unicodeChess APIs be 
     * available at the Uris in appSettings.
     * Defaults:
     *   "ChessApiUris": {
        "ChessGameApiUri": "http://localhost:5000/",
        "ChessGameBoardApiUri": "http://localhost:5000/",
        "ChessGameBoardSpaceApiUri": "http://localhost:5000/",
        "ChessGamePieceApiUri": "http://localhost:5000/"
      }
      */
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
            
/*
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
*/
        [Fact]
        public async void StartGame()
        {
            //Arrange
            var channel_id = "12345";

            //Act
            var response = await _client.GetAsync(
                String.Format("api/SlackChessGame/StartGame/{0}", channel_id)
                );

            string result = await response.Content.ReadAsStringAsync();

            //Assert
            //result should include chessboard with the piece: ♚
            Assert.True(result.Contains("♚") && result.Contains("New game set up!"));
        }
        [Fact]
        public async void Move()
        {
            //Arrange
            var values = new Dictionary<string, string>();
            var moveTo = "d4";
            var moveFrom = "d2";
            var channel_id = "12345";
            // Start Game
            await _client.GetAsync(
               String.Format("api/SlackChessGame/StartGame/{0}", channel_id)
               );

            //Act
            var response = await _client.GetAsync(
                String.Format("api/SlackChessGame/Move/{0}/{1}/{2}"
                ,channel_id
                ,moveTo
                ,moveFrom
                )
            );

            string result = await response.Content.ReadAsStringAsync();
               
            //Assert
            //result should include chessboard with the piece: ♚
            Assert.True(result.Contains("♚"));
        }

        [Fact]
        public async void RespondToCommand()
        {
            //Arrange
            var values = new Dictionary<string, string>();
            var user_name = "Scott";
            var text = "StartGame";
            var expectedResult = user_name + " asked the Chessmaster to " + text + "...";

            //Act
            //Create Game
            values.Add("channel_id", "12345");
            values.Add("command", "\\Chess");
            values.Add("text", "StartGame");
            values.Add("user_name", user_name);
            var postContent = new FormUrlEncodedContent(values);
            var response = await _client.PostAsync("api/SlackChessGame", postContent);
            SlackResponse result = JsonConvert.DeserializeObject<SlackResponse>
                (await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(expectedResult, result.text);
        }

    }
}
