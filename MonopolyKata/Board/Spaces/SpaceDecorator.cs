using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{

    public abstract class SpaceDecorator : BoardSpace
    {
        protected BoardSpace space;

        public SpaceDecorator(BoardSpace space): base(space.name)
        {
            this.space = space;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            space.LandOn(player);
        }

    }
    
}
