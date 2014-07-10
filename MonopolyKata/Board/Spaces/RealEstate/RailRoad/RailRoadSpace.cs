using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Board.Spaces.RealEstate.RailRoad
{
    public class RailRoadSpace : RealEstateSpace
    {
        const int BASE_RAILROAD_LAND_ON_COST = 25;

        public int baseLandOnCost { set; get; }

        public RailRoadSpace(string name, int purchaseCost) : base(name, purchaseCost)
        {
            this.baseLandOnCost = baseLandOnCost;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);

            if (Owner != player)
            {
                Owner.Balence += GetRailRoadLandOnCost();
                player.Balence -= GetRailRoadLandOnCost();
            }
        }

        private int GetRailRoadLandOnCost()
        {

            int NumberOfOtherRailRoadsOwned = groupProperties.Where(p => p.Owner == Owner).Count();

            return (BASE_RAILROAD_LAND_ON_COST * (int)IntPower(2, (short)(NumberOfOtherRailRoadsOwned)));
            
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

