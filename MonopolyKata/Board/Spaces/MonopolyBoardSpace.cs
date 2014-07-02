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
            Console.WriteLine(player.name + " landed on " + name );
        }

    }
}
