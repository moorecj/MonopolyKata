using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Player;

namespace MonopolyKata.Deck
{
    public interface IDeck
    {
        string Draw(IPlayer player);
    }
}
