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

        public RealEstateSpace(string name) : base(name)
        {

        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
        }

        public void Purchase( MonopolyPlayer player)
        {
            
        }
    }
}
