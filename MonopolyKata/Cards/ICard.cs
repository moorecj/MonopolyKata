using MonopolyKata.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards
{
    public interface ICard
    {
        string flavorText { get; }
        IPlayer Owner { get; }
        void SetOwner(IPlayer player);
        void Draw(IPlayer player);
    }
}
