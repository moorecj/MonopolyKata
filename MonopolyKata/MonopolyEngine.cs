using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Extensions;
using MonopolyKata.Board;
using MonopolyKata.Dice;

namespace MonopolyKata
{
    public class MonopolyEngine
    {
        public int Roll1{get; private set;}
        public int Roll2 { get; private set; }

        private MonopolyPlayer currentTurnPlayer;
        private ISetup GameSetup;
        private IDice dice;
        private IMonopolyGameBoard gameBoard;
        int doublesCount;


        public MonopolyEngine( ISetup GameSetup, IDie die )
            :this(GameSetup, die,new GameBoard())
        { }

        public MonopolyEngine(ISetup GameSetup, IDie die, IMonopolyGameBoard gameBoard)
        {
            this.GameSetup = GameSetup;
            dice = new TwoDie(die);
            currentTurnPlayer = GameSetup.WhoGoesFirst();
            this.gameBoard = gameBoard;
        }

        public void TakeTurn()
        {
            do
            {
                dice.Roll();

                if (dice.LastRollWereAllTheSame())
                {
                    doublesCount++;
                }

                if (ThePlayerRolledTooManyDoubles())
                {
                    SendTheCurrentPlayerToJail();
                }

                if (!gameBoard.Jail.IsLockedUp(currentTurnPlayer))
                {
                    gameBoard.Move(currentTurnPlayer, dice.GetDiceRollTotal());
                    gameBoard.LandOnNewSpace(currentTurnPlayer);
                }

            }
            while ((doublesCount > 0) && !(CurrentTurnPlayerIsLoser()) && !gameBoard.Jail.IsLockedUp(currentTurnPlayer)); 

        }

        private void SendTheCurrentPlayerToJail()
        {
            currentTurnPlayer.Location = GameBoard.JAIL_LOCATION;
            doublesCount = 0;
            gameBoard.Jail.LockUp(currentTurnPlayer);
        }

        private bool ThePlayerRolledTooManyDoubles()
        {
            return doublesCount >= 3;
        }


        public void GoToNextTurn()
        {
            currentTurnPlayer = ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist(); 
        }

        public MonopolyPlayer GetCurrentTurnPlayer()
        {
            return currentTurnPlayer;
        }

        private bool PlayerIsLoser(MonopolyPlayer player)
        {
            return player.Balence < 0;
        }

        public bool CurrentTurnPlayerIsLoser()
        {
            return PlayerIsLoser(currentTurnPlayer);
        }

        public bool CurrentTurnPlayerIsWinner()
        {
            return currentTurnPlayer == ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist();
        }

        private MonopolyPlayer ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist()
        {
            MonopolyPlayer initalPlayer = currentTurnPlayer;
            MonopolyPlayer nextPlayer = GameSetup.WhoGoesNext(currentTurnPlayer);

            while (PlayerIsLoser(nextPlayer))
            {
                nextPlayer = GameSetup.WhoGoesNext(nextPlayer);

                if (nextPlayer == initalPlayer)
                {
                    break;
                }     
            }

            return nextPlayer;
        }
        
    }
}
