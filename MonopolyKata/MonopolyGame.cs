using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Setup;
using MonopolyKata.Dice;


namespace MonopolyKata
{
    public class MonopolyGame
    {
            
        List<MonopolyPlayer> players;
        MonopolyEngine gameEngine;
            
        public MonopolyGame(params String[] playerNames)
        {
            players =  new List<MonopolyPlayer>();

            foreach(string s in playerNames )
            {
                players.Add(new ConsolePrintingMonopolyPlayer(s));
            }

            ISetup setup = new MonopolySetup(players.ToArray());
            IDice die = new ConsolePrintingSixSidedDie();

            gameEngine = new MonopolyEngine(setup, die);

        }

        public void PlayGame()
        {
            
            Console.WriteLine("======Play Monopoly========");

            for (int i = 0; i < (players.Count*20); ++i)
            {
                Console.WriteLine("It's " + gameEngine.GetCurrentTurnPlayer().name + "'s turn");
                gameEngine.TakeTurn();

                if (gameEngine.CurrentTurnPlayerIsLoser())
                {
                    Console.WriteLine(gameEngine.GetCurrentTurnPlayer().name + " has lost" );
                }

                if(gameEngine.CurrentTurnPlayerIsWinner())
                {
                    Console.WriteLine(gameEngine.GetCurrentTurnPlayer().name + " has Won");
                    break;
                }

                gameEngine.GoToNextTurn();
            }

        }
            
    }
}
