using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;
using MonopolyKata.Board;
using MonopolyKata.Cards;

namespace MonopolyKata.Player
{  
    public class MonopolyPlayer : IPlayer  
    {
        public string name { get; set; }
        public int Location { get; set; }
        public virtual int Balence{ get; set; }
        public int lastRoll { get; set; }

        public List<ICard> cards;

        public MonopolyPlayer(string name)
        {
            this.name = name;
            Location = 0;
            Balence = 0;

            cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            cards.Add(card);
        }

        public int GetNumberOfCard()
        {
            return cards.Count();
        }

        public ICard GetCard(int cardNumber)
        {
            return (cardNumber >= cards.Count()) ? null : cards[cardNumber];
        }
    }
}
