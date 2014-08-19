using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Cards;
using MonopolyKata.Deck;
namespace MonopolyKataTests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void ADeckShouldTakeAnArrayOfCards()
        {
            ICard [] cardsArray = {new Card(), new Card()};
            IDeck deck = new Deck(cardsArray);
        }
    }
}
