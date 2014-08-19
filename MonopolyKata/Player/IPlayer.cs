using System;
using MonopolyKata.Cards;

namespace MonopolyKata.Player
{
    public interface IPlayer
    {
        int Balence { get; set; }
        int lastRoll { get; set; }
        int Location { get; set; }
        string name { get; set; }

        void AddCard( ICard card);
        void RemoveCard(ICard card);
        int GetNumberOfCards();
        ICard GetCardByIndex(int cardIndex);
    }
}
