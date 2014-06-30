using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class GoSpace : BoardSpace
    {
        private const int LAND_ON_GO_AMOUNT = 200;

        public GoSpace( )
        {
            name = "Go";
        }

        public override void LandOn(MonopolyPlayer player)
        {
            player.Balence += LAND_ON_GO_AMOUNT;
        }

        public static void Pass( MonopolyPlayer player )
        {
            player.Balence += LAND_ON_GO_AMOUNT;
        }
    }
}
