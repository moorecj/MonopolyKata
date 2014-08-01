using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Player;
using NUnit.Framework;
using MonopolyKata.Cards;
using MonopolyKata.Cards.WhenDrawnStrategies;
using Moq;


namespace MonopolyKataTests.CardTests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void ACardShouldHaveFlavorText()
        {
            string flavorText = "This is a very awesome Monopoly card";
            Mock<IWhenDrawnStrategy>  whenDrawnStrategyMock = new Mock<IWhenDrawnStrategy>();

            ICard card = new Card(flavorText, whenDrawnStrategyMock.Object);

            Assert.That(card.flavorText, Is.EqualTo(flavorText));
        }

        [Test]
        public void ACardCanHaveAnOwner()
        {
            string flavorText = "This is a very awesome Monopoly card";
            MonopolyPlayer player = new MonopolyPlayer("player 1");
            Mock<IWhenDrawnStrategy> whenDrawnStrategyMock = new Mock<IWhenDrawnStrategy>();
            ICard card = new Card(flavorText, whenDrawnStrategyMock.Object);

            card.SetOwner(player);

            Assert.That(card.Owner, Is.EqualTo(player));
        }

        [Test]
        public void ACardCanShouldTakeAWhenDrawnStrategy()
        {
            string flavorText = "This is a very awesome Monopoly card";
            MonopolyPlayer player = new MonopolyPlayer("player 1");
            Mock<IWhenDrawnStrategy> whenDrawnStrategyMock = new Mock<IWhenDrawnStrategy>();

            ICard card = new Card(flavorText, whenDrawnStrategyMock.Object);

            Assert.That(card, Is.Not.Null);
        }

        [Test]
        public void ACardShouldApplytheAWhenDrawnStrategy_WhenItIsDrawn()
        {
            string flavorText = "This is a very awesome Monopoly card";
            MonopolyPlayer player = new MonopolyPlayer("player 1");
            Mock<IWhenDrawnStrategy> whenDrawnStrategyMock = new Mock<IWhenDrawnStrategy>();

            int count = 0;

            whenDrawnStrategyMock.Setup(m => m.Apply(player)).Callback(() => { count++; });

            ICard card = new Card(flavorText, whenDrawnStrategyMock.Object);

            card.Draw(player);

            Assert.That(count, Is.EqualTo(1));
        }



        


    }
}
