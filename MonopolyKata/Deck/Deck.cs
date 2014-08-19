using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Cards;

namespace MonopolyKata.Deck
{
    public class Deck : IDeck
    {
        List<ICard> cards;

        public Deck( params ICard[] cards)
        {
            this.cards = cards.ToList();
        }

        public void Draw(Player.IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
