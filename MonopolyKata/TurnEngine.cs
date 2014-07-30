using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Dice;
using MonopolyKata.Board;

namespace MonopolyKata
{
    public class TurnEngine
    {
        IDice dice;
        IMonopolyGameBoard gameBoard;
        int doublesInARowCount;

        public TurnEngine(IDice dice, IMonopolyGameBoard gameBoard)
        {
            this.dice = dice;
            this.gameBoard = gameBoard;
        }

        public void TakeTurn(MonopolyPlayer player)
        {
            if (gameBoard.Jail.IsLockedUp(player))
            {
                PlayJailedPlayersTurn(player);
            }
            else
            {
                PlayANonJailedPlayersTurn(player);
            } 
        }

        private void PlayJailedPlayersTurn(MonopolyPlayer player)
        {
            dice.Roll();

            gameBoard.Jail.TryToGetOUtWithDoubles(player, dice);

            if (PlayerRanOutOfRollToGetOutOfJailChances(player))
            {
                gameBoard.Jail.Pay50ToGetOut(player);
            }

            AttemptToMovePlayer(player);
        }

        private void PlayANonJailedPlayersTurn(MonopolyPlayer player)
        {
            do
            {
                dice.Roll();

                AccountDiceRoll();

                SendPlayerToJailIfTheyRolledToManyDoubles(player);

                AttemptToMovePlayer(player);

            }
            while (PlayerShouldRollAgain(player));
        }

        private void SendPlayerToJailIfTheyRolledToManyDoubles(MonopolyPlayer player)
        {
            if (PlayerRolledTooManyDoubles())
            {
                doublesInARowCount = 0;
                gameBoard.Jail.LockUp(player);
            }
        }

        private bool PlayerRanOutOfRollToGetOutOfJailChances(MonopolyPlayer player)
        {
            return !dice.LastRollWereAllTheSame() && (gameBoard.Jail.GetOutFromRollsAttemptCount(player) >= 3);
        }

        private void AttemptToMovePlayer(MonopolyPlayer player)
        {
            if (PlayerCanMove(player))
            {
                gameBoard.Move(player, dice.GetDiceRollTotal());
                gameBoard.LandOnNewSpace(player);
            }
        }

        private void AccountDiceRoll()
        {
            if (dice.LastRollWereAllTheSame())
            {
                doublesInARowCount++;
            }
            else
            {
                doublesInARowCount = 0;
            }

        }

        private bool PlayerShouldRollAgain(MonopolyPlayer player)
        {
            return PlayerRolledDoubles() && PlayerCanMove(player);
        }

        private bool PlayerRolledDoubles()
        {
            return (doublesInARowCount > 0);
        }

        private bool PlayerCanMove(MonopolyPlayer player)
        {
            return !(PlayerIsLoser(player)) && !(gameBoard.Jail.IsLockedUp(player));
        }

        private bool PlayerRolledTooManyDoubles()
        {
            return doublesInARowCount >= 3;
        }

        private bool PlayerIsLoser(MonopolyPlayer player)
        {
            return player.Balence < 0;
        }
    }
}
