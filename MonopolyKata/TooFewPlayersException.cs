﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class TooFewPlayersException : Exception
    {
        public TooFewPlayersException(string message): base(message)
        {

        }

    }
}
