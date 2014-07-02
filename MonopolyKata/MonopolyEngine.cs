using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Extensions;
using MonopolyKata.Board;

namespace MonopolyKata
{
    public class MonopolyEngine
    {

        private MonopolyPlayer currentTurnPlayer;

        private ISetup GameSetup;

        GameBoard gameBoard;

        public MonopolyEngine( ISetup GameSetup )
        {

            this.GameSetup = GameSetup;
            currentTurnPlayer = GameSetup.WhoGoesFirst();
            gameBoard = new GameBoard();


        }

        public void TakeTurn()
        {
            int roll = GameSetup.GetDiceRolls();

            CheckForPassingGo(roll);

            currentTurnPlayer.Move(roll);

            gameBoard.LandOnNewSpace(currentTurnPlayer);
            
            GoToNextTurn();
        }

        private void CheckForPassingGo(int roll)
        {
            if ((roll + currentTurnPlayer.Location) > 40)
            {
                GoSpace.Pass(currentTurnPlayer);
            }
        }

        private void GoToNextTurn()
        {
            currentTurnPlayer = GameSetup.WhoGoesNext(currentTurnPlayer);
        }

        public MonopolyPlayer GetCurrentTurnPlayer()
        {
            return currentTurnPlayer;
        }

       
        

    }
}
