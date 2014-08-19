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

        public void RemoveCard(ICard card)
        {
            cards.Remove(card);
        }
     
        public int GetNumberOfCards()
        {
            return cards.Count();
        }

        public ICard GetCardByIndex(int cardIndex)
        {
            return (cardIndex >= cards.Count()) ? null : cards[cardIndex];
        }



    }
}
