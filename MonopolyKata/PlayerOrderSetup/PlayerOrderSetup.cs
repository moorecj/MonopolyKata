﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyKata.Extensions;
using MonopolyKata.Dice;
using MonopolyKata.Player;

namespace MonopolyKata.Setup
{
    
    public class PlayerOrderSetup : IPlayerOrderSetup
    {
        private const int MAX_NUMBER_OF_PLAYERS = 8;
        private const int MIN_NUMBER_OF_PLAYERS = 2;

        private List<IPlayer> playOrder;

        public PlayerOrderSetup(params String[] playerNames )
        {
            CheckForTooManyPlayers(playerNames);
            CheckForTooFewPlayers(playerNames);
            PopulatePlayOrderList(playerNames);
            RandomizePlayOrder();

        }

        public PlayerOrderSetup(params IPlayer[] players)
        {
            CheckForTooManyPlayers(players);
            CheckForTooFewPlayers(players);
            playOrder = players.ToList<IPlayer>();
            RandomizePlayOrder();
        }

        private void RandomizePlayOrder()
        {
            playOrder = playOrder.Shuffle();
        }

        public void PopulatePlayOrderList(String[] playerNames)
        {
            playOrder = new List<IPlayer>();

            foreach (String s in playerNames)
            {
                playOrder.Add(new MonopolyPlayer(s));
            }
        }

        public IPlayer WhoGoesFirst()
        {
            return playOrder[0];
        }

        public IPlayer WhoGoesNext(IPlayer player)
        {
            int nextPlayerIndex = playOrder.FindIndex(p => p == player) + 1;

            if (nextPlayerIndex >= playOrder.Count())
            {
                nextPlayerIndex = 0;
            }

            return playOrder[nextPlayerIndex];
        }

        public void CheckForTooFewPlayers<T>(T[] players)
        {
            if (players.Count() < MIN_NUMBER_OF_PLAYERS)
            {
                throw new TooFewPlayersException(String.Format("Too few players: {0}", players.Count()));
            }
        }

        public void CheckForTooManyPlayers<T>(T[] players)
        {
            if (players.Count() > MAX_NUMBER_OF_PLAYERS)
            {
                throw new TooManyPlayersException(String.Format("Too many players: {0}", players.Count()));
            }
        }

    }
}
