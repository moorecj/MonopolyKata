using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public interface IWhenDrawnStrategy
    {
        void Apply(MonopolyPlayer player);
    }
}
