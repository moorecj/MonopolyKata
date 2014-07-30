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
        private TurnEngine turnEngine;
        public  IMonopolyGameBoard gameBoard;


        public MonopolyEngine( ISetup GameSetup, IDie die )
            :this(GameSetup, die,new MonopolyGameBoard())
        { }

        public MonopolyEngine(ISetup GameSetup, IDie die, IMonopolyGameBoard gameBoard)
        {
            this.GameSetup = GameSetup;
            currentTurnPlayer = GameSetup.WhoGoesFirst();
            this.gameBoard = gameBoard;

            turnEngine = new TurnEngine(new TwoDie(die), gameBoard);
        }

        public void TakeTurn()
        {
            turnEngine.TakeTurn(currentTurnPlayer);   
        }

        public void GoToNextTurn()
        {
            currentTurnPlayer = ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist();
        }

        public MonopolyPlayer GetCurrentTurnPlayer()
        {
            return currentTurnPlayer;
        }

        public bool CurrentTurnPlayerIsLoser()
        {
            return PlayerIsLoser(currentTurnPlayer);
        }

        public bool CurrentTurnPlayerIsWinner()
        {
            return currentTurnPlayer == ReturnNextValidPlayerOrCurrentPlayerIfNoValidPlayersExist();
        }

        private bool PlayerIsLoser(MonopolyPlayer player)
        {
            return player.Balence < 0;
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
