using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces.RealEstate.RailRoad;


namespace MonopolyKataTests
{
    [TestFixture]
    public class RailRoadTests
    {
        [Test]
        public void LandingOnARailRoadWhereTheOwnerOnlyOwnsThatRailRoadPays25ToTheOwner()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;
            player2.Balence = 25;

            int PurchaseCost =  200;

            RailRoadSpace railRoad = new RailRoadSpace("Rail Road Space", PurchaseCost);

            railRoad.Owner = player1;

            railRoad.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(25));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

    }
}
