using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MrPitiful.SlackChess
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private string helpText =
            "Welcome to Slack Chess!\n" +
            "To start a new game type the command: \\Chess StartGame\n" +
            "To move a piece use \\Chess Move [MoveTo] [MoveFrom]\n" +
            "Example: \\Chess Move d4 d2\n" +
            "--As an opening move would execute the [Queen's Gambit](https://en.wikipedia.org/wiki/Queen%27s_Gambit) moving the white pawn at d2 two spaces forward to d4";
        
        private async Task<string> StartGame(string channel_id)
        {
            return "StartGame";
        }

        private async Task<string> Move(string moveTo, string moveFrom)
        {
            return "Move " + moveTo + " " + moveFrom;
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post(
            string token,
            string team_id,
            string team_domain,
            string channel_id,
            string channel_name,
            string user_id,
            string user_name,
            string command,
            string text,
            string response_url)
        {
            string[] options;
            var responseString = helpText;
            if (command.ToLower() == "\\chess" && text != string.Empty) {
                options = text.Split(' ');
                switch (options[0])
                {
                    case "StartGame":
                        responseString = await StartGame(channel_id);
                        break;
                    case "Move":
                        if (options.Length == 3)
                        {
                            responseString = await Move(options[1], options[2]);
                        }
                        break;
                }
            }

            return responseString;
        }
    }
}
