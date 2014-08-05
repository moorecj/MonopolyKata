using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Board.Spaces.RealEstate;

 
namespace MonopolyKataTests.SpaceTests.RealEstate.ChargingStrategies
{
    [TestFixture]
    class MortgageStrategyTests
    {

        [Test]
        public void APlayerCanMortgageARealEstateSpaceFor90PercentOfTheInitialCost()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyGameBoard gameBoard = new MonopolyGameBoard();

            player1.Balence = 0;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.Owner = player1;

            realEstateSpace.Mortgage(player1);

            Assert.That(player1.Balence, Is.EqualTo(90));

        }

        [Test]
        public void LandingOnAMortgagedSpaceResultsInNoBalenceBeingTransfered()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");
            MonopolyGameBoard gameBoard = new MonopolyGameBoard();

            player1.Balence = 0;

            player2.Balence = 10;

            int PurchaseCost = 100;
            int LandOnCost = 10;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, LandOnCost, strategy);

            realEstateSpace.Owner = player1;
            realEstateSpace.Mortgage(player1);

            realEstateSpace.LandOn(player2);

            Assert.That(player2.Balence, Is.EqualTo(10));

        }

        [Test]
        public void APlayerCanMortgageARealEstateSpaceOnlyOnce()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyGameBoard gameBoard = new MonopolyGameBoard();

            player1.Balence = 0;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.Owner = player1;

            realEstateSpace.Mortgage(player1);
            realEstateSpace.Mortgage(player1);

            Assert.That(player1.Balence, Is.EqualTo(90));

        }

        [Test]
        public void APlayerCannotMortgageARealEstateSpaceThatTheyDontOwn()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");
            MonopolyGameBoard gameBoard = new MonopolyGameBoard();

            player1.Balence = 0;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();
            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.Owner = player2;

            realEstateSpace.Mortgage(player1);

            Assert.That(player1.Balence, Is.EqualTo(0));
        }


        [Test]
        public void APlayerCanUnmortgageASpaceTheyHaveMortgaged()
        {

            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            MonopolyPlayer player2 = new MonopolyPlayer("player2");
            MonopolyGameBoard gameBoard = new MonopolyGameBoard();

            player1.Balence = 10;

            IRealEstateChargingStategy strategy = new PropertyChargingStrategy();

            int PurchaseCost = 100;

            RealEstateSpace realEstateSpace = new RealEstateSpace("Real Estate Space", gameBoard, PurchaseCost, 10, strategy);

            realEstateSpace.Owner = player1;

            realEstateSpace.Mortgage(player1);

            realEstateSpace.Unmortgage(player1);

            Assert.That(player1.Balence, Is.EqualTo(0));
        }

    }
}
