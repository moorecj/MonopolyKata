using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MonopolyKata.Cards.WhenDrawnStrategies;

namespace MonopolyKataTests.CardTests.WhenDrawnTests
{
    [TestFixture]
    public class AddFundsTests
    {
        [Test]
        public void TheAddFundsStrategyWillTakeAnAmmount()
        {
            int amountToAdd = 10;
            AddFundsStrategy addStrategy = new AddFundsStrategy(amountToAdd);

            Assert.That(addStrategy, Is.Not.Null);
        }
    }
}
