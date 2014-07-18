using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class GoToJailSpace : MonopolyBoardSpace
    {
        JailSpace jail = new JailSpace("jail");

        public GoToJailSpace(string name, JailSpace jail) : base(name)
        {
            this.name = name;
            this.jail = jail;
        }

        public override void LandOn(MonopolyPlayer player)
        {
            base.LandOn(player);
            player.Location = GameBoard.JAIL_LOCATION;
        }

    }
}
