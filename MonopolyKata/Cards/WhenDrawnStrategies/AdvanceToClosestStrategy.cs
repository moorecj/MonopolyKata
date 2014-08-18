using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class AdvanceToClosestStrategy : IWhenDrawnStrategy
    {
        BoardSpace[] spaces;

        public AdvanceToClosestStrategy(params BoardSpace[] spaces)
        {
            this.spaces = spaces;
        }

        public void Apply(IPlayer player)
        {
            BoardSpace theClosestSpace;

            theClosestSpace = spaces[0];

            foreach(BoardSpace s in spaces)
            {
                if (DistanceFromPlayerToSpace(player, s) < DistanceFromPlayerToSpace(player, theClosestSpace))
                {
                    theClosestSpace = s;
                }
            }

            player.Location = theClosestSpace.GetMyLocation();
        }

        private static int DistanceFromPlayerToSpace(IPlayer player, BoardSpace s)
        {
            return s.GetForwardDistanceFromLocation(player.Location);
        }

    
    }
}
