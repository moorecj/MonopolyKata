using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate.Utilities
{
    public class UtilitySpace : RealEstateSpace
    {

        public int baseLandOnCost { set; get; }

        public UtilitySpace(string name, int purchaseCost) : base(name, purchaseCost)
        {
            this.baseLandOnCost = baseLandOnCost;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);

            int cost = player.lastRoll * GetUtilityMultiplier();

            if (Owner != player)
            {
                Owner.Balence += cost;
                player.Balence -= cost;
            }
        }

        private int GetUtilityMultiplier()
        {
            int multiplier;

            if ((CountOfOtherOwners() >= 1))
            {
                multiplier = 10;    
            }
            else
            {
                multiplier = 4;  
            }

            return multiplier;
        }

        private int CountOfOtherOwners()
        {
            return groupProperties.Where(p => p.Owner != null).Count();
        }
    
    }
}
