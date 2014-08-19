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
    public class ApplySpacesLandOnStrategyTests
    {
        Mock<IBoardSpace> mockBoardSpace;


        [SetUp]
        public void SetUp()
        {
            mockBoardSpace = new Mock<IBoardSpace>();
        }

        [Test]
        public void ApplySpacesLandOnStrategyShouldTakeABoardSpaces()
        {
            ApplySpacesLandOnStrategy moveToStrategy = new ApplySpacesLandOnStrategy(mockBoardSpace.Object);
            Assert.That(moveToStrategy, Is.Not.Null);
        }

        [Test]
        public void ApplySpacesLandOnStrategyShouldCallTheLandOnStrategyWhenApplied()
        {
            ApplySpacesLandOnStrategy moveToStrategy = new ApplySpacesLandOnStrategy(mockBoardSpace.Object);

            int count = 0;

            mockBoardSpace.Setup(m => m.LandOn(Moq.It.IsAny<IPlayer>())).Callback(() => { count++; });

            moveToStrategy.Apply(Moq.It.IsAny<IPlayer>());

            Assert.That(count, Is.EqualTo(1));
        }
    }
}

