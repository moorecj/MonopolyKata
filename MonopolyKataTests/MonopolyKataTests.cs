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
        public void APlayerRoll_ShouldIncreaseTheirLocationByTheRoll()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            game.MoveTheCurrentTurnPlayer(7);

            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(7));

        }

        [Test]
        public void APlayerRollThatGoesBeyondTheLastSpaceOnTheBoard_ShouldLoopAroundToTheBeginingOfBoard()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            game.MoveTheCurrentTurnPlayer(39);

            game.MoveTheCurrentTurnPlayer(6);

            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(5));

        }

        [Test]
        public void After20RoundsOfMovingOneSpace_EachPlayerShouldBeOnLocation20()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            for (int i = 0; i < 20; ++i)
            {
                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

                game.MoveTheCurrentTurnPlayer(1);
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
            game.MoveTheCurrentTurnPlayer(1);
            game.GoToNextTurn();

            string player2Name = game.GetCurrentTurnPlayer().name;
            game.MoveTheCurrentTurnPlayer(1);
            game.GoToNextTurn();

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

                Assert.That(player2Name, Is.EqualTo(game.GetCurrentTurnPlayer().name));
                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();
                
            }

        }

        [Test]
        public void APlayerShouldHaveAStartingBalenceOfZero()
        {

            MonopolyPlayer horse = new MonopolyPlayer("Horse");

            Assert.That(horse.Balence, Is.EqualTo(0));


        }

        [Test]
        public void APlayerWhoLandsOnGo_ShouldIncreaseTheirFundsBy200()
        {

            ISetup setup = new MonopolySetup("Horse", "Car");
            Monopoly game = new Monopoly(setup);

            game.MoveTheCurrentTurnPlayer(40);

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(200));


        }


    }


}
