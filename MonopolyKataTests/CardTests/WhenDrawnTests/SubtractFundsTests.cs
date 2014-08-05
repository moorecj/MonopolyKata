using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata;
using MonopolyKata.Player;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKataTests.CardTests.WhenDrawnTests
{
    [TestFixture]
    public class SubtractFundsTests
    {
        [Test]
        public void TheSubtractFundsStrategyWillTakeAnAmmount()
        {
            int amountToSubtract = 10;
            SubtractFundsStrategy subtractStrategy = new SubtractFundsStrategy(amountToSubtract);

            Assert.That(subtractStrategy, Is.Not.Null);
        }

        [Test]
        public void TheSubtractFundsStrategyWillSubtractThePastAmountFromTheBalenceWhenApplied()
        {
            int amountToSubtract = 10;
            SubtractFundsStrategy subtractStrategy = new SubtractFundsStrategy(amountToSubtract);
            
            MonopolyPlayer player = new MonopolyPlayer("Player");

            player.Balence = amountToSubtract;

            subtractStrategy.Apply(player);

            Assert.That(player.Balence, Is.EqualTo(0));
        }


    }
}