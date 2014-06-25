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
            MonopolyPlayer player1 = new MonopolyPlayer();
            MonopolyPlayer player2 = new MonopolyPlayer();

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(player1);
            players.Add(player2);

            Monopoly game = new Monopoly(players);

            Assert.That(game, Is.Not.Null);
        }

        [Test]
        public void AGameWithMoreThen8PlayersShouldFail()
        {
            
            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            for (int i = 0; i < 9; ++i )
            {
                players.Add(new MonopolyPlayer());
            }

            var exception = Assert.Throws<TooManyPlayersException>(() => new Monopoly(players));

            Assert.That(exception.Message, Is.EqualTo("Too many players: 9"));

        }

        [Test]
        public void AGameWithLessThen2PlayersShouldFail()
        {

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            var exception = Assert.Throws<TooFewPlayersException>(() => new Monopoly(players));

            Assert.That(exception.Message, Is.EqualTo("Too few players: 0"));

        }

        [Test]
        public void RandomPlayOrderShouldBeGenerated_In100GamesBothPlayOrdersShouldAppear()
        {
            MonopolyPlayer Horse = new MonopolyPlayer("Horse");
            MonopolyPlayer Car = new MonopolyPlayer("Car");

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(Horse);
            players.Add(Car);



            List<Monopoly> ListOfMonopolyGames = new List<Monopoly>();

            for( int i = 0; i < 100; ++i )
            {
                ListOfMonopolyGames.Add(new Monopoly(players));
            }

            var differentOrder = from g in ListOfMonopolyGames
                                 where g.GetCurrentTurnPlayer() == Car
                                 select g;

            var diffentCount = differentOrder.Count();

            Assert.That(diffentCount, Is.GreaterThan(2));

        }

        [Test]
        public void APlayerRoll_ShouldIncreaseTheirLocationByTheRoll()
        {
            
            MonopolyPlayer Horse = new MonopolyPlayer("Horse");
            MonopolyPlayer Car = new MonopolyPlayer("Car");

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(Horse);
            players.Add(Car);


            Monopoly game = new Monopoly(players);

            game.MoveTheCurrentTurnPlayer(7);

            Assert.That(game.GetLocation(1), Is.EqualTo(7));

        }

        [Test]
        public void APlayerRollThatGoesBeyondTheLastSpaceOnTheBoard_ShouldLoopAroundToTheBeginingOfBoard()
        {

            MonopolyPlayer Horse = new MonopolyPlayer("Horse");
            MonopolyPlayer Car = new MonopolyPlayer("Car");

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(Horse);
            players.Add(Car);


            Monopoly game = new Monopoly(players);

            game.MoveTheCurrentTurnPlayer(39);

            game.MoveTheCurrentTurnPlayer(6);

            Assert.That(game.GetLocation(1), Is.EqualTo(5));

        }

        [Test]
        public void After20RoundsOfMovingOneSpace_EachPlayerShouldBeOnLocation20()
        {

            MonopolyPlayer Horse = new MonopolyPlayer("Horse");
            MonopolyPlayer Car = new MonopolyPlayer("Car");

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(Horse);
            players.Add(Car);

            Monopoly game = new Monopoly(players);

            for (int i = 0; i < 20; ++i)
            {
                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

           }

            Assert.That(game.GetLocation(Horse), Is.EqualTo(20));
            Assert.That(game.GetLocation(Car), Is.EqualTo(20));

        }

        [Test]
        public void After20RoundsOfMoving_ThePlayOrderShouldNeverChange()
        {

            MonopolyPlayer Horse = new MonopolyPlayer("Horse");
            MonopolyPlayer Car = new MonopolyPlayer("Car");

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(Horse);
            players.Add(Car);


            Monopoly game = new Monopoly(players);

            MonopolyPlayer player1 = game.GetCurrentTurnPlayer();
            game.MoveTheCurrentTurnPlayer(1);
            game.GoToNextTurn();

            MonopolyPlayer player2 = game.GetCurrentTurnPlayer();
            game.MoveTheCurrentTurnPlayer(1);
            game.GoToNextTurn();

            for (int i = 0; i < 19; ++i)
            {
                Assert.That(player1, Is.EqualTo(game.GetCurrentTurnPlayer()));
                game.MoveTheCurrentTurnPlayer(1);
                game.GoToNextTurn();

                Assert.That(player2, Is.EqualTo(game.GetCurrentTurnPlayer()));
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

            MonopolyPlayer Horse = new MonopolyPlayer("Horse");
            MonopolyPlayer Car = new MonopolyPlayer("Car");

            List<MonopolyPlayer> players = new List<MonopolyPlayer>();

            players.Add(Horse);
            players.Add(Car);

            Monopoly game = new Monopoly(players);

            game.MoveTheCurrentTurnPlayer(40);

            Assert.That(game.GetCurrentTurnPlayer().Balence, Is.EqualTo(200));


        }


    }


}
