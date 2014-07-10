using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate.Utilities
{
    public class UtilitySpace : RealEstateSpace
    {
        const int UTILITY_MULTIPLYER = 4;

        public int baseLandOnCost { set; get; }

        public UtilitySpace(string name, int purchaseCost) : base(name, purchaseCost)
        {
            this.baseLandOnCost = baseLandOnCost;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);

            int cost = UTILITY_MULTIPLYER * player.lastRoll;

            if (Owner != player)
            {
                Owner.Balence += cost;
                player.Balence -= cost;
            }
        }
    
    }
}
