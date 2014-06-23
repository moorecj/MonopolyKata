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

            for (int i = 0; i <= 9; ++i )
            {
                players.Add(new Player());
            }


            Monopoly game = new Monopoly(players);

            var exception = Assert.Throws<TooManyPlayersException>(() => new Monopoly(players));

            Assert.That(exception.Message, Is.EqualTo("Too many players: 9"));

        }
    }


}
