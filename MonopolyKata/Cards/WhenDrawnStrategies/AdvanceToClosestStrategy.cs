using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Board.Spaces;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class AdvanceToClosestStrategy : IWhenDrawnStrategy
    {
        IBoardSpace[] spaces;

        public AdvanceToClosestStrategy(params IBoardSpace[] spaces)
        {
            this.spaces = spaces;
        }

        public void Apply(IPlayer player)
        {
            IBoardSpace theClosestSpace;

            theClosestSpace = spaces[0];

            theClosestSpace = FindTheClosestSpace(player, theClosestSpace);

            player.Location = theClosestSpace.GetMyLocation();

            theClosestSpace.LandOn(player);
        }

        private IBoardSpace FindTheClosestSpace(IPlayer player, IBoardSpace theClosestSpace)
        {
            foreach (IBoardSpace s in spaces)
            {
                if (DistanceFromPlayerToSpace(player, s) < DistanceFromPlayerToSpace(player, theClosestSpace))
                {
                    theClosestSpace = s;
                }
            }
            return theClosestSpace;
        }

        private static int DistanceFromPlayerToSpace(IPlayer player, IBoardSpace s)
        {
            return s.GetForwardDistanceFromLocation(player.Location);
        }

    
    }
}
