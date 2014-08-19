using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class MakePlayerOwnerStrategy : IWhenDrawnStrategy
    {
        public ICard card { get; set; }

        public MakePlayerOwnerStrategy(ICard card)
        {
            this.card = card;
        }

        public void Apply(IPlayer player) 
        {
            player.AddCard(this.card);
        }
    }
}
