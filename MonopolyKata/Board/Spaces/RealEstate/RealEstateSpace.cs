using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{

    public class RealEstateSpace : MonopolyBoardSpace, IMortgage
    {
        public MonopolyPlayer Owner{ get; set; }
        public int purchaseCost {  get; private set; }
        protected List<RealEstateSpace> groupProperties;

        public RealEstateSpace(string name) : base(name){ }

        public RealEstateSpace(string name, int purchaseCost) : base(name) 
        {
            this.purchaseCost = purchaseCost;

            groupProperties = new List<RealEstateSpace>();
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

        public static void GroupSpaces(params RealEstateSpace[] spaces)
        {
            for (int i = 0; i < spaces.Length-1; ++i )
            {
                for (int j = i+1; j < spaces.Length; ++j )
                {
                    spaces[i].AddSpaceToGroup(spaces[j]);
                    spaces[j].AddSpaceToGroup(spaces[i]);
                }
            }
        }



        public void AddSpaceToGroup( RealEstateSpace spaceToAdd )
        {
            groupProperties.Add(spaceToAdd);
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

        void Motgage(RealEstateSpace space, MonopolyPlayer player) 
        {
            space = new MortgageRealEstate(space, player);
        }

        void Unmortage(RealEstateSpace space, MonopolyPlayer player)
        {

        }

    }
}
