using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards.WhenDrawnStrategies
{
    public class GetFundsFromOthersStrategy: IWhenDrawnStrategy
    {

       
            private int amountToTransfer;
            IPlayerOrderSetup playerSetup;

            public GetFundsFromOthersStrategy(int amountToTransfer, IPlayerOrderSetup playerSetup)
            {
                this.amountToTransfer = amountToTransfer;
                this.playerSetup = playerSetup;
            }

            public void Apply(IPlayer playerToAddTo)
            {
                IPlayer playerToTakeFrom = playerSetup.WhoGoesFirst();
                IPlayer initalPlayer = playerToTakeFrom;

                do
                {
                    if(playerToAddTo != playerToTakeFrom)
                    {
                        TransferAsMuchOfAmountAsIsAvailable(playerToAddTo, playerToTakeFrom);
                    }

                    playerToTakeFrom = playerSetup.WhoGoesNext(playerToTakeFrom);

                }
                while (playerToTakeFrom != initalPlayer);
            }

            private void TransferAsMuchOfAmountAsIsAvailable(IPlayer playerToAddTo, IPlayer playerToTakeFrom)
            {
                if (playerToTakeFrom.Balence < amountToTransfer)
                {
                    playerToAddTo.Balence += playerToTakeFrom.Balence;
                }
                else
                {
                    playerToAddTo.Balence += amountToTransfer;
                }

                playerToTakeFrom.Balence -= amountToTransfer;
            }
        
    }
}
