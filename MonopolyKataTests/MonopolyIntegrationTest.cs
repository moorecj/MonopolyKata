using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Setup;
using MonopolyKata;
using MonopolyKata.Dice;

namespace MonopolyKataTests
{
    [TestFixture]
    class MonopolyIntegrationTest
    {
        [Test]
        public void PlayAGame()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            IDice die = new SixSidedDie();

            MonopolyEngine game = new MonopolyEngine(setup, die);

            for (int i = 0; i < 20; ++i)
            {
                
                game.TakeTurn();
               
                game.TakeTurn();

            }

        }

    }
}
