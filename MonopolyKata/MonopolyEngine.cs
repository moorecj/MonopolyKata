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
        private IDice die;
        private IGameBoard gameBoard;
        bool currentTurnPlayerGoesAgainFromDoubles;
        int doublesCount;


        public MonopolyEngine( ISetup GameSetup, IDice die )
        {
            this.GameSetup = GameSetup;
            this.die = die;
            currentTurnPlayer = GameSetup.WhoGoesFirst();
            gameBoard = new GameBoard();
        }

        public MonopolyEngine(ISetup GameSetup, IDice die, IGameBoard gameBoard)
        {
            this.GameSetup = GameSetup;
            this.die = die;
            currentTurnPlayer = GameSetup.WhoGoesFirst();
            this.gameBoard = gameBoard;
        }

        public void TakeTurn()
        {
            Roll1 = die.Roll();
            Roll2 = die.Roll();

            RecordTheDoubleRolls();

            if(doublesCount >= 3)
            {
                currentTurnPlayer.Location = GameBoard.JAIL_LOCATION;
                currentTurnPlayerGoesAgainFromDoubles = false;
                doublesCount = 0;
            }
            else
            {
                currentTurnPlayer.Move(Roll1 + Roll2);
                gameBoard.LandOnNewSpace(currentTurnPlayer);

            }

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

            if (currentTurnPlayerGoesAgainFromDoubles)
            {
                nextPlayer = currentTurnPlayer;
            }

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

        private void RecordTheDoubleRolls()
        {
            if (Roll1 == Roll2)
            {
                currentTurnPlayerGoesAgainFromDoubles = true;
                doublesCount++;
            }
            else
            {
                currentTurnPlayerGoesAgainFromDoubles = false;
                doublesCount = 0;
            }
        }

        
       
        

    }
}
