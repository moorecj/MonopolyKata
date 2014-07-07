using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{

    public class RealEstateSpace : MonopolyBoardSpace
    {
        public MonopolyPlayer Owner{ get; set; }
        public int landOnCost{ get; private set;}
        public int purchaseCost {  get; private set; }

        public RealEstateSpace(string name) : base(name){ }

        public RealEstateSpace(string name, int landOnCost, int purchaseCost) : base(name) 
        {
            this.landOnCost = landOnCost;
            this.purchaseCost = purchaseCost;
        }


        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
        }

        public void Purchase( MonopolyPlayer player)
        {
            Owner = player;    
        }
    }
}
