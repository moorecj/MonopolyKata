using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    abstract public class BoardSpace
    {
        public string name { get; set; }

        public BoardSpace()
        {

            
        }

        abstract public void LandOn(MonopolyPlayer player);

    }

    


}
