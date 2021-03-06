﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board.Spaces.RealEstate;
using MonopolyKata.Board;


namespace MonopolyKataTests
{
    [TestFixture]
    public class RailRoadTests
    {
        MonopolyPlayer player1;
        MonopolyPlayer player2;
        MonopolyGameBoard gameBoard;

        [SetUp]
        public void RailRoadTestSetup()
        {
            player1 = new MonopolyPlayer("player1");
            player2 = new MonopolyPlayer("player2");

            gameBoard = new MonopolyGameBoard();
        }

        [Test]
        public void LandingOnARailRoadWhereTheOwnerOnlyOwnsThatRailRoadPays25ToTheOwner()
        {
            

            player1.Balence = 0;
            player2.Balence = 25;

            int PurchaseCost =  200;

            RealEstateSpace railRoad = new RealEstateSpace("Rail Road Space",gameBoard, PurchaseCost,25,new RailRoadChargingStrategy());

            railRoad.Owner = player1;

            railRoad.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(25));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

        [Test]
        public void LandingOnARailRoadWhereTheOwnerOwnsThatRailRoadAnd1OtherPays50ToTheOwner()
        {

            player1.Balence = 0;
            player2.Balence = 50;

            int PurchaseCost = 200;

            RealEstateSpace railRoad1 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());
            RealEstateSpace railRoad2 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());

            MonopolyGameBoard.GroupSpaces(railRoad1, railRoad2);

            railRoad1.Owner = player1;
            railRoad2.Owner = player1;

            railRoad1.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(50));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

        [Test]
        public void LandingOnARailRoadWhereTheOwnerOwnsThatRailRoadAnd2OthersPays100ToTheOwner()
        {

            player1.Balence = 0;
            player2.Balence = 100;

            int PurchaseCost = 200;

            RealEstateSpace railRoad1 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());
            RealEstateSpace railRoad2 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());
            RealEstateSpace railRoad3 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());

            MonopolyGameBoard.GroupSpaces(railRoad1, railRoad2, railRoad3);

            railRoad1.Owner = player1;
            railRoad2.Owner = player1;
            railRoad3.Owner = player1;

            railRoad1.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(100));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }

        [Test]
        public void LandingOnARailRoadWhereTheOwnerOwnsThatRailRoadAnd3OthersPays200ToTheOwner()
        {
            player1.Balence = 0;
            player2.Balence = 200;

            int PurchaseCost = 200;

            RealEstateSpace railRoad1 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());
            RealEstateSpace railRoad2 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());
            RealEstateSpace railRoad3 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());
            RealEstateSpace railRoad4 = new RealEstateSpace("Rail Road Space", gameBoard, PurchaseCost, 25, new RailRoadChargingStrategy());

            MonopolyGameBoard.GroupSpaces(railRoad1, railRoad2, railRoad3, railRoad4);

            railRoad1.Owner = player1;
            railRoad2.Owner = player1;
            railRoad3.Owner = player1;
            railRoad4.Owner = player1;

            railRoad1.LandOn(player2);

            Assert.That(player1.Balence, Is.EqualTo(200));
            Assert.That(player2.Balence, Is.EqualTo(0));

        }



    }
}
