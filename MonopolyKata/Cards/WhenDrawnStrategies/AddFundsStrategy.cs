using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class AddFundsStrategy : IWhenDrawnStrategy
    {
        private int amount;

        public AddFundsStrategy(int amount )
        {
            this.amount = amount;
        }

        public void Apply(IPlayer player)
        {
            player.Balence += amount;
        }
    }
}
