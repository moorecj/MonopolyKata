using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class MonopolyBoardSpace : BoardSpace
    {
        public MonopolyBoardSpace( string name ) : base( name )
        {

        }

        public override void LandOn(MonopolyPlayer player)
        {
            if (CheckForPassingGo(player))
            {
                GoSpace.Pass(player);
            }
            

        }

        private bool CheckForPassingGo(MonopolyPlayer player)
        {
            return ((player.Location - player.lastRoll) < 0) && player.Location != GameBoard.GO_LOCATION;
        }

        

    }
}
