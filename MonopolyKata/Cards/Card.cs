using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKata.Cards
{
    public class Card : ICard
    {
        public string flavorText{get; private set;}
        public MonopolyPlayer Owner { get; private set; }
        IWhenDrawnStrategy whenDrawnStrategy;

        public Card(string flavorText, IWhenDrawnStrategy whenDrawnStrategy )
        {
            this.flavorText = flavorText;
            this.whenDrawnStrategy = whenDrawnStrategy;
        }

        public void SetOwner( MonopolyPlayer player )
        {
            Owner = player;
        }

        public void Draw( MonopolyPlayer player)
        {
            whenDrawnStrategy.Apply(player);
        }

    }
}
