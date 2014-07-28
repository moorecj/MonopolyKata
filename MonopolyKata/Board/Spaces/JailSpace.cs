using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Dice;

namespace MonopolyKata.Board.Spaces
{

    public class JailSpace:MonopolyBoardSpace
    {
        private List<MonopolyPlayer> escapeAttemptsWithRolls;
        private List<MonopolyPlayer> playersLockedInJail;

        public JailSpace(String name) : base(name)
        {
            playersLockedInJail = new List<MonopolyPlayer>();
            escapeAttemptsWithRolls = new List<MonopolyPlayer>();
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

        public void TryToGetOUtWithDoubles(MonopolyPlayer player, IDice dice)
        {

            escapeAttemptsWithRolls.Add(player);

            if(dice.LastRollWereAllTheSame())
            {
                Release(player);
            }
            
        }

        public int GetOutFromRollsAttemptCount(MonopolyPlayer player)
        {
            return escapeAttemptsWithRolls.Count(p => p == player);
        }
    }
}
