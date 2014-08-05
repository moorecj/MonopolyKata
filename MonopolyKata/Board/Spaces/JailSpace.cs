using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Dice;
using MonopolyKata.Player;

namespace MonopolyKata.Board.Spaces
{

    public class JailSpace:MonopolyBoardSpace
    {
        private List<IPlayer> escapeAttemptsWithRolls;
        private List<IPlayer> playersLockedInJail;

        public JailSpace(string name, IMonopolyGameBoard gameBoard): base(name, gameBoard)
        {
            playersLockedInJail = new List<IPlayer>();
            escapeAttemptsWithRolls = new List<IPlayer>();
        }

        public bool IsLockedUp(IPlayer player)
        {
            return playersLockedInJail.Contains(player);
        }

        public void LockUp(IPlayer player)
        {
            player.Location = gameBoard.GetSpaceAddress(gameBoard.Jail);
            playersLockedInJail.Add(player);
        }

        public void Release(IPlayer player)
        {
            playersLockedInJail.RemoveAll(p => p == player);
            escapeAttemptsWithRolls.RemoveAll(p => p == player); 
        }

        public void Pay50ToGetOut(IPlayer player)
        {
            player.Balence -= 50;

            Release(player);
        }

        public void TryToGetOUtWithDoubles(IPlayer player, IDice dice)
        {
            escapeAttemptsWithRolls.Add(player);

            if(dice.LastRollWereAllTheSame())
            {
                Release(player);
            }
            
        }

        public int GetOutFromRollsAttemptCount(IPlayer player)
        {
            return escapeAttemptsWithRolls.Count(p => p == player);
        }
    }
}
