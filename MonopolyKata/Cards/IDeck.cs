using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata.Cards
{
    public interface IDeck
    {
        void Shuffle();
        void DrawCard(MonopolyPlayer player);
    }
}
