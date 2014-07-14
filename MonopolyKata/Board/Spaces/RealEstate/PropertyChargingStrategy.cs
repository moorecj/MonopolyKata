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
            int multiplier;

            if (OwnerOfThisSpaceOwnsTheRestInGroup( realEstateSpace ))
            {
                multiplier = 2;
            }
            else
            {
                multiplier = 1;
            }

            return multiplier;
        }

        private bool OwnerOfThisSpaceOwnsTheRestInGroup(RealEstateSpace realEstateSpace)
        {
            List<RealEstateSpace> groupProperties = realEstateSpace.groupProperties;
            return ((groupProperties.Count() == groupProperties.Where(p => p.Owner == realEstateSpace.Owner).Count()) && groupProperties.Count() > 0);
        }
    }
}
