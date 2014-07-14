using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Board.Spaces.RealEstate
{
    public interface IRealEstateChargingStategy
    {
        void ChargePlayer(MonopolyPlayer player, RealEstateSpace realEstateSpace);
    }
}
