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

        public void MoveTheCurrentTurnPlayer(int numberOfSpaces)
        {
            currentTurnPlayer.Move(numberOfSpaces);  
        }

        public void GoToNextTurn()
        {
            currentTurnPlayer = GameSetup.WhoGoesNext(currentTurnPlayer);
        }

        public MonopolyPlayer GetCurrentTurnPlayer()
        {
            return currentTurnPlayer;
        }

       
        

    }
}
