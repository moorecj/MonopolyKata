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
        public int purchaseCost {  get; private set; }

        public RealEstateSpace(string name) : base(name){ }

        public RealEstateSpace(string name, int purchaseCost) : base(name) 
        {
            this.purchaseCost = purchaseCost;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);

            if (SpaceIsForSale())
            {
                if(player.Balence >= purchaseCost)
                {
                    Purchase(player);
                }
                
            }

        }

        private bool SpaceIsForSale()
        {
            return Owner == null;
        }

        private void Purchase( MonopolyPlayer player)
        {
            Owner = player;

            player.Balence -= purchaseCost;

        }
    }
}
