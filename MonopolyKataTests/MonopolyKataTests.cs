using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Player;
using NUnit.Framework;

namespace MonopolyKataTests
{
    [TestFixture]
    public class MonopolyKataTests
    {
        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {

            Monopoly game = new Monopoly("Player 1", "Player 2");

            Assert.That(game, Is.Not.Null);
        }


        [Test]
        public void RandomPlayOrderShouldBeGenerated_In100GamesBothPlayOrdersShouldAppear()
        {
            List<Monopoly> ListOfMonopolyGames = new List<Monopoly>();

            for( int i = 0; i < 100; ++i )
            {
                ListOfMonopolyGames.Add(new Monopoly("Horse","Car"));
            }

            var differentOrder = from g in ListOfMonopolyGames
                                 where g.GetCurrentTurnPlayer().name.Equals("Car")
                                 select g;

            var diffentCount = differentOrder.Count();

            Assert.That(diffentCount, Is.GreaterThan(2));

        }

        [Test]
        public void APlayerRoll_ShouldIncreaseTheirLocationByTheRoll()
        {

            Monopoly game = new Monopoly("Horse", "Car");

            game.MoveTheCurrentTurnPlayer(7);

            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(7));

        }

        [Test]
        public void APlayerRollThatGoesBeyondTheLastSpaceOnTheBoard_ShouldLoopAroundToTheBeginingOfBoard()
        {

            Monopoly game = new Monopoly("Horse", "Car");

            game.MoveTheCurrentTurnPlayer(39);

            game.MoveTheCurrentTurnPlayer(6);

            Assert.That(game.GetCurrentTurnPlayer().Location, Is.EqualTo(5));

        }

        [Test]
        public void After20RoundsOfMovingOneSpace_EachPlayerShouldBeOnLocation20()
        {

            Monopoly game = new Monopoly("Horse", "Car");

            for (int i = 0; i < 20; ++i)
            {
                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

           }

            Assert.That(game.GetLocation("Horse"), Is.EqualTo(20));
            Assert.That(game.GetLocation("Car"), Is.EqualTo(20));

        }

        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            Monopoly game = new Monopoly("Horse", "Car");

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

            Monopoly game = new Monopoly("Horse", "Car");

            game.MoveTheCurrentTurnPlayer(40);

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(200));


        }


    }


}
