using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Setup;

namespace MonopolyKataTests
{

    [TestFixture]
    class SetupTests
    {

        [Test]
        public void ASetupShouldBeCreatedWithStringsPassedAsPlayerIdentifyers()
        {
            ISetup setup = new MonopolySetup("Player1", "Player2");

            Assert.That(setup, Is.Not.Null);
        }

        [Test]
        public void ASetupWithMoreThen8PlayersShouldFail()
        {
            String[] players = { "Player 1", "Player 2", "Player 3", 
                                 "Player 4", "Player 5", "Player 6", 
                                 "Player 7", "Player 8", "Player 9" };

            var exception = Assert.Throws<TooManyPlayersException>(() => new MonopolySetup(players));

            Assert.That(exception.Message, Is.EqualTo("Too many players: 9"));

        }

        [Test]
        public void ASetupWithLessThen2PlayersShouldFail()
        {
            var exception = Assert.Throws<TooFewPlayersException>(() => new MonopolySetup());

            Assert.That(exception.Message, Is.EqualTo("Too few players: 0"));

        }

        [Test]
        public void ASetupShouldTellYouWhoGoesFirst()
        {
            String [] playerNames = {"Player1", "Player2"};
            
            ISetup setup = new MonopolySetup(playerNames);

            MonopolyPlayer firstplayer = setup.WhoGoesFirst();

            Assert.That(playerNames.Any(n => n.Contains(firstplayer.name)));

        }

        [Test]
        public void GivenAValidPlayerTheSetupShouldTellYouWhoGoesNext()
        {
            ISetup setup = new MonopolySetup("Horse", "Car" );

            MonopolyPlayer player1 = setup.WhoGoesFirst();

            MonopolyPlayer player2 = setup.WhoGoesNext(player1);

            Assert.That(player1, Is.Not.Null);
            Assert.That(player2, Is.Not.Null);
            Assert.That(player1, Is.Not.EqualTo(player2));

        }

        [Test]
        public void ForEachSetupRandomPlayOrderShouldBeGenerated_In100GamesBothPlayOrdersShouldAppear()
        {
            List<MonopolySetup> ListOfSetups = new List<MonopolySetup>();

            for (int i = 0; i < 100; ++i)
            {
                ListOfSetups.Add(new MonopolySetup("Horse", "Car"));
            }

            var differentOrder = from g in ListOfSetups
                                 where g.WhoGoesFirst().name.Equals("Car")
                                 select g;

            var diffentCount = differentOrder.Count();

            Assert.That(diffentCount, Is.GreaterThan(1));
            Assert.That(diffentCount, Is.LessThan(99));

        }



 



    }
}
