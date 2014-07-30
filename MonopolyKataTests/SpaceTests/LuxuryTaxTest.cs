using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Board.Spaces;


namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class LuxuryTaxTest
    {
        [Test]
        public void LandingOnLuxuryTaxShouldReduceAPlayersBalenceBy75()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            IMonopolyGameBoard gameBoard = new MonopolyGameBoard();

            player1.Balence = 100;

            MonopolyBoardSpace luxuryTaxSpace = new LuxuryTaxSpace("Luxury Tax", gameBoard);

            luxuryTaxSpace.LandOn(player1); 

            Assert.That(player1.Balence, Is.EqualTo(25));
        }
    }
}
