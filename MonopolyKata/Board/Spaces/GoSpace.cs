using MonopolyKata.Board.Spaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Board;
using MonopolyKata.Player;

namespace MonopolyKata
{
    public class GoSpace : MonopolyBoardSpace
    {
        private const int LAND_ON_GO_AMOUNT = 200;
        private const int PASS_GO_AMOUNT = 200;

        public GoSpace(string name, MonopolyGameBoard gameBoard) : base(name, gameBoard) { }

        public override void LandOn(IPlayer player) 
        {
            base.LandOn(player);
            player.Balence += LAND_ON_GO_AMOUNT;
        }

        public static void Pass(IPlayer player) 
        {
            player.Balence += PASS_GO_AMOUNT;
        }

        
    }
}
