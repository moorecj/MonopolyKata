﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class TooManyPlayersException : Exception
    {
        public TooManyPlayersException(string message) : base(message)
        { 

        }

    }
}
