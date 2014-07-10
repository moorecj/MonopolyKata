using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate.Property
{
    public class PropertySpace : RealEstateSpace
    {
        public int baseLandOnCost { set; get; }
        public PropertySpace(string name, int baseLandOnCost, int purchaseCost) : base(name, purchaseCost)
        {
            this.baseLandOnCost = baseLandOnCost;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);

            if(Owner !=  player)           
            {
                int multiplier = GetRentMultiplier();

                Owner.Balence += baseLandOnCost * multiplier;
                player.Balence -= baseLandOnCost * multiplier;
            }


        }

        private int GetRentMultiplier()
        {
            int multiplier;

            if (ThisOwnerOwnsTheRestInGroup())
            {
                multiplier = 2;
            }
            else
            {
                multiplier = 1;
            }
            return multiplier;
        }

        private bool ThisOwnerOwnsTheRestInGroup()
        {
            return((groupProperties.Count() == groupProperties.Where(p => p.Owner == Owner).Count() ) && groupProperties.Count() > 0);
        }

    }
}
