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
        public List<RealEstateSpace> groupProperties;
        public int baseLandOnCost { get; set; }
        IRealEstateChargingStategy chargingStrategy;
        
        
        public RealEstateSpace(string name) : base(name){ }


        public RealEstateSpace(string name, int purchaseCost, int baseLandOnCost, IRealEstateChargingStategy chargingStrategy) : base(name) 
        {
            this.purchaseCost = purchaseCost;

            groupProperties = new List<RealEstateSpace>();

            this.chargingStrategy = chargingStrategy;
            this.baseLandOnCost = baseLandOnCost;
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
            else
            {
                chargingStrategy.ChargePlayer(player,this);
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

        public void Mortgage( MonopolyPlayer player ) 
        {
            if(!(chargingStrategy is MortgageChargingStrategy))
            {
                if(player == Owner)
                {
                    player.Balence += (this.purchaseCost * 90) / 100;
                    chargingStrategy = new MortgageChargingStrategy();
                }
                
            }
        }

        void Unmortage(RealEstateSpace space, MonopolyPlayer player)
        {

        }

    }
}
