using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class LuxuryTaxSpace : MonopolyBoardSpace
    {
        private const int LUXURY_TAX_AMOUNT = 75;

        public LuxuryTaxSpace(string name, IMonopolyGameBoard gameBoard) : base(name, gameBoard) { }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
            player.Balence -= LUXURY_TAX_AMOUNT;
            
        }
    }
    
}
