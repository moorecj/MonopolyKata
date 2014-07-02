using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class GoToJailSpace : MonopolyBoardSpace
    {
        public GoToJailSpace(string name) : base(name)
        {
            this.name = name; 
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
            player.Location = GameBoard.JAIL_LOCATION;

            Console.WriteLine(player.name + " goes to Jail without passing GO :(\n");
        }

    }
}
