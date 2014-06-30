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
        public void After10RoundsOfMoving2SpacesEach_EachPlayerShouldBeOnLocation20()
        {

            ISetup setup = new MonopolySetupFake("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            for (int i = 0; i < 10; ++i)
            {
                game.RollForCurrentTurnPlayer();
                game.GoToNextTurn();

                game.RollForCurrentTurnPlayer();
                game.GoToNextTurn();

           }

            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(20));
            game.GoToNextTurn();
            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(20));

        }

        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            string player1Name = game.GetCurrentTurnPlayer().name;
            game.RollForCurrentTurnPlayer();
            game.GoToNextTurn();

            string player2Name = game.GetCurrentTurnPlayer().name;
            game.RollForCurrentTurnPlayer();
            game.GoToNextTurn();

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.RollForCurrentTurnPlayer();
                game.GoToNextTurn();

                Assert.That(player2Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.RollForCurrentTurnPlayer();
                game.GoToNextTurn();
                
            }

        }


    }


}
