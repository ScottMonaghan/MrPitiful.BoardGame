using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfHouses.Logic;

namespace GameOfHouses.MechanicsExperiments.DotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var rnd = new Random();
            var world = new World(rnd);
            var player = new Player();
            world.Player = player;
            Game game;
            if (Constants.PLAY_INTRO)
            {
                game = Utility.InitializeWorldWithIntro(world, rnd, player);
            } else
            {
                game = Utility.InitializeWorld(world, rnd, player);
            }

            while (world.Year < 500)
            {
                var playersLeftToTakeTurn = game.Players.ToList();
                while (playersLeftToTakeTurn.Count() > 0)
                {
                    var nextPlayer = playersLeftToTakeTurn[rnd.Next(0, playersLeftToTakeTurn.Count())];
                    playersLeftToTakeTurn.Remove(nextPlayer);
                    nextPlayer.DoPlayerTurn(rnd);
                }
                Utility.IncrementYear(world, rnd);
            }
            Console.ReadLine();
        }
    }
}
