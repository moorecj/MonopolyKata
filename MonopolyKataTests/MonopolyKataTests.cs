using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;

using NUnit.Framework;

namespace MonopolyKataTests
{
    [TestFixture]
    public class MonopolyKataTests
    {
        [Test]
        public void CanMakeNewMonopolyGameWith2Players()
        {
            Player player1 = new Player();
            Player player2 = new Player();

            List<Player> players = new List<Player>();

            players.Add(player1);
            players.Add(player2);

            Monopoly game = new Monopoly(players);

            Assert.That(game, Is.Not.Null);
        }

        [Test]
        public void AGameWithMoreThen8PlayersShouldFail()
        {
            

            List<Player> players = new List<Player>();

            for (int i = 0; i < 9; ++i )
            {
                players.Add(new Player());
            }

            var exception = Assert.Throws<TooManyPlayersException>(() => new Monopoly(players));

            Assert.That(exception.Message, Is.EqualTo("Too many players: 9"));

        }

        [Test]
        public void AGameWithLessThen2PlayersShouldFail()
        {

            List<Player> players = new List<Player>();

            var exception = Assert.Throws<TooFewPlayersException>(() => new Monopoly(players));

            Assert.That(exception.Message, Is.EqualTo("Too few players: 0"));

        }

        [Test]
        public void RandomPlayOrderShouldBeGenerated_In100GamesBothPlayOrdersShouldAppear()
        {
            Player Horse = new Player();
            Player Car = new Player();

            List<Player> players = new List<Player>();

            players.Add(Horse);
            players.Add(Car);

            List<Monopoly> ListOfMonopolyGames = new List<Monopoly>();

            for( int i = 0; i < 100; ++i )
            {
                ListOfMonopolyGames.Add(new Monopoly(players));
            }

            var differentOrderGames = from g in ListOfMonopolyGames
                                      where g.GetPlayOrder()[0] != Car
                                      select g;

            Assert.That(differentOrderGames.Count(), Is.GreaterThan(0));


        }
    }


}
