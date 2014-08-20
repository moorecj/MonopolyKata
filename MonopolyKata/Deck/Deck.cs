using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Cards;
using MonopolyKata.Player;
using MonopolyKata.Extensions;


namespace MonopolyKata.Deck
{
    public class Deck : IDeck
    {
        List<ICard> drawnCards;
        Stack<ICard> cardsToDraw;
        public Deck( params ICard[] cards)
        {
            cardsToDraw = new Stack<ICard>(cards.Shuffle());
            drawnCards = new List<ICard>();
        }

        public string Draw(IPlayer player)
        {
            ICard card;
            card = cardsToDraw.Pop();
            card.Draw(player);

            drawnCards.Add(card);

            if(cardsToDraw.Count == 0)
            {
                cardsToDraw = new Stack<ICard>(drawnCards.Shuffle());
            }
                
            return (card.flavorText);
        }
    }
}
