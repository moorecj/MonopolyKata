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

            public void Apply(MonopolyPlayer playerToAddTo)
            {
                MonopolyPlayer playerToTakeFrom = playerSetup.WhoGoesFirst();
                MonopolyPlayer initalPlayer = playerToTakeFrom;

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

            private void TransferAsMuchOfAmountAsIsAvailable(MonopolyPlayer playerToAddTo, MonopolyPlayer playerToTakeFrom)
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
