using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Player;
using NUnit.Framework;
using MonopolyKata.Setup;

namespace MonopolyKataTests
{
    [TestFixture]
    public class MonopolyKataTests
    {
        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {
            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            Assert.That(game, Is.Not.Null);
        }
 
       


        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            string player1Name = game.GetCurrentTurnPlayer().name;
            game.RollForCurrentTurnPlayer();

            string player2Name = game.GetCurrentTurnPlayer().name;
            game.RollForCurrentTurnPlayer();

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.RollForCurrentTurnPlayer();

                Assert.That(player2Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.RollForCurrentTurnPlayer();
                
            }

        }

        [Test]
        public void PassingGoShouldIncreaseBalenceBy200()
        {

            ISetup setup = new MonopolySetupFake("Horse", "Car");
            Monopoly game = new Monopoly(setup);


            for (int i = 0; i < 50; ++i)
            {
                
                game.RollForCurrentTurnPlayer();//Rolls for fake setup always 1
                game.RollForCurrentTurnPlayer();

            }

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(200));

        }

        [Test]
        public void LandingOnGoShouldIncreaseBalenceBy200()
        {

            ISetup setup = new MonopolySetupFake("Horse", "Car");
            Monopoly game = new Monopoly(setup);


            for (int i = 0; i <= 41 ; ++i)
            {

                game.RollForCurrentTurnPlayer();//Rolls for fake setup always 1
                game.RollForCurrentTurnPlayer();

            }

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(200));

        }




    }


}
