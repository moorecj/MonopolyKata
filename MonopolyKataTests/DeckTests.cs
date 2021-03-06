﻿using System;
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
            IWhenDrawnStrategy strategy = new AddFundsStrategy(0);
            
            ICard card1 = new Card("card1 text", strategy);

            IDeck deck = new Deck(card1);

            String cardText = deck.Draw(new MonopolyPlayer("player"));

            Assert.That(cardText, Is.EquivalentTo("card1 text"));

        }


        [Test]
        public void ADeckShouldPlaceCardsInRandomOrderUponDeckCreation()
        {
            ICard card1 = new Card("card1 text", new AddFundsStrategy(0));
            ICard card2 = new Card("card2 text", new AddFundsStrategy(0));
            

            List<IDeck> ListOfDecks = new List<IDeck>();

            for (int i = 0; i < 100; ++i)
            {
                ListOfDecks.Add(new Deck(card1, card2));
            }


            IEnumerable<IDeck> differentOrder = from g in ListOfDecks
                                                where g.Draw(new MonopolyPlayer("Player")).Equals("card2 text")
                                                select g;

            int diffentCount = differentOrder.Count();

            Assert.That(diffentCount, Is.GreaterThan(1));
            Assert.That(diffentCount, Is.LessThan(99));
        }


        [Test]
        public void ADeckShouldReshuffleTheDrawnCardsInOnceAllTheCardsRunOUt()
        {
            ICard card1 = new Card("card1 text", new AddFundsStrategy(0));
            ICard card2 = new Card("card2 text", new AddFundsStrategy(0));

            IDeck deck = new Deck(card1, card2);

            int diffentCount = 0; 

            for (int i = 0; i < 100; ++i)
            {
                String text1 = deck.Draw(new MonopolyPlayer("Player"));
                deck.Draw(new MonopolyPlayer("Player"));

                String text2 = deck.Draw(new MonopolyPlayer("Player"));
                deck.Draw(new MonopolyPlayer("Player"));

                if(text1.Equals(text2))
                {
                    diffentCount++;
                }


            }

            Assert.That(diffentCount, Is.GreaterThan(1));
            Assert.That(diffentCount, Is.LessThan(99));
        }





    }
}
