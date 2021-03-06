﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Cards.WhenDrawnStrategies;
using MonopolyKata.Player;

namespace MonopolyKata.Cards
{
    public class Card : ICard
    {
        public string flavorText{get; set;}
        public IWhenDrawnStrategy whenDrawnStrategy;

        public Card() { }

        public Card(string flavorText, IWhenDrawnStrategy whenDrawnStrategy )
        {
            this.flavorText = flavorText;
            this.whenDrawnStrategy = whenDrawnStrategy;
        }

        public void Draw(IPlayer player)
        {
            whenDrawnStrategy.Apply(player);
        }

    }
}
