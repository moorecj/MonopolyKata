using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board.Spaces.RealEstate.Utilities;
using MonopolyKata.Board.Spaces;
using Moq;
using NUnit.Framework;

namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class UtilitySpaceTests
    {
        [Test]
        public void LandingOnAUtilityWhenOnlyOneUtilityIsOwnedResultsIn4TimesTheLastMovementReducedFromBalence()
        {
            int PurchaseCost = 100;
            UtilitySpace Utility = new UtilitySpace("Utility", PurchaseCost);

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;

            player2.Balence = 40;

            Utility.Owner = player1;

            player2.Move(10);

            Utility.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(40));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

        [Test]
        public void LandingOnAUtilityWhenMoreThenOneIsOwnedResultsIn10TimesTheLastMovementReducedFromBalence()
        {
            int PurchaseCost = 100;
            UtilitySpace Utility1 = new UtilitySpace("Utility", PurchaseCost);
            UtilitySpace Utility2 = new UtilitySpace("Utility", PurchaseCost);

            RealEstateSpace.GroupSpaces(Utility1, Utility2);

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;

            player2.Balence = 100;

            Utility1.Owner = player1;
            Utility2.Owner = player1;

            player2.Move(10);

            Utility1.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(100));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

    }
}
