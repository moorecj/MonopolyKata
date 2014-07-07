using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Board.Spaces.RealEstate;


namespace MonopolyKataTests
{
    [TestFixture]
    public class RealEstateTests
    {

        [Test]
        public void RealEstateShouldHaveAnOwner()
        {
            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space");

            Assert.That( realEstateSpace.Owner, Is.EqualTo(null));

        }

        [Test]
        public void PurchasingARealEstateSpaceShouldChangeTheOwerToTheUserThatPurchaedIt()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space");

            realEstateSpace.Purchase(player1);

            Assert.That(realEstateSpace.Owner, Is.EqualTo(player1));

        }


    }
}
