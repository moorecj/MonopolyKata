using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata.Board.Spaces
{
    public class LuxuryTaxSpace : MonopolyBoardSpace
    {
        private const int LUXURY_TAX_AMOUNT = 75;

        public LuxuryTaxSpace(string name, MonopolyGameBoard gameBoard) : base(name, gameBoard) { }

        public override void LandOn(IPlayer player)
        {
            base.LandOn(player);
            player.Balence -= LUXURY_TAX_AMOUNT;
            
        }
    }
    
}
