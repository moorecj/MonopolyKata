using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class PrintWhereLanded : SpaceDecorator
    {
        public PrintWhereLanded(BoardSpace space) : base ( space )
        {

        }

        public override void LandOn(MonopolyPlayer player)
        {
            Console.WriteLine(player.name + " has landed on " + name);
            space.LandOn(player);
        }

        
    }
}
