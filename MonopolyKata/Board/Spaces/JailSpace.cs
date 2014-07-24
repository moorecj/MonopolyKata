using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces
{
    public class JailSpace:MonopolyBoardSpace
    {
        private List<MonopolyPlayer> playersLockedInJail;

        public JailSpace(String name) : base(name)
        {
            playersLockedInJail = new List<MonopolyPlayer>();
        }

        public bool IsLockedUp(MonopolyPlayer player)
        {
            return playersLockedInJail.Contains(player);
        }

        public void LockUp(MonopolyPlayer player)
        {
            playersLockedInJail.Add(player);
        }

        public void Release(MonopolyPlayer player)
        {
            playersLockedInJail.RemoveAll(p => p == player); ;
        }

        public void Pay50ToGetOut(MonopolyPlayer player)
        {
            player.Balence -= 50;

            Release(player);
        }
    }
}
