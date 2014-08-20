using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Board;
using MonopolyKata.Deck;
using MonopolyKata.Cards;
using MonopolyKata.Player;
using Moq;

namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class DeckSpaceTests
    {
        [Test]
        public void ACardSpaceShouldTakeADeck()
        {
            IDeck deck = new Deck(Moq.It.IsAny<Card>());

            IBoardSpace cardSpace = new CardSpace(Moq.It.IsAny<string>(), Moq.It.IsAny<MonopolyGameBoard>(), deck);

            Assert.That(cardSpace, Is.Not.Null);
        }

        [Test]
        public void ACardSpaceShouldTakeDrawACardWhenLandedOn()
        {
            Mock<ICard> mockCard = new Mock<ICard>();

            int count = 0;

            mockCard.Setup(m => m.Draw(Moq.It.IsAny<MonopolyPlayer>())).Callback(() => { count++; });

            IDeck deck = new Deck(mockCard.Object);

            Assert.That(count, Is.EqualTo(1));
        }


    }
}