using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Board;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Setup;


namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class CardSpaceTests
    {
        [Test]
        public void ACardSpaceShouldTakeAPlayerSetup()
        {
            PlayerOrderSetup setup = new PlayerOrderSetup("player1","player2");
            MonopolyGameBoard gameBoard = new MonopolyGameBoard();

            CardSpace cardSpace = new CardSpace("card space", gameBoard, setup);

            Assert.That(cardSpace, Is.Not.Null);
        }
    }
}
