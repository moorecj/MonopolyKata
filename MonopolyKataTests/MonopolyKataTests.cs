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
            Player Player2 = new Player();

            List<Player> players = new List<Player>();

            Monopoly game = new Monopoly(players);
        }
    }
}
