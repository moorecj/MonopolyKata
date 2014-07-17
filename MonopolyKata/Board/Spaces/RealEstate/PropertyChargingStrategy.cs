using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{
    public class PropertyChargingStrategy:IRealEstateChargingStategy
    {
        public PropertyChargingStrategy() { }

        public void ChargePlayer(MonopolyPlayer player, RealEstateSpace realEstateSpace)
        {
            if (realEstateSpace.Owner != player)
            {
                int multiplier = GetRentMultiplier(realEstateSpace);

                realEstateSpace.Owner.Balence += realEstateSpace.baseLandOnCost * multiplier;
                player.Balence -= realEstateSpace.baseLandOnCost * multiplier;
            }
        }

        private int GetRentMultiplier( RealEstateSpace realEstateSpace )
        {
            int multiplier = 1;

            if (OwnerOfThisSpaceOwnsTheRestInGroup( realEstateSpace ))
            {
                multiplier = 2;
            }

            return multiplier;
        }

        private bool OwnerOfThisSpaceOwnsTheRestInGroup(RealEstateSpace realEstateSpace)
        {
            return(realEstateSpace.groupProperties.Count(p => p.Owner == realEstateSpace.Owner) > 0);
        }
    }
}
