﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board.Spaces.RealEstate.Property;
using MonopolyKata.Board.Spaces;
using Moq;


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
        public void RealEstateShouldSaveAPurchaseCostInContructor()
        {

            int PurchaseCost = 100;
            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space",  PurchaseCost);

            Assert.That(realEstateSpace.purchaseCost, Is.EqualTo(100));


        }

        [Test]
        public void LandingOnAnUnownedRealEstateSpaceShouldPurchaseTheSpaceAutomatically()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space");

            realEstateSpace.LandOn(player1);

            Assert.That(realEstateSpace.Owner, Is.EqualTo(player1));

        }
        

        [Test]
        public void PurchasingARealEstateSpaceShouldReduceThePurchaseesBalenceByTheCost()
        {
            
            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            player1.Balence = 1000;

            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", PurchaseCost);

            realEstateSpace.LandOn(player1);

            Assert.That(player1.Balence, Is.EqualTo(900));

        }

        [Test]
        public void APlayerWillNotPurchaseASpaceIfTheyDoNotHaveEnoughMoney()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            player1.Balence = 0;

            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", PurchaseCost);

            realEstateSpace.LandOn(player1);

            Assert.That(realEstateSpace.Owner, Is.Null);

        }

        [Test]
        public void APlayerCanMortgageARealEstateSpaceFor90PercentOfTheInitialCost()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            player1.Balence = 0;

            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", PurchaseCost);

            realEstateSpace.Owner = player1;

            realEstateSpace.Mortgage(player1);

            Assert.That(player1.Balence, Is.EqualTo(90));
           
        }

        [Test]
        public void LandingOnAMortgagedSpaceResultsInNoBalenceBeingTransfered()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");

            player1.Balence = 0;

            player2.Balence = 10;
            
            int PurchaseCost = 100;
            int LandOnCost = 10;

            RealEstateSpace realEstateSpace = new PropertySpace("Property", LandOnCost, PurchaseCost);

            realEstateSpace.Owner = player1;
            realEstateSpace.Mortgage(player1);

            realEstateSpace.LandOn(player2);

            Assert.That(player2.Balence, Is.EqualTo(10));

        }






    }
}