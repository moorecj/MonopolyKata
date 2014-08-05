using MonopolyKata.Player;
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

        public SpaceDecorator(BoardSpace space): base(space.name, space.gameBoard)
        {
            this.space = space;
        }

        public override void LandOn(IPlayer player)
        {
            space.LandOn(player);
        }

    }
    
}
