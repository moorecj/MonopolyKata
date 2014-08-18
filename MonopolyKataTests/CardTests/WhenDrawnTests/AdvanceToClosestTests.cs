using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKataTests.CardTests.WhenDrawnTests
{
    [TestFixture]
    public class AdvanceToClosestTests
    {
        Mock<IMonopolyGameBoard> mockGameBoard;
        BoardSpace boardSpace1;
        BoardSpace boardSpace2;

        [SetUp]
        public void SetUp()
        {
            mockGameBoard = new Mock<IMonopolyGameBoard>();
            boardSpace1 = new MonopolyBoardSpace("Board Space", mockGameBoard.Object);
            boardSpace2 = new MonopolyBoardSpace("Board Space", mockGameBoard.Object);

            mockGameBoard.Setup(m => m.GetSpaceAddress(boardSpace1)).Returns(1);
            mockGameBoard.Setup(m => m.GetSpaceAddress(boardSpace2)).Returns(2);

        }

        
        [Test]
        public void TheAdvanceToClosestStategyShouldTakeAnArrayOfBoardSpaces()
        {
            AdvanceToClosestStrategy moveToStrategy = new AdvanceToClosestStrategy(boardSpace1, boardSpace2);
        }

        [Test]
        public void TheAddvanceToClosestStrategeyShouldMoveThePlayerToTheClosestBoardSpaceInThePositiveDirection()
        {
            AdvanceToClosestStrategy moveToStrategy = new AdvanceToClosestStrategy(boardSpace1, boardSpace2);

            IPlayer player = new MonopolyPlayer("player");

            player.Location = 0;

            moveToStrategy.Apply(player);

            Assert.That(player.Location, Is.EqualTo(1));
        }

        [Test]
        public void TheAddvanceToClosestStrategeyShouldApplyTheLandOnMethodOfTheNewSpace()
        {
            Mock<BoardSpace> mockSpace = new Mock<BoardSpace>();

            IPlayer player = new MonopolyPlayer("player");

            int count = 0;

            mockSpace.Setup(m => m.GetMyLocation()).Returns(1);
            mockSpace.Setup(m => m.LandOn(player)).Callback(() => { count++; });

            AdvanceToClosestStrategy moveToStrategy = new AdvanceToClosestStrategy(mockSpace.Object, boardSpace2);

            moveToStrategy.Apply(player);

            Assert.That(count, Is.EqualTo(1));
        }




    }
}
