using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class SubtractFundsStrategy : IWhenDrawnStrategy
    {
        private int amount;

        public SubtractFundsStrategy(int amount)
        {
            this.amount = amount;
        }

        public void Apply(MonopolyPlayer player)
        {
            player.Balence -= amount;
        }
    }
}