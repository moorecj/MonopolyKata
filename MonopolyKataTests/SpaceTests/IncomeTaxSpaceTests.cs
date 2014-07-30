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
    public class IncomeTaxSpaceTests
    {
        [Test]
        public void LandingOnIncomeTaxWithABalenceLessThen2000ShouldResultIn10PercentDeductionFromBalance()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");
            
            MonopolyBoardSpace incomeTaxSpace = new IncomeTaxSpace("Income Tax", new MonopolyGameBoard());

            player1.Balence = 100;

            incomeTaxSpace.LandOn(player1);

            Assert.That(player1.Balence, Is.EqualTo(90));
        }

        [Test]
        public void LandingOnIncomeTaxWithABalenceGreaterThan2000ShouldResultIn200DeductionFromBalance()
        {
            MonopolyPlayer player1 = new MonopolyPlayer("player1");

            MonopolyBoardSpace incomeTaxSpace = new IncomeTaxSpace("Income Tax", new MonopolyGameBoard());

            player1.Balence = 2200;

            incomeTaxSpace.LandOn(player1);

            Assert.That(player1.Balence, Is.EqualTo(2000));
        }
    }
}
