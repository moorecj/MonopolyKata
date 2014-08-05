using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class MoveToClosestStrategy : IWhenDrawnStrategy
    {
        List<BoardSpace> spaces;

        public MoveToClosestStrategy(params BoardSpace[] spaces)
        {

        }

        public void Apply(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
