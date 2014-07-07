using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Setup;
using MonopolyKata.Dice;

namespace GameOfMonopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            MonopolyGame game = new MonopolyGame("Car", "Horse" );

            game.PlayGame();

        }
    }
}
