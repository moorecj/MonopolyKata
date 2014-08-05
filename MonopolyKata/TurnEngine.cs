using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata;
using MonopolyKata.Dice;
using MonopolyKata.Board;
using MonopolyKata.Player;

namespace MonopolyKata
{
    public class TurnEngine
    {
        IDice dice;
        MonopolyGameBoard gameBoard;
        int doublesInARowCount;

        public TurnEngine(IDice dice, MonopolyGameBoard gameBoard)
        {
            this.dice = dice;
            this.gameBoard = gameBoard;
        }

        public void TakeTurn(IPlayer player)
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

        private void PlayJailedPlayersTurn(IPlayer player)
        {
            dice.Roll();

            gameBoard.Jail.TryToGetOUtWithDoubles(player, dice);

            if (PlayerRanOutOfRollToGetOutOfJailChances(player))
            {
                gameBoard.Jail.Pay50ToGetOut(player);
            }

            AttemptToMovePlayer(player);
        }

        private void PlayANonJailedPlayersTurn(IPlayer player)
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

        private void SendPlayerToJailIfTheyRolledToManyDoubles(IPlayer player)
        {
            if (PlayerRolledTooManyDoubles())
            {
                doublesInARowCount = 0;
                gameBoard.Jail.LockUp(player);
            }
        }

        private bool PlayerRanOutOfRollToGetOutOfJailChances(IPlayer player)
        {
            return !dice.LastRollWereAllTheSame() && (gameBoard.Jail.GetOutFromRollsAttemptCount(player) >= 3);
        }

        private void AttemptToMovePlayer(IPlayer player)
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

        private bool PlayerShouldRollAgain(IPlayer player)
        {
            return PlayerRolledDoubles() && PlayerCanMove(player);
        }

        private bool PlayerRolledDoubles()
        {
            return (doublesInARowCount > 0);
        }

        private bool PlayerCanMove(IPlayer player)
        {
            return !(PlayerIsLoser(player)) && !(gameBoard.Jail.IsLockedUp(player));
        }

        private bool PlayerRolledTooManyDoubles()
        {
            return doublesInARowCount >= 3;
        }

        private bool PlayerIsLoser(IPlayer player)
        {
            return player.Balence < 0;
        }
    }
}
