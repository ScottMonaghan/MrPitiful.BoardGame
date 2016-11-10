using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MrPitiful.SlackChess
{
    [Route("api/[controller]")]
    public class SlackChessGameController : Controller
    {
        private ISlackChessGame _slackChessGame;
        private ISlackChessGameRepository _slackChessRepository;
        private IConfiguration _configuration;
        private HttpClient _client;
        //private ISlackResponse _slackResponse;

        public SlackChessGameController(
            IConfiguration configuration, 
            //ISlackResponse slackResponse, 
            ISlackChessGame slackChessGame, 
            ISlackChessGameRepository slackChessRepository)
        {
            _slackChessGame = slackChessGame;
            _slackChessRepository = slackChessRepository;
            //_slackResponse = slackResponse;
            _client = new HttpClient();
            _configuration = configuration;
            _client.BaseAddress = new Uri(_configuration.GetSection("UnicodeChess").GetValue<string>("ApiUri"));

        }

        private string helpText =
            "Welcome to Slack Chess!\n" +
            "To start a new game type the command: /Chess StartGame\n" +
            "To move a piece use /Chess Move [MoveTo] [MoveFrom]\n" +
            "Example: /Chess Move d4 d2\n" +
            "--As an opening move would execute the [Queen's Gambit](https://en.wikipedia.org/wiki/Queen%27s_Gambit) moving the white pawn at d2 two spaces forward to d4";

        [HttpGet("StartGame/{slackChannelId}"), HttpPost("StartGame/{slackChannelId}")]
        public async Task<string> StartGame(string slackChannelId)
        {
            string responseString = "";
            var response = await _client.GetAsync("api/ChessGameMaster/StartGame");
            Guid unicodeChessGameId = JsonConvert.DeserializeObject<Guid>(
                    await response.Content.ReadAsStringAsync()
                );
            _slackChessRepository.Create(slackChannelId, unicodeChessGameId);
            response = await _client.GetAsync(String.Format("api/ChessGameMaster/GetGameMessage/{0}",unicodeChessGameId));
            responseString += await response.Content.ReadAsStringAsync();
            response = await _client.GetAsync(String.Format("api/ChessGameMaster/RenderChessBoardAsText/{0}",unicodeChessGameId));
            responseString += "```\n" + await response.Content.ReadAsStringAsync() + "```\n";
            await _client.GetAsync(String.Format("api/ChessGameMaster/ClearGameMessage/{0}", unicodeChessGameId));

            return responseString;
        }

        [HttpGet("Move/{slackChannelId}/{moveTo}/{moveFrom}"), HttpPost("Move/{slackChannelId}/{moveTo}/{moveFrom}")]
        public async Task<string> Move(string slackChannelId, string moveTo, string moveFrom)
        {
            Guid unicodeChessGameId = _slackChessRepository.Get(slackChannelId).UnicodeChessGameId;
            Regex positionValidation = new Regex("^[a-hA-H][1-8]$");
            string responseString = "";
            if (positionValidation.IsMatch(moveTo) && positionValidation.IsMatch(moveFrom))
            {
                var response = await _client.GetAsync(
                    String.Format(
                        "api/ChessGameMaster/Move/{0}/{1}/{2}/{3}/{4}",
                        unicodeChessGameId,
                        moveTo.ToCharArray()[0],
                        moveTo.ToCharArray()[1],
                        moveFrom.ToCharArray()[0],
                        moveFrom.ToCharArray()[1]
                        )
                    );
                response = await _client.GetAsync(String.Format("api/ChessGameMaster/GetGameMessage/{0}", unicodeChessGameId));
                responseString += await response.Content.ReadAsStringAsync();
                response = await _client.GetAsync(String.Format("api/ChessGameMaster/RenderChessBoardAsText/{0}", unicodeChessGameId));
                responseString += "```\n" + await response.Content.ReadAsStringAsync() + "\n```";
                await _client.GetAsync(String.Format("api/ChessGameMaster/ClearGameMessage/{0}", unicodeChessGameId));
            }
            else
            {
                responseString = helpText;
            }
            return responseString;
        }

        public async Task RespondToSlackAsync(
            string token = "",
            string team_id = "",
            string team_domain = "",
            string channel_id = "",
            string channel_name = "",
            string user_id = "",
            string user_name = "",
            string command = "",
            string text = "",
            string response_url = "")
        {
            string[] options;
            var responseString = helpText;
            if (command.ToLower() == "/chess" && text != string.Empty)
            {
                options = text.Split(' ');
                switch (options[0].ToLower())
                {
                    case "startgame":
                        responseString = await StartGame(channel_id);
                        break;
                    case "move":
                        if (options.Length == 3)
                        {
                            responseString = await Move(channel_id, options[1], options[2]);
                        }
                        break;
                }
            }

            SlackResponse slackResponse = new SlackResponse();
            slackResponse.response_type = "in_channel";
            slackResponse.text = responseString;
            await _client.PostAsync(
                response_url,
                new StringContent(
                    JsonConvert.SerializeObject(slackResponse)
                    )
                );
        }


        [HttpGet("TestString")]
        public string TestString()
        {
            return "I'm working!";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(
            string token = "",
            string team_id = "",
            string team_domain = "",
            string channel_id = "",
            string channel_name = "",
            string user_id = "",
            string user_name = "",
            string command = "",
            string text = "",
            string response_url = "")
        {
            //we don't want to await this because we need to respond to slack in under 3 seconds
            RespondToSlackAsync(token, team_id, team_domain, channel_id, channel_name, user_id, user_name, command, text, response_url);
            SlackResponse slackResponse = new SlackResponse();
            slackResponse.response_type = "in_channel";
            slackResponse.text = user_name + " asked the Chessmaster to " + text + "...";
            return new ObjectResult(slackResponse);
        }
    }
}
