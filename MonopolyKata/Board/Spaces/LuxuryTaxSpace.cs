﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    class LuxuryTaxSpace : MonopolyBoardSpace
    {
        private const int LUXURY_TAX_AMOUNT = 75;

        public LuxuryTaxSpace(string name) : base(name) { }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
            player.Balence -= LUXURY_TAX_AMOUNT;
            
        }
    }
    
}