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
        MonopolyPlayer Owner { get; }
        void SetOwner(MonopolyPlayer player);
        void Draw(MonopolyPlayer player);
    }
}
