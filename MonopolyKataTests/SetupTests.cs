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

 



    }
}
