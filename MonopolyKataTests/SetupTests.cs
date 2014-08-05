using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Setup;
using MonopolyKata.Player;

namespace MonopolyKataTests
{

    [TestFixture]
    class SetupTests
    {

        [Test]
        public void ASetupShouldBeCreatedWithStringsPassedAsPlayerIdentifyers()
        {
            IPlayerOrderSetup setup = new PlayerOrderSetup("Player1", "Player2");

            Assert.That(setup, Is.Not.Null);
        }

        [Test]
        public void ASetupWithMoreThen8PlayersShouldFail()
        {
            String[] players = { "Player 1", "Player 2", "Player 3", 
                                 "Player 4", "Player 5", "Player 6", 
                                 "Player 7", "Player 8", "Player 9" };

            TooManyPlayersException exception = Assert.Throws<TooManyPlayersException>(() => new PlayerOrderSetup(players));

            Assert.That(exception.Message, Is.EqualTo("Too many players: 9"));

        }

        [Test]
        public void ASetupWithLessThen2PlayersShouldFail()
        {
            TooFewPlayersException exception = Assert.Throws<TooFewPlayersException>(() => new PlayerOrderSetup("Player1"));

            Assert.That(exception.Message, Is.EqualTo("Too few players: 1"));

        }

        [Test]
        public void ASetupShouldTellYouWhoGoesFirst()
        {
            String [] playerNames = {"Player1", "Player2"};
            
            IPlayerOrderSetup setup = new PlayerOrderSetup(playerNames);

            IPlayer firstplayer = setup.WhoGoesFirst();

            Assert.That(playerNames.Any(n => n.Contains(firstplayer.name)));

        }

        [Test]
        public void GivenAValidPlayerTheSetupShouldTellYouWhoGoesNext()
        {
            IPlayerOrderSetup setup = new PlayerOrderSetup("Horse", "Car" );

            IPlayer player1 = setup.WhoGoesFirst();

            IPlayer player2 = setup.WhoGoesNext(player1);

            Assert.That(player1, Is.Not.Null);
            Assert.That(player2, Is.Not.Null);
            Assert.That(player1, Is.Not.EqualTo(player2));

        }

        [Test]
        public void ForEachSetupRandomPlayOrderShouldBeGenerated_In100GamesBothPlayOrdersShouldAppear()
        {
            List<PlayerOrderSetup> ListOfSetups = new List<PlayerOrderSetup>();

            for (int i = 0; i < 100; ++i)
            {
                ListOfSetups.Add(new PlayerOrderSetup("Horse", "Car"));
            }

            IEnumerable<PlayerOrderSetup> differentOrder = from g in ListOfSetups
                                 where g.WhoGoesFirst().name.Equals("Car")
                                 select g;

            int diffentCount = differentOrder.Count();

            Assert.That(diffentCount, Is.GreaterThan(1));
            Assert.That(diffentCount, Is.LessThan(99));

        }



    }
}
