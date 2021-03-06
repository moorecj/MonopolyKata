﻿using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{

    public class RealEstateSpace : MonopolyBoardSpace
    {
        public IPlayer Owner { get; set; }
        public int purchaseCost {  get; private set; }
        public List<RealEstateSpace> groupProperties;
        public int baseLandOnCost { get; set; }
        IRealEstateChargingStategy currentChargingStrategy;
        IRealEstateChargingStategy standardChargingStrategy;
        IRealEstateChargingStategy mortgagedChargingStrategy;


        public RealEstateSpace(string name, MonopolyGameBoard gameBoard, int purchaseCost, int baseLandOnCost, IRealEstateChargingStategy standardChargingStrategy)
            : this(name, gameBoard, purchaseCost, baseLandOnCost, standardChargingStrategy, new MortgageChargingStrategy())
        { }


        public RealEstateSpace(string name,  MonopolyGameBoard gameBoard, int purchaseCost, int baseLandOnCost, IRealEstateChargingStategy standardChargingStrategy, IRealEstateChargingStategy mortgagedChargingStrategy)
            : base(name, gameBoard)
        {
            this.purchaseCost = purchaseCost;

            groupProperties = new List<RealEstateSpace>();

            this.baseLandOnCost = baseLandOnCost;

            currentChargingStrategy = standardChargingStrategy;
            this.standardChargingStrategy = standardChargingStrategy;
            this.mortgagedChargingStrategy = mortgagedChargingStrategy;
        }

        public override void LandOn(IPlayer player)
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
                currentChargingStrategy.ChargePlayer(player, this);
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

        private void Purchase(IPlayer player)
        {
            Owner = player;

            player.Balence -= purchaseCost;

        }

        public void Mortgage(IPlayer player) 
        {
            if (currentChargingStrategy == standardChargingStrategy)
            {
                if(player == Owner)
                {
                    player.Balence += (this.purchaseCost * 90) / 100;
                    currentChargingStrategy = mortgagedChargingStrategy;
                }
                
            }
        }

        public void Unmortgage(IPlayer player)
        {
            if (currentChargingStrategy == mortgagedChargingStrategy)
            {
                if (player == Owner)
                {
                    player.Balence -= this.purchaseCost;
                    currentChargingStrategy = standardChargingStrategy;
                }

            }

        }

    }
}
