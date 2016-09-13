using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrPitiful.BoardGame.Game;
using MrPitiful.BoardGame.Interfaces;
using MrPitiful.BoardGame.Game.Web.Client;

namespace ScratchConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new GameAPIClient(new Uri("http://localhost:5000/"));
            Task.Run(async () =>
            {
                var response = await client.Create();
                Game game = (Game)response;
                await client.AddGameBoardSpaceIdToGame(Guid.NewGuid(), game.Id);
                await client.AddGamePieceIdToGame(Guid.NewGuid(), game.Id);
                await client.AddPlayerIdToGame(Guid.NewGuid(), game.Id);
                await client.UpdateGameStateProperty(game.Id, "Test", "Success");
                var response2 = await client.Get(game.Id);
                Game game2 = (Game)response2;
            }).Wait();
        }
    }
}
