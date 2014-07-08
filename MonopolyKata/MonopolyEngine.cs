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

        private MonopolyPlayer currentTurnPlayer;

        private ISetup GameSetup;
        private IDice die;

        GameBoard gameBoard;


        public MonopolyEngine( ISetup GameSetup, IDice die )
        {
            this.GameSetup = GameSetup;
            this.die = die;
            currentTurnPlayer = GameSetup.WhoGoesFirst();
            gameBoard = new GameBoard();
        }

        public void TakeTurn()
        {
            int roll1 = die.Roll();
            int roll2 = die.Roll();

            CheckForPassingGo(roll1+roll2);

            currentTurnPlayer.Move(roll1 + roll2);

            gameBoard.LandOnNewSpace(currentTurnPlayer);
        }

        private void CheckForPassingGo(int roll)
        {
            if ((roll + currentTurnPlayer.Location) > GameBoard.NUMBER_OF_GAME_BOARD_SPACES)
            {
                GoSpace.Pass(currentTurnPlayer);
            }
        }

        public void GoToNextTurn()
        {
            currentTurnPlayer = ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist(); 
        }

        private MonopolyPlayer ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist()
        {
            MonopolyPlayer initalPlayer = currentTurnPlayer;
            MonopolyPlayer nextPlayer = GameSetup.WhoGoesNext(currentTurnPlayer);

            while (PlayerIsLoser(nextPlayer))
            {
                nextPlayer = GameSetup.WhoGoesNext(nextPlayer);
                if (nextPlayer == initalPlayer)
                    break;
            }

            return nextPlayer;
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
       
        

    }
}
