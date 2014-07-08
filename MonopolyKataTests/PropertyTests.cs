using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Board.Spaces.RealEstate.Property;
using MonopolyKata.Player;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void LandingOnASpaceOwnedByAnotherPlayerTransferTheRentCostFromTheRenterToTheOwner()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;

            player2.Balence = 10;

            int LandOnCost = 10;
            int PurchaseCost = 100;

            PropertySpace propertySpace = new PropertySpace("Real Estate Space", LandOnCost, PurchaseCost);

            propertySpace.Owner = player1;

            propertySpace.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(10));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }
    }
}
