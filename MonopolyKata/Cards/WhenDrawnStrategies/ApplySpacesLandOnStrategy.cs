using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Board.Spaces;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class ApplySpacesLandOnStrategy : IWhenDrawnStrategy
    {
        IBoardSpace space;

        public ApplySpacesLandOnStrategy(IBoardSpace space)
        {
            this.space = space;
        }
    
        public void Apply(Player.IPlayer player)
        {
            space.LandOn(player);
        }
}
}
