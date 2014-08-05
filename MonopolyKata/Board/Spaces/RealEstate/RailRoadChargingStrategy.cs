using MonopolyKata.Player;
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

        public void ChargePlayer(IPlayer player, RealEstateSpace realEstateSpace)
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

            return 25 * (Int32)Math.Pow(2, NumberOfOtherRailRoadsOwned);
        }
    }
}
