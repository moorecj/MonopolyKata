using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board.Spaces;


namespace MonopolyKataTests
{
    [TestFixture]
    public class RealEstateTests
    {

        [Test]
        public void RealEstateShouldHaveAnOwnerInitializedToNull()
        {
            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space");

            Assert.That( realEstateSpace.Owner, Is.EqualTo(null));

        }

        [Test]
        public void RealEstateShouldSaveABaseLandOnCostAndPurchaseCostInContructor()
        {
            int LandOnCost =  10;
            int PurchaseCost = 100;
            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", LandOnCost, PurchaseCost);

            Assert.That(realEstateSpace.purchaseCost, Is.EqualTo(100));
            Assert.That(realEstateSpace.landOnCost, Is.EqualTo(10));

        }


        [Test]
        public void PurchasingARealEstateSpaceShouldChangeTheOwerToTheUserThatPurchaedIt()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space");

            realEstateSpace.Purchase(player1);

            Assert.That(realEstateSpace.Owner, Is.EqualTo(player1));

        }

        [Test]
        public void PurchasingARealEstateSpaceShouldReduceThePurchaseesBalenceByTheCost()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space");

            realEstateSpace.Purchase(player1);

            Assert.That(realEstateSpace.Owner.Balence, Is.EqualTo(player1));

        } 




    }
}
