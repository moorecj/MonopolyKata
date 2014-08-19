using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Cards;
using MonopolyKata.Cards.WhenDrawnStrategies;
using MonopolyKata.Deck;
using MonopolyKata.Player;
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

        [Test]
        public void ADeckShouldReturnTheDrawnCardsTextWhenTheCardIsDrawn()
        {
            ICard card1 = new Card("card1 text", Moq.It.IsAny<IWhenDrawnStrategy>());

            IDeck deck = new Deck(card1);

            String cardText = deck.Draw(new MonopolyPlayer("player"));

            Assert.That(cardText, Is.EquivalentTo("card1 text"));

        }


        [Test]
        public void ADeckShouldPlaceThoseCardsInRandomOrder()
        {
            ICard card1 = new Card("card1 text", Moq.It.IsAny<IWhenDrawnStrategy>());
            ICard card2 = new Card("card2 text", Moq.It.IsAny<IWhenDrawnStrategy>());
            
            ICard[] cardsArray = { card1, card2 };

            IDeck deck = new Deck(cardsArray);
        }


    }
}
