using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Cards;
using MonopolyKata.Player;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKataTests.CardTests.WhenDrawnTests
{
    [TestFixture]
    public class MakePlayerOwnerStrategyTests
    {
        [Test]
        public void AMakePlayerOwnerStrategyShouldTakeAPlayerAndACard()
        {
            IPlayer player = new MonopolyPlayer("player");
            
            ICard card = new Card();

            IWhenDrawnStrategy strategy = new MakePlayerOwnerStrategy(card);

            Assert.That(strategy, Is.Not.Null);
        }

        [Test]
        public void AMakePlayerOwnerStrategyShouldAddedToAPlayersCardsWhenApplied()
        {
            IPlayer player = new MonopolyPlayer("player");
            Card card = new Card();

            IWhenDrawnStrategy strategy = new MakePlayerOwnerStrategy(card);

            card.whenDrawnStrategy = strategy;

            strategy.Apply(player);

            Assert.That(player.GetCardByIndex(0), Is.EqualTo(card));

        }

    }
}
