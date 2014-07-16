using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board;
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

            RealEstateSpace propertySpace = new RealEstateSpace("Real Estate Space", PurchaseCost, LandOnCost, new PropertyChargingStrategy());

            propertySpace.Owner = player1;

            propertySpace.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(10));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

        [Test]
        public void LandingOnASpaceWhereAllPropertiesInTheGroupAreOwnedByAnotherPlayerResultsInDoubleRent()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;

            player2.Balence = 20;

            int LandOnCost = 10;
            int PurchaseCost = 100;

            RealEstateSpace groupPropertySpace1 = new RealEstateSpace("Real Estate Space", PurchaseCost, LandOnCost, new PropertyChargingStrategy());
            RealEstateSpace groupPropertySpace2 = new RealEstateSpace("Real Estate Space", PurchaseCost, LandOnCost,  new PropertyChargingStrategy());

            groupPropertySpace1.Owner = player1;
            groupPropertySpace2.Owner = player1;

            GameBoard.GroupSpaces(groupPropertySpace1, groupPropertySpace2);

            groupPropertySpace1.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(20));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }


    }
}
