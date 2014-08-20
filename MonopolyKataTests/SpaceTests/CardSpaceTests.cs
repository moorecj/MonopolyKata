using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Board.Spaces;
using MonopolyKata.Deck;
using MonopolyKata.Cards;
using Moq;

namespace MonopolyKataTests.SpaceTests
{
    [TestFixture]
    public class DeckSpaceTests
    {
        [Test]
        public void ADeckSpaceShouldTakeADeck()
        {
            IDeck deck = new Deck(Moq.It.IsAny<Card>());

            Assert.That(deck, Is.Not.Null);
        }
    }
}