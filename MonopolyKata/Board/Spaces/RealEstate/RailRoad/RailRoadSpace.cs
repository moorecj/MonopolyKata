using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata.Board.Spaces.RealEstate.RailRoad
{
    public class RailRoadSpace : RealEstateSpace
    {
        const int RAILROAD_LAND_ON_COST = 25;

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
            return RAILROAD_LAND_ON_COST;
        }

    }

}

