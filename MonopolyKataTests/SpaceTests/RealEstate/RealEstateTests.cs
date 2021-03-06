﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board.Spaces;
using Moq;


namespace MonopolyKataTests
{
    [TestFixture]
    public class RealEstateTests
    {

        MonopolyPlayer player1;
        MonopolyGameBoard gameBoard;

        [SetUp]
        public void RailRoadTestSetup()
        {
            player1 = new MonopolyPlayer("player1");
            gameBoard = new MonopolyGameBoard();
        }

        [Test]
        public void RealEstateShouldHaveAnOwnerInitializedToNull()
        {
            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 100;
            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            Assert.That( realEstateSpace.Owner, Is.EqualTo(null));

        }

        [Test]
        public void RealEstateShouldSaveAPurchaseCostInContructor()
        {
            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 100;
            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            Assert.That(realEstateSpace.purchaseCost, Is.EqualTo(100));
        }

        [Test]
        public void LandingOnAnUnownedRealEstateSpaceShouldPurchaseTheSpaceAutomatically()
        {

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 0;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.LandOn(player1);

            Assert.That(realEstateSpace.Owner, Is.EqualTo(player1));

        }
        

        [Test]
        public void PurchasingARealEstateSpaceShouldReduceThePurchaseesBalenceByTheCost()
        {

            player1.Balence = 1000;

            int PurchaseCost = 100;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.LandOn(player1);

            Assert.That(player1.Balence, Is.EqualTo(900));

        }

        [Test]
        public void APlayerWillNotPurchaseASpaceIfTheyDoNotHaveEnoughMoney()
        {

            player1.Balence = 0;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.LandOn(player1);

            Assert.That(realEstateSpace.Owner, Is.Null);

        }


    }
}
