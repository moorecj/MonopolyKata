using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{
    public class RailRoadChargingStrategy:IRealEstateChargingStategy
    {

        public RailRoadChargingStrategy() {}

        public void ChargePlayer(MonopolyPlayer player, RealEstateSpace realEstateSpace)
        {
            if (realEstateSpace.Owner != player)
            {
                int cost = GetRailRoadLandOnCost( realEstateSpace);
                realEstateSpace.Owner.Balence += cost;
                player.Balence -= cost;
            }
        }

        private int GetRailRoadLandOnCost(RealEstateSpace realEstateSpace)
        {

            int NumberOfOtherRailRoadsOwned = realEstateSpace.groupProperties.Where(p => p.Owner == realEstateSpace.Owner).Count();

            return (realEstateSpace.baseLandOnCost * (int)IntPower(2, (short)(NumberOfOtherRailRoadsOwned)));

        }

        private long IntPower(int x, short power)
        {
            if (power == 0) return 1;
            if (power == 1) return x;

            int n = 15;
            while ((power <<= 1) >= 0) n--;

            long tmp = x;
            while (--n > 0)
                tmp = tmp * tmp *
                     (((power <<= 1) < 0) ? x : 1);
            return tmp;
        }
    }
}
