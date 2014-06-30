using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Extensions;

namespace MonopolyKata
{
    public class Monopoly
    {

        private MonopolyPlayer currentTurnPlayer;

        private ISetup GameSetup;

        public Monopoly( ISetup GameSetup )
        {

            this.GameSetup = GameSetup;

            currentTurnPlayer = GameSetup.WhoGoesFirst();

        }

        public void RollForCurrentTurnPlayer()
        {

            int roll = GameSetup.GetDiceRolls();

            if( roll + currentTurnPlayer.Location > 40)
            {
                GoSpace.Pass(currentTurnPlayer);    
            }

            currentTurnPlayer.Move(GameSetup.GetDiceRolls());

            GoToNextTurn();
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
