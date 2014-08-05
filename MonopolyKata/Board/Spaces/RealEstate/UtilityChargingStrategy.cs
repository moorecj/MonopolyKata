using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{
    public class UtilityChargingStrategy:IRealEstateChargingStategy
    {
        public UtilityChargingStrategy() { }

        public void ChargePlayer(IPlayer player, RealEstateSpace realEstateSpace)
        {
            int cost = player.lastRoll * GetUtilityMultiplier(realEstateSpace.groupProperties);

            if (realEstateSpace.Owner != player)
            {
                realEstateSpace.Owner.Balence += cost;
                player.Balence -= cost;
            }
        }

        private int GetUtilityMultiplier(List<RealEstateSpace> groupProperties)
        {
            int multiplier;

            if ((CountOfOtherOwners(groupProperties) >= 1))
            {
                multiplier = 10;
            }
            else
            {
                multiplier = 4;
            }

            return multiplier;
        }

        private int CountOfOtherOwners(List<RealEstateSpace> groupProperties)
        {
            return groupProperties.Where(p => p.Owner != null).Count();
        }
    }
}
